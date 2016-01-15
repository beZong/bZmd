using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace bZmd.DockUI
{
    public partial class DummyDoc : DockContent
    {
        public DummyDoc()
        {
            InitializeComponent();

			browser.DocumentCompleted += BrowserDocumentCompleted;
			// browser.PreviewKeyDown += BrowserPreviewKeyDown;
			browser.AllowWebBrowserDrop = false;
			browser.IsWebBrowserContextMenuEnabled = false;
			browser.WebBrowserShortcutsEnabled = false;
			//browser.AllowNavigation = false;
			browser.ScriptErrorsSuppressed = true;

			// _markdown = new Markdown();
			_fileWatcher = new FileSystemWatcher();
			_fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
			_fileWatcher.Changed += new FileSystemEventHandler(OnWatchedFileChanged);

			this.Disposed += new EventHandler(Watcher_Disposed);
			browser.AllowWebBrowserDrop = false;
		}

/*		public DummyDoc(FileInfo info)
		{
			InitializeComponent();
		}*/

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

		private FileInfo m_fileInfo = null;
		public FileInfo FileInfo
		{
			get { return m_fileInfo; }
			set
			{
				m_fileInfo = value;
                if (m_fileInfo != null)
				{
					// MarkdownWin *129
					RefreshPreview(m_fileInfo);

					_fileWatcher.Path = m_fileInfo.DirectoryName;
					_fileWatcher.Filter = m_fileInfo.Name;
					_fileWatcher.EnableRaisingEvents = true;
					/*
					Stream s = new FileStream(value, FileMode.Open);

					FileInfo efInfo = new FileInfo(value);

					string fext = efInfo.Extension.ToUpper();

					if (fext.Equals(".RTF"))
						richTextBox1.LoadFile(s, RichTextBoxStreamType.RichText);
					else
						richTextBox1.LoadFile(s, RichTextBoxStreamType.PlainText);
					s.Close(); */
				}

				m_fileInfo = value;
				this.ToolTipText = (m_fileInfo == null) ? "" : m_fileInfo.FullName; 
			}
		}

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
	}
}