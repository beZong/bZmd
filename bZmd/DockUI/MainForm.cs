using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
// using DockSample.Customization;
// using Lextm.SharpSnmpLib;
using WeifenLuo.WinFormsUI.Docking;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;

// using DockSample;		// eucaly, 151205 

namespace bZmd.DockUI		// eucaly, 151205
{
	public partial class MainForm : Form /*: DockSample.MainForm*/
	{
		private bool m_bSaveLayout = true;
		private DeserializeDockContent m_deserializeDockContent;
#if x160113
		private DummySolutionExplorer m_solutionExplorer;
		private DummyPropertyWindow m_propertyWindow;
		private DummyToolbox m_toolbox;
		private DummyOutputWindow m_outputWindow;
		private DummyTaskList m_taskList;
		private bool _showSplash;
		private SplashScreen _splashScreen;
#endif

		private string lastHookFileName = string.Empty;

		public MainForm()
		{
			InitializeComponent();

#if DockSample1 // todo		// eucaly, 151205
			SetSplashScreen();
#endif      // eucaly, 151205
			Text = "logPLot - program loading";		// Form Title		// eucaly, 151205
			CreateStandardControls();

			showRightToLeft.Checked = (RightToLeft == RightToLeft.Yes);
			RightToLeftLayout = showRightToLeft.Checked;
			// m_solutionExplorer.RightToLeftLayout = RightToLeftLayout;
			m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
			
#if DockSample1 // todo		// eucaly, 151205
			vS2012ToolStripExtender1.DefaultRenderer = _toolStripProfessionalRenderer;
			vS2012ToolStripExtender1.VS2012Renderer = _vs2012ToolStripRenderer;
			vS2012ToolStripExtender1.VS2013Renderer = _vs2013ToolStripRenderer;
#endif      // eucaly, 151205

			this.topBar.BackColor = this.bottomBar.BackColor = Color.FromArgb(0xFF, 41, 57, 85);

			SetSchema(this.menuItemSchemaVS2013Blue, null);
		}

		private bool isRunning = false;
		private string wActive = "";

		// https://social.msdn.microsoft.com/Forums/en-US/2ee1e7ae-946f-4394-b09d-7d1021d8be23/how-to-get-the-active-windows-title?forum=csharpgeneral
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		// getwindowthreadprocessid - http://www.pinvoke.net/default.aspx/user32.getwindowthreadprocessid
		// https://pinvoke.codeplex.com/

		#region Methods

		private IDockContent FindDocument(string text)
		{
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				foreach (Form form in MdiChildren)
					if (form.Text == text)
						return form as IDockContent;

				return null;
			}
			else
			{
				foreach (IDockContent content in dockPanel.Documents)
					if (content.DockHandler.TabText == text)
						return content;

				return null;
			}
		}

		private DummyDoc CreateNewDocument()
		{
			DummyDoc dummyDoc = new DummyDoc();

			int count = 1;
			//string text = "C:\\MADFDKAJ\\ADAKFJASD\\ADFKDSAKFJASD\\ASDFKASDFJASDF\\ASDFIJADSFJ\\ASDFKDFDA" + count.ToString();
			string text = "Document" + count.ToString();
			while (FindDocument(text) != null)
			{
				count++;
				//text = "C:\\MADFDKAJ\\ADAKFJASD\\ADFKDSAKFJASD\\ASDFKASDFJASDF\\ASDFIJADSFJ\\ASDFKDFDA" + count.ToString();
				text = "Document" + count.ToString();
			}
			dummyDoc.Text = text;
			return dummyDoc;
		}

		private DummyDoc CreateNewDocument(string text)
		{
			DummyDoc dummyDoc = new DummyDoc();
			dummyDoc.Text = text;
			return dummyDoc;
		}

		private void CloseAllDocuments()
		{
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				foreach (Form form in MdiChildren)
					form.Close();
			}
			else
			{
				foreach (IDockContent document in dockPanel.DocumentsToArray())
				{
					document.DockHandler.Close();
				}
			}
		}
#if DockSample1 // eucaly, 151224
		private IDockContent GetContentFromPersistString(string persistString)
		{
			if (persistString == typeof(DummySolutionExplorer).ToString())
				return m_solutionExplorer;
			else if (persistString == typeof(DummyPropertyWindow).ToString())
				return m_propertyWindow;
			else if (persistString == typeof(DummyToolbox).ToString())
				return m_toolbox;
			else if (persistString == typeof(DummyOutputWindow).ToString())
				return m_outputWindow;
			else if (persistString == typeof(DummyTaskList).ToString())
				return m_taskList;
			else
			{
				// DummyDoc overrides GetPersistString to add extra information into persistString.
				// Any DockContent may override this value to add any needed information for deserialization.

				string[] parsedStrings = persistString.Split(new char[] { ',' });
				if (parsedStrings.Length != 3)
					return null;

				if (parsedStrings[0] != typeof(DummyDoc).ToString())
					return null;

				DummyDoc dummyDoc = new DummyDoc();
				if (parsedStrings[1] != string.Empty)
					dummyDoc.FileName = parsedStrings[1];
				if (parsedStrings[2] != string.Empty)
					dummyDoc.Text = parsedStrings[2];

				return dummyDoc;
			}
		}
#endif
		private void CloseAllContents()
		{
			// we don't want to create another instance of tool window, set DockPanel to null
			/* m_solutionExplorer.DockPanel = null;
			m_propertyWindow.DockPanel = null;
			m_toolbox.DockPanel = null;
			m_outputWindow.DockPanel = null;
			m_taskList.DockPanel = null; */

			// Close all other document windows
			CloseAllDocuments();
		}

		private readonly ToolStripRenderer _toolStripProfessionalRenderer = new ToolStripProfessionalRenderer();
#if DockSample1 // todo		// eucaly, 151205
		private readonly ToolStripRenderer _vs2012ToolStripRenderer = new VS2012ToolStripRenderer();
		private readonly ToolStripRenderer _vs2013ToolStripRenderer = new Vs2013ToolStripRenderer();
#endif      // eucaly, 151205
		
		private void SetSchema(object sender, System.EventArgs e)
		{
#if DockSample1 // todo		// eucaly, 151205
			// Persist settings when rebuilding UI
			string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");

			dockPanel.SaveAsXml(configFile);
			CloseAllContents();

			if (sender == this.menuItemSchemaVS2005)
			{
				this.dockPanel.Theme = this.vS2005Theme1;
				this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2005);
			}
			else if (sender == this.menuItemSchemaVS2003)
			{
				this.dockPanel.Theme = this.vS2003Theme1;
				this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2003);
			}
			else if (sender == this.menuItemSchemaVS2012Light)
			{
				this.dockPanel.Theme = this.vS2012LightTheme1;
				this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2012);
			}
			else if (sender == this.menuItemSchemaVS2013Blue)
			{
				this.dockPanel.Theme = this.vS2013BlueTheme1;
				this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2013);
			}

			menuItemSchemaVS2005.Checked = (sender == menuItemSchemaVS2005);
			menuItemSchemaVS2003.Checked = (sender == menuItemSchemaVS2003);
			menuItemSchemaVS2012Light.Checked = (sender == menuItemSchemaVS2012Light);
			this.menuItemSchemaVS2013Blue.Checked = (sender == this.menuItemSchemaVS2013Blue);
			this.topBar.Visible = this.bottomBar.Visible = (sender == this.menuItemSchemaVS2013Blue);

			if (File.Exists(configFile))
				dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
#endif      // eucaly, 151205
		}

#if DockSample1 // todo
		private void EnableVSRenderer(VSToolStripExtender.VsVersion version)
		{
			vS2012ToolStripExtender1.SetStyle(this.mainMenu, version);
			vS2012ToolStripExtender1.SetStyle(this.toolBar, version);
			vS2012ToolStripExtender1.SetStyle(this.statusBar, version);
	}
#endif

		private void SetDocumentStyle(object sender, System.EventArgs e)
		{
			DocumentStyle oldStyle = dockPanel.DocumentStyle;
			DocumentStyle newStyle;
			if (sender == menuItemDockingMdi)
				newStyle = DocumentStyle.DockingMdi;
			else if (sender == menuItemDockingWindow)
				newStyle = DocumentStyle.DockingWindow;
			else if (sender == menuItemDockingSdi)
				newStyle = DocumentStyle.DockingSdi;
			else
				newStyle = DocumentStyle.SystemMdi;

			if (oldStyle == newStyle)
				return;

			if (oldStyle == DocumentStyle.SystemMdi || newStyle == DocumentStyle.SystemMdi)
				CloseAllDocuments();

			dockPanel.DocumentStyle = newStyle;
			menuItemDockingMdi.Checked = (newStyle == DocumentStyle.DockingMdi);
			menuItemDockingWindow.Checked = (newStyle == DocumentStyle.DockingWindow);
			menuItemDockingSdi.Checked = (newStyle == DocumentStyle.DockingSdi);
			menuItemSystemMdi.Checked = (newStyle == DocumentStyle.SystemMdi);
			menuItemLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
			menuItemLayoutByXml.Enabled = (newStyle != DocumentStyle.SystemMdi);
			toolBarButtonLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
			toolBarButtonLayoutByXml.Enabled = (newStyle != DocumentStyle.SystemMdi);
		}

		private AutoHideStripSkin _autoHideStripSkin;
		private DockPaneStripSkin _dockPaneStripSkin;

		private void SetDockPanelSkinOptions(bool isChecked)
		{
		}

#endregion

#region Event Handlers

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		 
		private void menuItemSolutionExplorer_Click(object sender, System.EventArgs e)
		{
			// m_solutionExplorer.Show(dockPanel);
		}

		private void menuItemPropertyWindow_Click(object sender, System.EventArgs e)
		{
			// m_propertyWindow.Show(dockPanel);
		}

		private void menuItemToolbox_Click(object sender, System.EventArgs e)
		{
			// m_toolbox.Show(dockPanel);
		}

		private void menuItemOutputWindow_Click(object sender, System.EventArgs e)
		{
			// m_outputWindow.Show(dockPanel);
		}

		private void menuItemTaskList_Click(object sender, System.EventArgs e)
		{
			// m_taskList.Show(dockPanel);
		}

		private void menuItemAbout_Click(object sender, System.EventArgs e)
		{ /*
			AboutDialog aboutDialog = new AboutDialog();
			aboutDialog.ShowDialog(this); */
		}
		
		private void menuItemNew_Click(object sender, System.EventArgs e)
		{
#if DockSample      // eucaly, 151205
			DummyDoc dummyDoc = CreateNewDocument();
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				dummyDoc.MdiParent = this;
				dummyDoc.Show();
			}
			else
				dummyDoc.Show(dockPanel);
#endif
		}
#if DockSample      // 151225 LoadFromXml
		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();

			openFile.InitialDirectory = Application.ExecutablePath;
			openFile.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*";
			openFile.FilterIndex = 1;
			openFile.RestoreDirectory = true;

			if (openFile.ShowDialog() == DialogResult.OK)
			{
				string fullName = openFile.FileName;
				string fileName = Path.GetFileName(fullName);

				if (FindDocument(fileName) != null)
				{
					MessageBox.Show("The document: " + fileName + " has already opened!");
					return;
				}

				DummyDoc dummyDoc = new DummyDoc();
				dummyDoc.Text = fileName;
				if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
				{
					dummyDoc.MdiParent = this;
					dummyDoc.Show();
				}
				else
					dummyDoc.Show(dockPanel);
				try
				{
					dummyDoc.FileName = fullName;
				}
				catch (Exception exception)
				{
					dummyDoc.Close();
					MessageBox.Show(exception.Message);
				}

			}
		}
#endif
		private void menuItemFile_Popup(object sender, System.EventArgs e)
		{
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				menuItemClose.Enabled = 
					menuItemCloseAll.Enabled =
					menuItemCloseAllButThisOne.Enabled = (ActiveMdiChild != null);
			}
			else
			{
				menuItemClose.Enabled = (dockPanel.ActiveDocument != null);
				menuItemCloseAll.Enabled =
					menuItemCloseAllButThisOne.Enabled = (dockPanel.DocumentsCount > 0);
			}
		}

		private void menuItemClose_Click(object sender, System.EventArgs e)
		{
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
				ActiveMdiChild.Close();
			else if (dockPanel.ActiveDocument != null)
				dockPanel.ActiveDocument.DockHandler.Close();
		}

		private void menuItemCloseAll_Click(object sender, System.EventArgs e)
		{
			CloseAllDocuments();
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			/* string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

			if (File.Exists(configFile))
				dockPanel.LoadFromXml(configFile, m_deserializeDockContent); */

			if (isRunning) return;
			isRunning = true;
			backgroundWorker1.RunWorkerAsync();
		}

		private void active_worker()
		{
			int chars = 256;
			StringBuilder buff = new StringBuilder(chars);

			while (true)
			{
				if (!isRunning) break;
				// Obtain the handle of the active window.
				IntPtr handle = GetForegroundWindow();

				if (GetWindowText(handle, buff, chars) > 0)
				{
					// MessageBox.Show(buff.ToString());
					wActive = buff.ToString();
					backgroundWorker1.ReportProgress(10);
					//MessageBox.Show(handle.ToString());
				}
				Thread.Sleep(1000);
			}
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			active_worker();
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// statusBar.Visible = true;
			// statusBar.Text = wActive;
			if (lastHookFileName != wActive)
			{
				lastHookFileName = wActive;
				Match m = Regex.Match(lastHookFileName, @"(.+) - Notepad\+\+");
				if (m.Success)
				{
					int num = 0;
					var info = new FileInfo(m.Groups[1].Value);
					if (!info.Exists || info.Extension.ToLower() != ".md") return;
					NewDummyDoc(info);
				}
			}
			
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			isRunning = false;
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
			if (m_bSaveLayout)
				dockPanel.SaveAsXml(configFile);
			else if (File.Exists(configFile))
				File.Delete(configFile);
		}

		private void menuItemToolBar_Click(object sender, System.EventArgs e)
		{
			toolBar.Visible = menuItemToolBar.Checked = !menuItemToolBar.Checked;
		}

		private void menuItemStatusBar_Click(object sender, System.EventArgs e)
		{
			statusBar.Visible = menuItemStatusBar.Checked = !menuItemStatusBar.Checked;
		}

		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem == toolBarButtonNew)
				menuItemNew_Click(null, null);
			else if (e.ClickedItem == toolBarButtonOpen)
				menuItemOpen_Click(null, null);
			else if (e.ClickedItem == toolBarButtonSolutionExplorer)
				menuItemSolutionExplorer_Click(null, null);
			else if (e.ClickedItem == toolBarButtonPropertyWindow)
				menuItemPropertyWindow_Click(null, null);
			else if (e.ClickedItem == toolBarButtonToolbox)
				menuItemToolbox_Click(null, null);
			else if (e.ClickedItem == toolBarButtonOutputWindow)
				menuItemOutputWindow_Click(null, null);
			else if (e.ClickedItem == toolBarButtonTaskList)
				menuItemTaskList_Click(null, null);
			else if (e.ClickedItem == toolBarButtonLayoutByCode)
				menuItemLayoutByCode_Click(null, null);
			else if (e.ClickedItem == toolBarButtonLayoutByXml)
				menuItemLayoutByXml_Click(null, null);
			else if (e.ClickedItem == toolBarButtonDockPanelSkinDemo)
				SetDockPanelSkinOptions(!toolBarButtonDockPanelSkinDemo.Checked);
		}

		private void menuItemNewWindow_Click(object sender, System.EventArgs e)
		{
			MainForm newWindow = new MainForm();
			newWindow.Text = newWindow.Text + " - New";
			newWindow.Show();
		}

		private void menuItemTools_Popup(object sender, System.EventArgs e)
		{
			menuItemLockLayout.Checked = !this.dockPanel.AllowEndUserDocking;
		}

		private void menuItemLockLayout_Click(object sender, System.EventArgs e)
		{
			dockPanel.AllowEndUserDocking = !dockPanel.AllowEndUserDocking;
		}

		private void menuItemLayoutByCode_Click(object sender, System.EventArgs e)
		{
		}

		private void SetSplashScreen()
		{
		}

		private void ResizeSplash()
		{
		}

		private void CreateStandardControls()
		{ /*
			m_solutionExplorer = new DummySolutionExplorer();
			m_propertyWindow = new DummyPropertyWindow();
			m_toolbox = new DummyToolbox();
			m_outputWindow = new DummyOutputWindow();
			m_taskList = new DummyTaskList(); */
		}

		private void menuItemLayoutByXml_Click(object sender, System.EventArgs e)
		{
			dockPanel.SuspendLayout(true);

			// In order to load layout from XML, we need to close all the DockContents
			CloseAllContents();

			CreateStandardControls();

			Assembly assembly = Assembly.GetAssembly(typeof(MainForm));
			Stream xmlStream = assembly.GetManifestResourceStream("DockSample.Resources.DockPanel.xml");
			dockPanel.LoadFromXml(xmlStream, m_deserializeDockContent);
			xmlStream.Close();

			dockPanel.ResumeLayout(true, true);
		}

		private void menuItemCloseAllButThisOne_Click(object sender, System.EventArgs e)
		{
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				Form activeMdi = ActiveMdiChild;
				foreach (Form form in MdiChildren)
				{
					if (form != activeMdi)
						form.Close();
				}
			}
			else
			{
				foreach (IDockContent document in dockPanel.DocumentsToArray())
				{
					if (!document.DockHandler.IsActivated)
						document.DockHandler.Close();
				}
			}
		}

		private void menuItemShowDocumentIcon_Click(object sender, System.EventArgs e)
		{
			dockPanel.ShowDocumentIcon = menuItemShowDocumentIcon.Checked = !menuItemShowDocumentIcon.Checked;
		}

		private void showRightToLeft_Click(object sender, EventArgs e)
		{
		}

		private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
		{
			m_bSaveLayout = false;
			Close();
			m_bSaveLayout = true;
		}

#endregion

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			ResizeSplash();
		}
	}
}