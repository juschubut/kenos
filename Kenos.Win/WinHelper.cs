using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Kenos.Win
{
    public class WinHelper
    {
        private static string _version = null;

        public static void ComboBoxSelectByText(ComboBox cbo, string txt)
        {
            int idx = cbo.FindStringExact(txt);
            if (idx >= 0)
                cbo.SelectedIndex = idx;
            else
                cbo.SelectedIndex = -1;
        }

        internal static void LoadComboBoxFromDelimitedText(ComboBox combo, string values)
        {
            combo.Items.Clear();

            string[] items = Regex.Split(values, System.Environment.NewLine);

            foreach (string item in items)
            {
                combo.Items.Add(item);
            }
        }


        public static double GetEspacioLibreDisco()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    if (Properties.Settings.Default.PathGrabacion.StartsWith(drive.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return drive.TotalFreeSpace;
                    }
                }
            }

            return 0;
        }


        public static string GenerarHashSHA1(string file)
        {
            try
            {
                using (FileStream stream = File.OpenRead(file))
                {
                    using (SHA1Managed sha = new SHA1Managed())
                    {
                        byte[] checksum = sha.ComputeHash(stream);
                        return BitConverter.ToString(checksum);
                    }
                }
            }
            catch (Exception)
            {
                return "Error generando HASH - " + file;
            }
        }

        public static string Version
        {
            get
            {
                if (_version == null)
                {
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

                    _version = fvi.FileVersion;
                }

                return _version;
            }
        }

    }
}
