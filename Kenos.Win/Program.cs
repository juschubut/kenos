using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Kenos.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Debugger.IsAttached)
            {
                if (IsProcessOpen())
                {
                    MessageBox.Show("La aplicación ya se encuentra en funcionamiento.");
                    return;
                }

                if (Properties.Settings.Default.RegistracionHabilitada)
                {
                    Register.RegistrarInstalacion();
                }
            }

            Application.Run(new frmMain());
        }

        public static bool IsProcessOpen()
        {
             Process process = Process.GetCurrentProcess();

             if (Process.GetProcessesByName(process.ProcessName).Length > 1)
            {
                return true;
            }

             return false;
        }


        public static bool IsUserInGroup(string username, string groupname, ContextType type)
        {
            PrincipalContext context = new PrincipalContext(type);

            UserPrincipal user = UserPrincipal.FindByIdentity(
                context,
                IdentityType.SamAccountName,
                username);
            GroupPrincipal group = GroupPrincipal.FindByIdentity(
                context, groupname);

            return user.IsMemberOf(group);
        }
    }

}
