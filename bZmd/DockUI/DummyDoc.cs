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
			// MarkdownWin *21
			browser.DocumentCompleted += browser_DocumentCompleted;
			// browser.PreviewKeyDown += browser_PreviewKeyDown;
			browser.AllowWebBrowserDrop = false;
			// browser.IsWebBrowserContextMenuEnabled = false;		// ContextMenu Enabled
			//browser.WebBrowserShortcutsEnabled = false;			// Shortcuts Enabled
			//browser.AllowNavigation = false;
			browser.ScriptErrorsSuppressed = true;

			browser.StatusTextChanged += browser_StatusTextChange; // new DWebBrowserEvents2_StatusTextChangeEventHandler(AxWebBrowser_StatusTextChange)

			_fileWatcher = new FileSystemWatcher();		// need assign in Class constructor
			_fileWatcher.NotifyFilter = NotifyFilters.Size |  NotifyFilters.LastWrite;
			_fileWatcher.Changed += new FileSystemEventHandler(OnWatchedFileChanged);
			bgRefreshWorker.RunWorkerAsync();

			this.Disposed += new EventHandler(Watcher_Disposed);
			browser.AllowWebBrowserDrop = false;

			#endregion
		}

		private FileInfo m_fileInfo = null;
		private string m_Url = string.Empty;
		private string _html = string.Empty;
		private string _html_with_css = string.Empty;

		// private string m_fileName = string.Empty;
		public string FileName
        {
            get	{	return m_fileInfo.FullName;	}
            set
            {
                if (value != string.Empty)
                {
					m_fileInfo = new FileInfo(value);
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

		private void menuItemExportHTML_Click(object sender, EventArgs e)
		{
			Global.myDebug("ExportHTML");

			SaveFileDialog SaveDlg = new SaveFileDialog();
			SaveDlg.Title = "Export HTML";
			SaveDlg.Filter = "html file (*.html;*.htm)|*.html;*.htm";
			SaveDlg.DefaultExt = "htm";
			SaveDlg.InitialDirectory = m_fileInfo.DirectoryName;
			// SaveDlg.FileName = Path.Combine(m_fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(m_fileInfo.Name) + DateTime.Now.ToString("-yyMMdd-HHmmss") + ".htm");
			SaveDlg.FileName = Path.GetFileNameWithoutExtension(m_fileInfo.Name) + DateTime.Now.ToString("-yyMMdd-HHmmss") + ".htm";

			if (SaveDlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(SaveDlg.FileName, _html);
				// MainTextBox.SaveFile(SaveDlg.FileName, RichTextBoxStreamType.PlainText);

		}

		private void menuItemExportHTMLwithCSS_Click(object sender, EventArgs e)
		{
			Global.myDebug("ExportHTML with CSS");

			SaveFileDialog SaveDlg = new SaveFileDialog();
			SaveDlg.Title = "Export HTML with CSS";
			SaveDlg.Filter = "html file (*.html;*.htm)|*.html;*.htm";
			SaveDlg.DefaultExt = "htm";
			SaveDlg.InitialDirectory = m_fileInfo.DirectoryName;
			// SaveDlg.FileName = Path.Combine(m_fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(m_fileInfo.Name) + DateTime.Now.ToString("-yyMMdd-HHmmss") + ".htm");
			SaveDlg.FileName = Path.GetFileNameWithoutExtension(m_fileInfo.Name) + DateTime.Now.ToString("-yyMMdd-HHmmss") + ".htm";

			if (SaveDlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(SaveDlg.FileName, _html_with_css);
		}

		private void menuItem_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}