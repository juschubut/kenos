using Kenos.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kenos.Common
{
    public abstract class ConnectorBase : IConnector
    {
        public ILog Log
        {
            get { return Kenos.Logger.Log.Logger; }
        }

        public abstract Metadata Nueva();

        
        public virtual void Finalizar(Metadata config)
        {
            Log.Info("Finalizar");
        }

        public virtual void Cancelar(Metadata config)
        {
            Log.Info("Cancelar");
        }

        public abstract string Nombre { get; }


        public bool Copiar(string sourceFileName, string destinationFileName)
        {
            if (!File.Exists(sourceFileName))
            {
                Log.Debug("El archivo que se desea copiar no existe");

                return false;
            }

            int chunk = 0;
            int chunkSize = 32 * 1024;
            long acumulado = 0;
            long total = new FileInfo(sourceFileName).Length;


            Application.DoEvents();

            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(sourceFileName, FileMode.Open, FileAccess.Read)))
                {
                    using (BinaryWriter bw = new BinaryWriter(File.Open(destinationFileName, FileMode.Create, FileAccess.Write)))
                    {
                        byte[] buffer = new byte[chunkSize];

                        while ((chunk = br.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            acumulado += chunk;

                            bw.Write(buffer, 0, chunk);

                            Application.DoEvents();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(new ApplicationException("Error mientras se copiaba archivo de grabación", ex));

                MessageBox.Show("Se produjo un error mientras se copiaba el archivo", "Kenos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
         
       
    }
}
