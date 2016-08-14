// using mshtml;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using bZmd.myMarkdown;
using mshtml;

namespace bZmd.DockUI
{
	public partial class DummyDoc : DockContent
	{
		// private string parsed_html;
		bool _Refreshed = true;
		int _stat = -1;		// todo, for debug
        Stopwatch _PreviewDelay = new Stopwatch();
        Point _scrollpos = new Point(0, 0);
		// private int _browserScrollTop;

		private readonly FileSystemWatcher _fileWatcher;    // todo, file watcher to class lib

		// *38
		private void Watcher_Disposed(object sender, EventArgs e)
		{
			_fileWatcher.Dispose();
		}
		// *56
		private void OnWatchedFileChanged(object sender, FileSystemEventArgs e)
        {
            PendingPreview(m_fileInfo /*e.FullPath*/);
        }

		private void PendingPreview(FileInfo info)      // todo, info.FullName != e.FullPath
		{
			_PreviewDelay.Restart();
			_Refreshed = false;
			Global.myDebug("PendingPreview " + info.FullName);
        }

		private void bgRefreshWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			while (true)
			{
				// Exit if no valid _fileWatcher, because form is closed
				if (_fileWatcher == null) break;
				
				if (!_Refreshed										// if need Refresh
					// && this.IsActivated								// if Form Activate 
					&& m_fileInfo.FullName == Global.ActiveDocumentFullName
                    && _PreviewDelay.ElapsedMilliseconds > 500)    // if delayed
				{
					_Refreshed = true;
					RefreshPreview();
                }
				else
				{
					/* if (_PreviewDelay.ElapsedMilliseconds > 500)
						Global.myDebug((!_Refreshed ? "Not" : "") + " Refreshed / " */
                }
				Thread.Sleep(100);
			}
		}

		// *73
		private void RefreshPreview(/*FileInfo info*/)
		{
			FileInfo info = m_fileInfo;

            try
			{   // remember scroll position
				browser.Invoke(new Action(() => {
					HtmlDocument doc = null;
					doc = browser.Document;
					if (doc == null || doc.Body == null)
					{
						_scrollpos = new Point(0, 0);
					}
					else
					{
						_scrollpos = new Point(doc.Body.ScrollLeft, doc.Body.ScrollTop);
                    }
				}));
			}
			catch (Exception ee)
			{
				_scrollpos = new Point(0, 0);
			}

			// Convert Markdown to Html
			using (var cssFile = Assembly.GetExecutingAssembly().GetManifestResourceStream(this.GetType(),
				//	"gitlab-markdown.css")) 
				"github-markdown.css"))
			{
				var parserStopWatch = new Stopwatch();
				// myGithubAPI
				var engine = new myStrikeIE();
				// var engine = new myGithubAPI();
				engine.FileToHtml(info, cssFile, out _html_with_css, out _html);    // todo, embed resource somewhere else
				parserStopWatch.Stop();
				Global.myDebug(string.Format("{0} ms", parserStopWatch.ElapsedMilliseconds));
				Global.myDebug("WebBrowser version: " + browser.Version);
            }

			_stat = 1;
			browser.Invoke(new Action(() =>
			{
				// browser.NavigateToString(html_with_css);		// WPF only
				browser.DocumentText = _html_with_css;
			}));
			_stat = 5;
			Global.myDebug("DocumentText = html_with_css");
		}
		// *91
		private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (browser.Document != null)
			{
				if (browser.Document != null)
				{
					Global.myDebug("scroll to " + _scrollpos.Y);
					browser.Document.Body.ScrollTop = _scrollpos.Y;
                }
				Global.myDebug("Restore preview scroll position");
			}
		}
		// *111
        private void browser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
		}

		// *148
		/* private void mnuCopyHtml_Click(object sender, EventArgs e)
		{
			if (parsed_html != null)
				Clipboard.SetText(parsed_html.Trim());
		} */

		private void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			string url = e.Url.ToString();
			Global.myDebug(_stat + " url = " + url);

			if (url == "about:blank")
			{
				/* m_Url = "file:///" + m_fileInfo.FullName.Replace('\\', '/'); // + "/";
				e.Cancel = true;
				browser.Navigate(m_Url); */
				return;
			}

			if (url == m_Url || url.IndexOf("navcancl.htm", StringComparison.InvariantCultureIgnoreCase) >= 0)      // url.EndsWith
				return;

			if (url.StartsWith("http://") || url.StartsWith("https://"))
			{
				// browser.Navigate(e.Url);
#if debug
				// Web link in default browser
				System.Diagnostics.Process.Start(url);

				/* using (Process exeProcess = Process.Start(url))
				{
					exeProcess.WaitForExit();
				} */

				e.Cancel = true;
#endif
				return;
			}

			if (url.StartsWith("about:") || url.StartsWith("file:"))
			{
				// File link in another tab
				string target = Path.Combine(m_fileInfo.DirectoryName, url.Replace("about:", ""));
				Global.toNavi = target;
				e.Cancel = true;
			}
		}

		private void browser_StatusTextChange(object sender, EventArgs e)
		{
			statusMessage.Text = ((WebBrowser)sender).StatusText.Replace("about:", "");
		}

	}
}
