using System;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Linq;
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


			if (IsProcessOpen())
			{
				MessageBox.Show("La aplicación ya se encuentra en funcionamiento.");
				return;
			}
			if (!Debugger.IsAttached)
			{
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

			if (Process.GetProcessesByName(Properties.Settings.Default.ObsFileName).Length > 1)
			{
				return true;
			}

			var processes = Process.GetProcesses();

			var obs = processes.Where(x => x.ProcessName.Contains("obs")).ToList();

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
