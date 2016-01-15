using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace bZmd.DockUI
{
	public partial class DummyDoc : DockContent
	{
		private string _pendingPreviewHtml;
		// private readonly Markdown _markdown;
		private readonly FileSystemWatcher _fileWatcher;

		// *38
		private void Watcher_Disposed(object sender, EventArgs e)
		{
			_fileWatcher.Dispose();
		}
		// *56
		private void OnWatchedFileChanged(object sender, FileSystemEventArgs e)
        {
            RefreshPreview(m_fileInfo /*e.FullPath*/);
        }
		// *73
		private void RefreshPreview(FileInfo info)
		{
			browser.Stop();

			string text;
			using (var stream = new FileStream(info.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var reader = new StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}

			// _pendingPreviewHtml = _markdown.Transform(text);
			_pendingPreviewHtml = CommonMark.CommonMarkConverter.Convert(text);

			//browser.AllowNavigation = true;
			browser.Navigate("about:blank");
			//browser.AllowNavigation = false;
		}
		// *91
		private void BrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			const string htmlTemplate = "<html><head><style type=\"text/css\">{0}</style></head><body>{1}</body></html>";

			if (browser.Document != null)
			{
				string stylesheet;
				using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(this.GetType(), "markdown.css"))
				using (var reader = new StreamReader(stream))
				{
					stylesheet = reader.ReadToEnd();
				}

				string html = string.Format(htmlTemplate, stylesheet, _pendingPreviewHtml);
				browser.Document.Write(html);

				Debug.WriteLine("Document Completed and written to.");
			}
		}
		// *148
		/* private void mnuCopyHtml_Click(object sender, EventArgs e)
		{
			if (_pendingPreviewHtml != null)
				Clipboard.SetText(_pendingPreviewHtml.Trim());
		} */
	}
}
