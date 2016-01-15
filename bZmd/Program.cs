using System;
using System.Windows.Forms;

namespace bZmd
{
	static class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DockUI.MainForm());
		}
	}
}
