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
			{
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

			string html_with_css = string.Empty;

			// Convert Markdown to Html
			/* using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(this.GetType(), "markdown.css"))
			{
				myMarkdownSharp.FileToHtml(info, stream, out html_with_css);    // todo, embed resource somewhere else
			}*/

			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(this.GetType(),
				//	"gitlab-markdown.css")) 
				"github-markdown.css"))
            {
				var st = new Stopwatch();
				//myGithubAPI
				myStrikeIE.FileToHtml(info, stream, out html_with_css);    // todo, embed resource somewhere else
				st.Stop();
				Global.myDebug(string.Format("{0} ms", st.ElapsedMilliseconds));
			}

			_stat = 1;
			browser.Invoke(new Action(() =>
			{
				// browser.NavigateToString(html_with_css);		// WPF only
				browser.DocumentText = html_with_css;
			}));
			_stat = 5;
			Global.myDebug("DocumentText = html_with_css");
		}
		// *91
		private void BrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
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
        private void BrowserPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        { /*
            if (mnuFloatWindow.ShortcutKeys == e.KeyData)
                mnuFloatWindow_Click(mnuFloatWindow, EventArgs.Empty);

            else if (mnuOpenFile.ShortcutKeys == e.KeyData)
                mnuOpenFile_Click(mnuOpenFile, EventArgs.Empty);

            else if (mnuCopyHtml.ShortcutKeys == e.KeyData)
                mnuCopyHtml_Click(mnuCopyHtml, EventArgs.Empty);

            else if (mnuPrint.ShortcutKeys == e.KeyData)
                mnuPrint_Click(mnuPrint, EventArgs.Empty);

            else if (mnuExit.ShortcutKeys == e.KeyData)
                mnuExit_Click(mnuExit, EventArgs.Empty);
        */ }

		// *148
		/* private void mnuCopyHtml_Click(object sender, EventArgs e)
		{
			if (parsed_html != null)
				Clipboard.SetText(parsed_html.Trim());
		} */
	}
}
