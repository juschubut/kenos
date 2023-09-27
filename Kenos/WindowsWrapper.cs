using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kenos
{
	public class WindowsWrapper
	{
		#region Constants 
		private const int SWP_NOOWNERZORDER = 0x200;
		private const int SWP_NOREDRAW = 0x8;
		private const int SWP_NOZORDER = 0x4;
		private const int SWP_SHOWWINDOW = 0x0040;
		private const int WS_EX_MDICHILD = 0x40;
		private const int SWP_FRAMECHANGED = 0x20;
		private const int SWP_NOACTIVATE = 0x10;
		private const int SWP_ASYNCWINDOWPOS = 0x4000;
		private const int SWP_NOMOVE = 0x2;
		private const int SWP_NOSIZE = 0x1;
		private const int GWL_STYLE = (-16);
		private const int WS_VISIBLE = 0x10000000;
		private const int WM_CLOSE = 0x10;
		private const int WS_CHILD = 0x40000000;
		#endregion

		#region Windows Functions
		[DllImport("user32.dll")]
		private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


		[DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
		private static extern long GetWindowLong(IntPtr hwnd, int nIndex);

		[DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
		private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

		[DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
		private static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);
		#endregion

		public static void DisplayOnPanel(Process process, Panel panel)
		{
			SetParent(process.MainWindowHandle, panel.Handle);

			try
			{
				// Remueve los bordes 
				SetWindowLong(process.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
			}
			catch { }
		}

	}
}
