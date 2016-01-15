using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

// using logPlot.Data;
// using logPlot.Graph;
using WeifenLuo.WinFormsUI.Docking;

namespace bZmd.DockUI
{
	public partial class MainForm : Form
	{
		/* public static string uPlotExt = ".uPlot";
		public static string uPlotExtFilter = string.Format("uPlot file (*{0})|*{0}", uPlotExt);
		List <object> dataSource = Graph.Global.dataSource; */
		// #55
		private IDockContent FindPlot(string text)
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

		private IDockContent FindDoc(FileInfo info)
		{
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				foreach (Form form in MdiChildren)
					if (form is DummyDoc && ((DummyDoc)form).FileInfo.FullName == info.FullName)
						return form as IDockContent;

				return null;
			}
			else
			{
				foreach (IDockContent content in dockPanel.Documents)
					if (content is DummyDoc && ((DummyDoc)content).FileInfo.FullName == info.FullName)
						return content;

				return null;
			}
		}
		// #75
		private DummyDoc CreateNewDoc()
		{ 
			DummyDoc DummyDoc = new DummyDoc();

			int count = 0;
			string text;
			do      // todo -- FindPlot?
			{
				count++;
				text = "Chart" + count.ToString();
			} while (FindDocument(text) != null);
			DummyDoc.Text = text;
			return DummyDoc;
		}

		// #92
		private DummyDoc CreateNewDoc(string text)
		{   // todo -- FindPlot?
			DummyDoc DummyDoc = new DummyDoc();
			DummyDoc.Text = text;
			return DummyDoc;
		}

		private DummyDoc CreateNewDoc(FileInfo info)
		{   // todo -- FindPlot?
			DummyDoc DummyDoc = new DummyDoc();
			DummyDoc.FileInfo = info;
			// DummyDoc.Text = text;
			return DummyDoc;
		}
#if DockSample1 // eucaly, 151224
#else
		private IDockContent GetContentFromPersistString(string persistString)
		{
			/*if (persistString == typeof(DummySolutionExplorer).ToString())
				return m_solutionExplorer;
			else*/	 /* if (persistString == typeof(DummyPropertyWindow).ToString())
				return m_propertyWindow; */
			/*else if (persistString == typeof(DummyToolbox).ToString())
				return m_toolbox;
			else if (persistString == typeof(DummyOutputWindow).ToString())
				return m_outputWindow;
			else if (persistString == typeof(DummyTaskList).ToString())
				return m_taskList;*/
			// else
			{
				// DummyDoc overrides GetPersistString to add extra information into persistString.
				// Any DockContent may override this value to add any needed information for deserialization.

				string[] parsedStrings = persistString.Split(new char[] { ',' });
				/* if (parsedStrings.Length != 3)
					return null; */

				if (parsedStrings[0] != typeof(DummyDoc).ToString())
					return null;

				DummyDoc DummyDoc = new DummyDoc();
				if (parsedStrings.Length > 1 &&  parsedStrings[1] != string.Empty)
					DummyDoc.FileName = parsedStrings[1];
				if (parsedStrings.Length > 2 && parsedStrings[2] != string.Empty)
					DummyDoc.Text = parsedStrings[2];

				return DummyDoc;
			}
		}
#endif
			// #343
		private void menuItemNew_Click2(object sender, System.EventArgs e)
		{
			NewDummyDoc();
		}

		private DummyDoc NewDummyDoc()
		{
			DummyDoc DummyDoc = CreateNewDoc();
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				DummyDoc.MdiParent = this;
				DummyDoc.Show();
			}
			else
				DummyDoc.Show(dockPanel);
			return DummyDoc;
		}

		private DummyDoc NewDummyDoc(FileInfo info)
		{
			var doc = FindDoc(info) as DummyDoc;
            if (doc != null)
			{
				doc.Activate();
				return doc;
			}

			DummyDoc DummyDoc = CreateNewDoc(info);
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				DummyDoc.MdiParent = this;
				DummyDoc.Show();
			}
			else
				DummyDoc.Show(dockPanel);
			return DummyDoc;
		}
		// #357
		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
		}

		private void menuItemSave_Click(object sender, EventArgs e)
		{
		}

		// #426
		private void MainForm_Load2(object sender, System.EventArgs e)
		{
			#region ==== DockSample load layout ==== 
			string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

			if (File.Exists(configFile))
				dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
			#endregion

			Assembly assem = Assembly.GetEntryAssembly();
			AssemblyName assemName = assem.GetName();
			Version ver = assemName.Version;
			

			this.Text = String.Format("{0} - {1} - ({2})", assemName.Name, ver.ToString(), Application.ProductVersion);		// Form Title
			// myScriptInfo = assemName.Name + " - " + ver.ToString();
			
			toolBar.Visible = false;
#if a151223
			var table = new DataTable();

			using (CsvReader csv = new CsvReader(
				//new StreamReader(@"D:\OneDrive\0K\(K15)\5-EE\$EE\battery-CSV\L0004_8A_0_1200.csv"), true))
				new StreamReader(@"D:\OneDrive\0K\(K15)\5-EE\$EE\battery-CSV\20151221_L0004_8A_Tool.csv"), true))
			{
				table.Load(csv);
			}

			MessageBox.Show( String.Format("Table contains {0} rows.", table.Rows.Count) );
#endif
#if auto_log_decode
			var Log = new EEPROMLOG();
			Log.DecodeFile(@"D:\Dropbox\Coding\sharp\DRT\2015-11-06_17-41-40_CA0311000001_eeprom_dump.txt",
				@"D:\Dropbox\Coding\sharp\DRT\logPlot2\logPlot\bin\Debug\EEPROM MAP\EEPROM MAP (VCU2.0) 150707 - 32bit-RTC.xls");
			dataSource.Add(Log);
#endif
#if auto_xls
			var Log = new ExcelLog();
			//Log.DecodeFile(@"D:\Dropbox\Coding\sharp\5000 pt 統達6.9AH檢查項目list@2015-1217.xls");
			//Log.DecodeFile(@"D:\Dropbox\0K\(K15)\5-EE\$EE\battery-CSV\L0004_8A_0_120.xls");
			Log.DecodeFile();
			if ( (Log.DataSet != null) && (!dataSource.Contains(Log)) )
			{
				dataSource.Add(Log);
				MessageBox.Show(String.Format("Load {0} table(s)", Log.DataSet.Tables.Count)); // from\n{1}", sFile1);
			}
#endif
			if (isRunning) return;
			isRunning = true;
			backgroundWorker1.RunWorkerAsync();
		}

		void MenuItemLoadDataFileClick(object sender, EventArgs e)
		{
		}

		private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
		{
			/* try
			{
				uGraph obj = ((DummyDoc)dockPanel.ActiveDocument).PlotControl;
				// m_propertyWindow.propertyGridSelect(obj);
				m_propertyWindow.listObjects = obj.ListedObjects();
				m_propertyWindow.listBoxPlotsSelect(0);
			}
			catch (Exception ee)
			{
			} */
		}
	}
}
