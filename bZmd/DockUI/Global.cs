using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;      // for [CallerLineNumber], > .NET 4.5
using System.Text;
using System.Threading.Tasks;

namespace bZmd.DockUI
{
	public partial class Global
	{
		public static string toNavi = string.Empty;   // todo, add to list que
		public static string ActiveDocumentFullName = string.Empty;
		public static bool isRunning = false;

		public static int DebugLevel = 3;

		public static void myDebug(     //  todo, check for SharpDevelopment support
			string msg, int level = 3,
		 	[CallerLineNumber] int lineNumber = 0,
		    [CallerMemberName] string caller = null)
        {
			if (level <= DebugLevel)
				Debug.WriteLine(string.Format("({1}) *{0}: {2}", lineNumber, caller, msg));
		}

	}
}
