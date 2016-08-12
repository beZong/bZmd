using bZmd.DockUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;

namespace bZmd.Watcher
{
	class WindowWatcher
	{
		// https://social.msdn.microsoft.com/Forums/en-US/2ee1e7ae-946f-4394-b09d-7d1021d8be23/how-to-get-the-active-windows-title?forum=csharpgeneral
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		// getwindowthreadprocessid - http://www.pinvoke.net/default.aspx/user32.getwindowthreadprocessid
		// https://pinvoke.codeplex.com/

		public static bool isRunning = true;

		private static Thread workerThread = null;
		private static string passFileName = string.Empty;
		private static string watchFileName = string.Empty;
		private static Stopwatch stopwatch = new Stopwatch();
	
		private static string WinGetText(IntPtr hWnd)
		{
			int chars = 256;
			StringBuilder buff = new StringBuilder(chars);
			if (GetWindowText(hWnd, buff, chars) > 0)
			{
				return buff.ToString();
			}
			return "";
		}

		public class Condition
		{
			Func<AutomationElement, object> _func = null;
			object _result = null;

			public Condition(Func<AutomationElement, object> func, object result)
			{
				_func = func;
				_result = result;
            }

			public bool Test(AutomationElement a)
			{
				if (_result is string)
					return string.Equals((string)_result, _func(a) as string, StringComparison.InvariantCultureIgnoreCase);
				else
					return _result.Equals(_func(a));
			}
		}

		public static string FetchFileName()
		{
			if (workerThread == null || !workerThread.IsAlive)
			{
				workerThread = new Thread(Worker);
				workerThread.Start();
				passFileName = string.Empty;
				watchFileName = string.Empty;
			}
			return passFileName;
		}

		private static void Worker()
		{
			TreeWalker walker = TreeWalker.RawViewWalker;
			string thisFileName = string.Empty;

			while (Global.isRunning)
			{
				Thread.Sleep(130);

				// Obtain the handle of the active window.
				IntPtr win_id = GetForegroundWindow();
				if (win_id == IntPtr.Zero)
				{
					passFileName = string.Empty;
					watchFileName = string.Empty;
					continue;
				}

				if (watchFileName != thisFileName)
				{
					watchFileName = thisFileName;
					stopwatch.Restart();
				}

				if (stopwatch.ElapsedMilliseconds >= 500)
					passFileName = watchFileName;

				try
				{
					// string win_title = WinGetText(win_id);
					var aWin = AutomationElement.FromHandle(win_id);
					var aCtrl = AutomationElement.FocusedElement;   // todo, parent closed exception
					thisFileName = string.Empty;

					// Notepad++
					if (aWin.Current.ClassName.ToLower() == "Notepad++".ToLower())
					{
						Match m = Regex.Match(aWin.Current.Name, @"([^*]+\.md) - Notepad\+\+");
						if (m.Success)
						{
							thisFileName = m.Groups[1].Value.Replace("*", "");
						}
						continue;
					}
					
					// VisualStudio
					if (aWin.Current.AutomationId.ToLower() == "VisualStudioMainWindow".ToLower())
					{
						var aUp = Up(aCtrl, x => Regex.Match(x.Current.AutomationId, @"\|([^*|]+\.md)\|").Success );

						if (aUp == null) continue;

						Match m = Regex.Match(aUp.Current.AutomationId, @"\|([^*|]+\.md)\|");
						if (m.Success)
						{
							thisFileName = m.Groups[1].Value.Replace("*", "");
						}
						continue;
					}

					// File Explorer
					if (aWin.Current.ClassName.Equals( "CabinetWClass", StringComparison.InvariantCultureIgnoreCase))		// win10, QTTabBar
					{
						if (aCtrl.Current.ClassName.Equals("UIItem", StringComparison.InvariantCultureIgnoreCase)
							&& aCtrl.Current.ControlType == ControlType.ListItem )
						{
                            var selectItem = (aCtrl.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern).Current;

							string name = aCtrl.Current.Name;
							if (!name.EndsWith(".md", StringComparison.InvariantCultureIgnoreCase)
								|| !selectItem.IsSelected) continue;

							var aToolbar = Dn(aWin, new List<Condition>()
							{
								new Condition(x => x.Current.ClassName, "ReBarWindow32"),
                                new Condition(x => x.Current.ClassName, "Breadcrumb Parent"),
                                new Condition(x => x.Current.ClassName, "ToolbarWindow32")
							});

							Match m = Regex.Match(aToolbar.Current.Name, @": (.+)");
							if (!m.Success) continue;

							string path = m.Groups[1].Value;
							thisFileName = Path.Combine(path, name);
							continue;
						}
					}
                }
				catch (Exception ee)
				{
					Global.myDebug(ee.Message, 0);
				}

            }
			passFileName = string.Empty;
		}

		public static AutomationElement Up(AutomationElement aSrc, Func<AutomationElement, bool> test)
		{
			var aPath = new List<AutomationElement>() { };
			TreeWalker walker = TreeWalker.RawViewWalker;

			AutomationElement aThis = aSrc,
				aNext = null;
			while (aNext != aThis)
			{
				aNext = walker.GetParent(aThis);
				if (aNext == null) break;

				aPath.Add(aNext);

				if (test(aNext))
					return aNext;

				aThis = aNext;
				aNext = null;
			}
			return null;
        }

		public static AutomationElement Dn(AutomationElement aSrc, Condition cond)
		{
			return Dn(aSrc, x => cond.Test(x));
		}

		public static AutomationElement Dn(AutomationElement aSrc, List<Condition> conds)
		{
			AutomationElement aTemp = aSrc;
			foreach (var cond in conds)
			{
				aTemp = Dn(aTemp, x => cond.Test(x));
				if (aTemp == null)
					break;
			}

			return aTemp;
		}

		public static AutomationElement Dn(AutomationElement aSrc, Func<AutomationElement, bool> test)
		{
			var aPath = new List<AutomationElement>() { };
			TreeWalker walker = TreeWalker.RawViewWalker;

			var aThis = new List<AutomationElement>() { aSrc };
			var aMatch = new List<AutomationElement>();
			// bool Found = false;

			while (true)
			{
				var aNext = new List<AutomationElement>();

				foreach (var aThis1 in aThis)
				{
					var aChild = walker.GetFirstChild(aThis1);
					while (aChild != null)
					{
						aNext.Add(aChild);
						if ( test(aChild) )
						{
							// Found = true;
							aMatch.Add(aChild);
						}
						aChild = walker.GetNextSibling(aChild);
                    }
				}

				if (aMatch.Count > 0)
					return aMatch[0];

				if (aNext.Count == 0)
					return null;

				aThis = aNext;
			}
		}
	}
}
