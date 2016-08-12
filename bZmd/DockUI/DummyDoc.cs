using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace bZmd.DockUI
{
	public partial class DummyDoc : DockContent
    {
        public DummyDoc()
        {
            InitializeComponent();

			Global.myDebug("after InitializeComponent()");

			#region MarkdownWin

			browser.DocumentCompleted += BrowserDocumentCompleted;
			browser.PreviewKeyDown += BrowserPreviewKeyDown;
			browser.AllowWebBrowserDrop = false;
			browser.IsWebBrowserContextMenuEnabled = false;
			browser.WebBrowserShortcutsEnabled = false;
			//browser.AllowNavigation = false;
			browser.ScriptErrorsSuppressed = true;

			browser.StatusTextChanged += Browser_StatusTextChange; // new DWebBrowserEvents2_StatusTextChangeEventHandler(AxWebBrowser_StatusTextChange)

			_fileWatcher = new FileSystemWatcher();
			_fileWatcher.NotifyFilter = NotifyFilters.Size |  NotifyFilters.LastWrite;
			_fileWatcher.Changed += new FileSystemEventHandler(OnWatchedFileChanged);
			bgRefreshWorker.RunWorkerAsync();

			this.Disposed += new EventHandler(Watcher_Disposed);
			browser.AllowWebBrowserDrop = false;

#endregion
		}

		private FileInfo m_fileInfo = null;
		private string m_Url = string.Empty;

		// private string m_fileName = string.Empty;
		public string FileName
        {
            get	{	return m_fileInfo.FullName;	}
            set
            {
                if (value != string.Empty)
                {
					m_fileInfo = new FileInfo(value);
					/*   Stream s = new FileStream(value, FileMode.Open);

					   FileInfo efInfo = new FileInfo(value);

					   string fext = efInfo.Extension.ToUpper();

					   if (fext.Equals(".RTF"))
						   richTextBox1.LoadFile(s, RichTextBoxStreamType.RichText);
					   else
						   richTextBox1.LoadFile(s, RichTextBoxStreamType.PlainText);
					   s.Close();*/
				}

				this.ToolTipText = value;	// todo
            }
        }

		public FileInfo FileInfo
		{
			get { return m_fileInfo; }
			set
			{
				m_fileInfo = value;
                if (m_fileInfo != null)
				{
					// MarkdownWin *129
					addressBar.Text = m_fileInfo.FullName;
					addressBar.ReadOnly = true;
					browser.Focus();        // todo, browser.Focus()

					_stat = 10;
					PendingPreview(m_fileInfo);
					_stat = 11;
					_fileWatcher.Path = m_fileInfo.DirectoryName;
					_stat = 12;
					_fileWatcher.Filter = m_fileInfo.Name;
					_stat = 13;
					_fileWatcher.EnableRaisingEvents = true;
					_stat = 14;
				}

				m_fileInfo = value;
				this.ToolTipText = (m_fileInfo == null) ? "" : m_fileInfo.FullName; 
			}
		}
		/*
		// workaround of RichTextbox control's bug:
		// If load file before the control showed, all the text format will be lost
		// re-load the file after it get showed.
		private bool m_resetText = true;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_resetText)
            {
                m_resetText = false;
                FileName = FileName;
            }
        }
		*/
        protected override string GetPersistString()
        {
            // Add extra information into the persist string for this document
            // so that it is available when deserialized.
            return GetType().ToString() + "," + FileName + "," + Text;
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This is to demostrate menu item has been successfully merged into the main form. Form Text=" + Text);
        }

        private void menuItemCheckTest_Click(object sender, System.EventArgs e)
        {
            menuItemCheckTest.Checked = !menuItemCheckTest.Checked;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            /* base.OnTextChanged (e);
            if (FileName == string.Empty)
                this.richTextBox1.Text = Text; */
        }

		private void DummyDoc_Activated(object sender, EventArgs e)
		{
			// PendingPreview(m_fileInfo);
		}

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

			if (url == m_Url || url.IndexOf("navcancl.htm", StringComparison.InvariantCultureIgnoreCase) >=0 ) // url.EndsWith
				return;

			if (url.StartsWith("http://") || url.StartsWith("https://"))
			{
				// Web link in default browser
				System.Diagnostics.Process.Start(url);

				/* using (Process exeProcess = Process.Start(url))
				{
					exeProcess.WaitForExit();
				} */

				e.Cancel = true;
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

		private void Browser_StatusTextChange(object sender, EventArgs e)
		{
			statusMessage.Text = ((WebBrowser)sender).StatusText.Replace("about:", "");
		}
	}
}