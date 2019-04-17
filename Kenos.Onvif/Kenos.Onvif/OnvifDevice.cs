using Kenos.Onvif.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Onvif
{
    public class OnvifDevice
    {
        public string Host { get; private set; }
        public int Port { get; private set; }
        public string Username { get; private set; }
        private string Passwrod { get; set; }

        private EndpointAddress _endpointAddress;
        private CustomBinding _customBinding;
        private PasswordDigestBehavior _passwordDigestBehavior;

        #region Events
        public event Events.OnLogEventHandler OnLog;
        #endregion

        #region Configs
        private OnvifServices.v10.Media.Profile _profile;

        public void SetCurrentProfile(string profileToken)
        {
            _profile = this.Media.GetProfile(profileToken);
        }

        private OnvifServices.v10.Media.Profile Profile
        {
            get
            {
                if (_profile == null)
                    LoadDefaultProfile();

                return _profile;
            }
        }

        private OnvifServices.v10.Media.PTZConfiguration PTZConfig
        {
            get { return _profile.PTZConfiguration; }
        }
        #endregion

        #region Services
        private OnvifServices.v10.DeviceManagement.DeviceClient _deviceClient;
        private OnvifServices.v20.PTZ.PTZClient _ptzClient;
        private OnvifServices.v10.Media.MediaClient _mediaClient;

        public OnvifServices.v10.DeviceManagement.DeviceClient Managment
        {
            get
            {
                if (_deviceClient == null)
                    ConnectDeviceManagement();
                return _deviceClient;
            }
        }
        public OnvifServices.v20.PTZ.PTZClient PTZ
        {
            get
            {
                if (_ptzClient == null)
                    ConnectPTZ();

                return _ptzClient;
            }
        }
        public OnvifServices.v10.Media.MediaClient Media
        {
            get
            {
                if (_mediaClient == null)
                    ConnectMedia();

                return _mediaClient;
            }
        }
        #endregion

        #region Tokens
        public string ProfileToken
        {
            get { return this.Profile.token; }
        }

        public string PTZConfigToken
        {
            get { return this.Profile.PTZConfiguration.token; }
        }
        #endregion

        public OnvifDevice(string host, int port, string username, string password)
        {
            this.Host = host;
            this.Port = port;
            this.Username = username;
            this.Passwrod = password;

            Initialize();
        }

        #region Connect
        private void ConnectDeviceManagement()
        {
            _deviceClient = new OnvifServices.v10.DeviceManagement.DeviceClient(_customBinding, _endpointAddress);
            _deviceClient.Endpoint.Behaviors.Add(_passwordDigestBehavior);
        }

        private void ConnectMedia()
        {
            _mediaClient = new OnvifServices.v10.Media.MediaClient(_customBinding, _endpointAddress);
            _mediaClient.Endpoint.Behaviors.Add(_passwordDigestBehavior);
        }

        private void ConnectPTZ()
        {
            _ptzClient = new OnvifServices.v20.PTZ.PTZClient(_customBinding, _endpointAddress);
            _ptzClient.Endpoint.Behaviors.Add(_passwordDigestBehavior);
        }
        #endregion

        public DeviceInformation GetDeviceInformation()
        {
            string model;
            string firmwareVersion;
            string serialNumber;
            string hardwareId;

            this.Managment.GetDeviceInformation(out model, out  firmwareVersion, out serialNumber, out hardwareId);

            return new DeviceInformation
            {
                Model = model,
                FirmwareVersion = firmwareVersion,
                SerialNumber = serialNumber,
                HardwareId = hardwareId
            };
        }

        public GetProfilesResponse GetProfiles()
        {
            var rs = new GetProfilesResponse();

            try
            {
                var profiles = this.Media.GetProfiles();
                List<ProfileInfo> list = new List<ProfileInfo>();

                foreach (OnvifServices.v10.Media.Profile profile in profiles)
                {
                    list.Add(new ProfileInfo
                    {
                        Token = profile.token,
                        Description = string.Format("{0} - {1}x{2} fs{3}", profile.token, profile.VideoEncoderConfiguration.Resolution.Width, profile.VideoEncoderConfiguration.Resolution.Height, profile.VideoEncoderConfiguration.RateControl.FrameRateLimit),
                        Profile = profile
                    });
                }

                rs.Profiles = list.ToArray();
            }
            catch (Exception ex)
            {
                rs.Exception = ex;
                rs.Message = "Error recuperando lista de perfiles.";
            }

            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }

        public GetRTSPStreamUriResponse GetRTSPStreamUri()
        {
            return GetRTSPStreamUri(this.Profile.token);
        }

        private GetRTSPStreamUriResponse GetRTSPStreamUri(string mediaProfileToken)
        {
            GetRTSPStreamUriResponse rs = new GetRTSPStreamUriResponse();

            try
            {
                OnvifServices.v10.Media.StreamSetup setup = new OnvifServices.v10.Media.StreamSetup
                {
                    Stream = OnvifServices.v10.Media.StreamType.RTPUnicast,
                    Transport = new OnvifServices.v10.Media.Transport
                    {
                        Protocol = OnvifServices.v10.Media.TransportProtocol.RTSP,
                    }
                };

                var mediaUri = this.Media.GetStreamUri(setup, mediaProfileToken);

                rs.Uri = mediaUri.Uri;
            }
            catch (Exception ex)
            {
                rs.Exception = ex;
                rs.Message = "Error recuperando RTSP uri.";
            }

            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }

        public GetPresetsResponse GetPresets()
        {
            var rs = new GetPresetsResponse();

            var chk = this.CheckPTZSupported();

            rs.Attach(chk);

            if (rs.IsSuccess)
            {
                try
                {
                    List<string> result = new List<string>();

                    OnvifServices.v20.PTZ.PTZPreset[] presets = this.PTZ.GetPresets(this.ProfileToken);

                    rs.Presets = presets.Select(x => x.Name).ToArray();
                }
                catch (Exception ex)
                {
                    rs.Message = "Error recuperando los presets del dispositivo.";
                    rs.Exception = ex;
                }

            }

            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }

        public OperationResponse GoToPreset(string preset)
        {
            OperationResponse rs = new OperationResponse();

            try
            {
                OnvifServices.v20.PTZ.PTZPreset ptzPreset = this.PTZ.GetPresets(this.ProfileToken).Where(x => x.Name.Equals(preset, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                this.PTZ.GotoPreset(this.ProfileToken, ptzPreset.token, null);
            }
            catch (Exception ex)
            {
                rs = new OperationResponse
                {
                    Message = "Error en la operacion de preset",
                    Exception = ex
                };
            }

            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }

        public OperationResponse Ping()
        {
            OperationResponse rs = new OperationResponse();

            try
            {
                rs = LoadDefaultProfile();

                return rs;
            }
            catch (Exception ex)
            {
                rs = new OperationResponse
                {
                    Message = "No se puede conectar con la camara ip",
                    Exception = ex
                };
            }

            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }

        #region OnLog
        private void RaiseOnLog(OperationResponse rs)
        {
            RaiseOnLog(rs.Message, rs.Exception);
        }

        private void RaiseOnLog(string message)
        {
            RaiseOnLog(message, null);
        }

        private void RaiseOnLog(string message, Exception ex)
        {
            if (this.OnLog != null)
            {
                Events.OnLogEventArgs e = new Events.OnLogEventArgs(message, ex);

                this.OnLog(this, e);
            }
        }

        #endregion

        #region Move
        public OperationResponse MoveLeft()
        {
            return this.Move(-1, 0);
        }

        public OperationResponse MoveRight()
        {
            return this.Move(1, 0);
        }

        public OperationResponse MoveUp()
        {
            return this.Move(0, 1);
        }

        public OperationResponse MoveDown()
        {
            return this.Move(0, -1);
        }

        private OperationResponse Move(int directionX, int directionY)
        {
            var rs = this.CheckPTZSupported();

            if (rs.IsSuccess)
            {
                try
                {
                    this.PTZ.ContinuousMove(
                        this.ProfileToken,
                        new OnvifServices.v20.PTZ.PTZSpeed
                        {
                            PanTilt = new OnvifServices.v20.PTZ.Vector2D
                            {
                                x = 0.5f * directionX,
                                y = 0.5f * directionY
                            }
                        },
                        "PT10S" //10 segundos. Formato de duracion https://www.w3schools.com/xml/schema_dtypes_date.asp
                    );
                }
                catch (Exception ex)
                {
                    rs = new OperationResponse
                    {
                        IsSuccess = false,
                        Message = "Error moviendo el dispositivo.",
                        Exception = ex
                    };
                }
            }
            
            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }

        public OperationResponse MoveStop()
        {
            var rs = this.CheckPTZSupported();

            if (rs.IsSuccess)
            {
                try
                {
                    this.PTZ.Stop(this.ProfileToken, true, true);
                }
                catch (Exception ex)
                {
                    rs = new OperationResponse
                    {
                        IsSuccess = false,
                        Exception = ex,
                        Message = "Error finalizando movimiento del dispositivo"
                    };
                }
            }

            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }

        /// <summary>
        /// Movimiento absoluto del dispositivo. 
        /// </summary>
        /// <param name="x">Valores entre -1 y 1</param>
        /// <param name="y">Valores entre -1 y 1</param>
        public OperationResponse AbsoluteMove(float x, float y)
        {
            var rs = this.CheckPTZSupported();

            if (rs.IsSuccess)
            {
                if (!this.IsAbsoluteMoveSupported)
                {
                    rs.IsSuccess = true;
                    rs.Message = "Operacion de Movimiento Absoluto no soportada";
                }
            }

            if (rs.IsSuccess)
            {
                try
                {
                    OnvifServices.v20.PTZ.PTZNode node = this.PTZ.GetNodes()[0];

                    if (node != null)
                    {
                        OnvifServices.v20.PTZ.FloatRange xRange = node.SupportedPTZSpaces.AbsolutePanTiltPositionSpace[0].XRange;
                        OnvifServices.v20.PTZ.FloatRange yRange = node.SupportedPTZSpaces.AbsolutePanTiltPositionSpace[0].YRange;

                        if (x < xRange.Min || x > xRange.Max)
                        {
                            throw new KenosOnvifException(string.Format("Valor x inválido. x: {0}", x));
                        }
                        if (y < yRange.Min || y > yRange.Max)
                        {
                            throw new KenosOnvifException(string.Format("Valor y inválido. y: {0}", y));
                        }
                    }

                    OnvifServices.v20.PTZ.PTZVector position = new OnvifServices.v20.PTZ.PTZVector
                    {
                        PanTilt = new OnvifServices.v20.PTZ.Vector2D
                        {
                            x = x,
                            y = y,
                            space = this.PTZConfig.DefaultAbsolutePantTiltPositionSpace
                        }
                    };

                    OnvifServices.v20.PTZ.PTZSpeed speed = new OnvifServices.v20.PTZ.PTZSpeed
                    {
                        PanTilt = new OnvifServices.v20.PTZ.Vector2D
                        {
                            space = this.PTZConfig.DefaultPTZSpeed.PanTilt.space,
                            x = this.PTZConfig.DefaultPTZSpeed.PanTilt.x,
                            y = this.PTZConfig.DefaultPTZSpeed.PanTilt.y
                        },
                        Zoom = new OnvifServices.v20.PTZ.Vector1D()
                        {
                            space = this.PTZConfig.DefaultPTZSpeed.Zoom.space,
                            x = this.PTZConfig.DefaultPTZSpeed.Zoom.x
                        }
                    };

                    this.PTZ.AbsoluteMove(this.ProfileToken, position, speed);
                }
                catch (Exception ex)
                {
                    rs.Message = "Error realizando movimiento absoluto";
                    rs.Exception = ex;
                }
            }

            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }

        public OperationResponse RelativeMove(float x, float y)
        {
            OperationResponse rs = this.CheckPTZSupported();

            if (rs.IsSuccess)
            {
                if (!this.IsRelativeMoveSupported)
                {
                    rs.IsSuccess = false;
                    rs.Message = "Operacion de Movimiento Relativo no soportada";
                }
            }

            if (rs.IsSuccess)
            {
                try
                {
                    OnvifServices.v20.PTZ.PTZNode node = this.PTZ.GetNodes()[0];

                    if (node != null)
                    {
                        OnvifServices.v20.PTZ.FloatRange xRange = node.SupportedPTZSpaces.RelativePanTiltTranslationSpace[0].XRange;
                        OnvifServices.v20.PTZ.FloatRange yRange = node.SupportedPTZSpaces.RelativePanTiltTranslationSpace[0].YRange;

                        if (x < xRange.Min || x > xRange.Max)
                        {
                            throw new KenosOnvifException(string.Format("Valor x inválido. x: {0}", x));
                        }
                        if (y < yRange.Min || y > yRange.Max)
                        {
                            throw new KenosOnvifException(string.Format("Valor y inválido. y: {0}", y));
                        }
                    }

                    OnvifServices.v20.PTZ.PTZVector translation = new OnvifServices.v20.PTZ.PTZVector
                    {
                        PanTilt = new OnvifServices.v20.PTZ.Vector2D
                        {
                            x = x,
                            y = y,
                            space = this.PTZConfig.DefaultRelativePanTiltTranslationSpace
                        }
                    };

                    OnvifServices.v20.PTZ.PTZSpeed speed = new OnvifServices.v20.PTZ.PTZSpeed
                    {
                        PanTilt = new OnvifServices.v20.PTZ.Vector2D
                        {
                            space = this.PTZConfig.DefaultPTZSpeed.PanTilt.space,
                            x = this.PTZConfig.DefaultPTZSpeed.PanTilt.x,
                            y = this.PTZConfig.DefaultPTZSpeed.PanTilt.y
                        },
                        Zoom = new OnvifServices.v20.PTZ.Vector1D()
                        {
                            space = this.PTZConfig.DefaultPTZSpeed.Zoom.space,
                            x = this.PTZConfig.DefaultPTZSpeed.Zoom.x
                        }
                    };

                    this.PTZ.RelativeMove(this.ProfileToken, translation, speed);
                }
                catch (Exception ex)
                {
                    RaiseOnLog("Error realizando movimiento relativo", ex);
                }
            }


            if (!rs.IsSuccess)
                RaiseOnLog(rs);

            return rs;
        }
        #endregion

        #region IsSupported
        public bool IsRtspSupported
        {
            get { return this.RtspProtocol != null; }
        }

        private OperationResponse CheckPTZSupported()
        {
            if (this.IsPTZSupported)
                return new OperationResponse { IsSuccess = true, Message = "Ok" };

            return new OperationResponse { IsSuccess = false, Message = "Operación PTZ no soportada" };
        }

        public bool IsPTZSupported
        {
            get
            {
                return (this.Profile.PTZConfiguration != null);
            }
        }

        public bool IsAbsoluteMoveSupported
        {
            get
            {
                return (this.PTZConfig != null && this.PTZConfig.DefaultAbsolutePantTiltPositionSpace != null);
            }
        }

        public bool IsRelativeMoveSupported
        {
            get
            {
                return (this.PTZConfig != null && this.PTZConfig.DefaultRelativePanTiltTranslationSpace != null);
            }
        }

        public bool IsContinuousMoveSupported
        {
            get
            {
                return (this.PTZConfig != null && this.PTZConfig.DefaultContinuousPanTiltVelocitySpace != null);
            }
        }

        public bool IsZoomSupported
        {
            get
            {
                return (this.PTZConfig != null && (this.PTZConfig.DefaultAbsoluteZoomPositionSpace != null || this.PTZConfig.DefaultContinuousZoomVelocitySpace != null || this.PTZConfig.DefaultRelativeZoomTranslationSpace != null));
            }
        }
        #endregion

        #region Metodos Privados

        public OnvifServices.v10.DeviceManagement.NetworkProtocol RtspProtocol
        {
            get
            {
                return this.Managment.GetNetworkProtocols()
                    .Where(x => x.Name.ToString().Equals("rtsp", StringComparison.InvariantCultureIgnoreCase))
                    .FirstOrDefault();
            }
        }

        private void Initialize()
        {
            ServicePointManager.Expect100Continue = false;

            string uri = string.Format("http://{0}:{1}/onvif/device_service", this.Host, this.Port);

            _endpointAddress = new EndpointAddress(uri);

            var httpTransportBinding = new HttpTransportBindingElement { AuthenticationScheme = AuthenticationSchemes.Digest };
            var textMessageEncodingBinding = new TextMessageEncodingBindingElement { MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None) };
            _customBinding = new CustomBinding(textMessageEncodingBinding, httpTransportBinding);
            _passwordDigestBehavior = new PasswordDigestBehavior(this.Username, this.Passwrod);
        }

        private OperationResponse LoadDefaultProfile()
        {
            OperationResponse rs = new OperationResponse();

            OnvifServices.v10.Media.Profile[] profiles = null;

            try
            {

                profiles = this.Media.GetProfiles();

                if (profiles == null || profiles.Length == 0)
                {
                    _profile = new OnvifServices.v10.Media.Profile();

                    rs.Message = "No se encontro ningun Perfil para utiliar";
                    rs.IsSuccess = false;

                    RaiseOnLog(rs.Message);

                    return rs;
                }

                this.SetCurrentProfile(profiles[0].token);

                rs.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _profile = new OnvifServices.v10.Media.Profile();

                rs.IsSuccess = false;
                rs.Exception = ex;
                rs.Message = "Error conectando con servicio ONVIF Media";

                RaiseOnLog(rs);
            }

            return rs;
        }
        #endregion


       
    }
}
