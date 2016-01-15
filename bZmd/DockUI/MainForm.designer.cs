namespace bZmd.DockUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemLoadDataFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemCloseAll = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemCloseAllButThisOne = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.exitWithoutSavingLayout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSolutionExplorer = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemPropertyWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemToolbox = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemOutputWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTaskList = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemToolBar = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemStatusBar = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemLockLayout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemShowDocumentIcon = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemDockingMdi = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemDockingSdi = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemDockingWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSystemMdi = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemNewWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemLayoutByCode = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemLayoutByXml = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemSchemaVS2013Blue = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSchemaVS2012Light = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSchemaVS2005 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSchemaVS2003 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.showRightToLeft = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolBar = new System.Windows.Forms.ToolStrip();
			this.toolBarButtonNew = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonOpen = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolBarButtonSolutionExplorer = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonPropertyWindow = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonToolbox = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonOutputWindow = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonTaskList = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolBarButtonLayoutByCode = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonLayoutByXml = new System.Windows.Forms.ToolStripButton();
			this.toolBarButtonDockPanelSkinDemo = new System.Windows.Forms.ToolStripButton();
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.topBar = new System.Windows.Forms.Panel();
			this.bottomBar = new System.Windows.Forms.Panel();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.mainMenu.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.toolBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemTools,
            this.menuItemWindow,
            this.menuItemHelp});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.MdiWindowListItem = this.menuItemWindow;
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(579, 24);
			this.mainMenu.TabIndex = 7;
			// 
			// menuItemFile
			// 
			this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLoadDataFile,
            this.toolStripSeparator1,
            this.menuItemNew,
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemClose,
            this.menuItemCloseAll,
            this.menuItemCloseAllButThisOne,
            this.menuItem4,
            this.menuItemExit,
            this.exitWithoutSavingLayout});
			this.menuItemFile.Name = "menuItemFile";
			this.menuItemFile.Size = new System.Drawing.Size(49, 20);
			this.menuItemFile.Text = "C&hart";
			this.menuItemFile.DropDownOpening += new System.EventHandler(this.menuItemFile_Popup);
			// 
			// menuItemLoadDataFile
			// 
			this.menuItemLoadDataFile.Name = "menuItemLoadDataFile";
			this.menuItemLoadDataFile.Size = new System.Drawing.Size(224, 22);
			this.menuItemLoadDataFile.Text = "&Load Data File";
			this.menuItemLoadDataFile.Click += new System.EventHandler(this.MenuItemLoadDataFileClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
			// 
			// menuItemNew
			// 
			this.menuItemNew.Name = "menuItemNew";
			this.menuItemNew.Size = new System.Drawing.Size(224, 22);
			this.menuItemNew.Text = "&New Chart";
			this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click2);
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Name = "menuItemOpen";
			this.menuItemOpen.Size = new System.Drawing.Size(224, 22);
			this.menuItemOpen.Text = "&Open Chart ...";
			this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
			// 
			// menuItemSave
			// 
			this.menuItemSave.Name = "menuItemSave";
			this.menuItemSave.Size = new System.Drawing.Size(224, 22);
			this.menuItemSave.Text = "&Save Chart ...";
			this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
			// 
			// menuItemClose
			// 
			this.menuItemClose.Name = "menuItemClose";
			this.menuItemClose.Size = new System.Drawing.Size(224, 22);
			this.menuItemClose.Text = "&Close";
			this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
			// 
			// menuItemCloseAll
			// 
			this.menuItemCloseAll.Name = "menuItemCloseAll";
			this.menuItemCloseAll.Size = new System.Drawing.Size(224, 22);
			this.menuItemCloseAll.Text = "Close &All";
			this.menuItemCloseAll.Click += new System.EventHandler(this.menuItemCloseAll_Click);
			// 
			// menuItemCloseAllButThisOne
			// 
			this.menuItemCloseAllButThisOne.Name = "menuItemCloseAllButThisOne";
			this.menuItemCloseAllButThisOne.Size = new System.Drawing.Size(224, 22);
			this.menuItemCloseAllButThisOne.Text = "Close All &But This One";
			this.menuItemCloseAllButThisOne.Click += new System.EventHandler(this.menuItemCloseAllButThisOne_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Name = "menuItem4";
			this.menuItem4.Size = new System.Drawing.Size(221, 6);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new System.Drawing.Size(224, 22);
			this.menuItemExit.Text = "&Exit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// exitWithoutSavingLayout
			// 
			this.exitWithoutSavingLayout.Name = "exitWithoutSavingLayout";
			this.exitWithoutSavingLayout.Size = new System.Drawing.Size(224, 22);
			this.exitWithoutSavingLayout.Text = "Exit &Without Saving Layout";
			this.exitWithoutSavingLayout.Click += new System.EventHandler(this.exitWithoutSavingLayout_Click);
			// 
			// menuItemView
			// 
			this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSolutionExplorer,
            this.menuItemPropertyWindow,
            this.menuItemToolbox,
            this.menuItemOutputWindow,
            this.menuItemTaskList,
            this.menuItem1,
            this.menuItemToolBar,
            this.menuItemStatusBar,
            this.menuItem2});
			this.menuItemView.MergeIndex = 1;
			this.menuItemView.Name = "menuItemView";
			this.menuItemView.Size = new System.Drawing.Size(46, 20);
			this.menuItemView.Text = "&View";
			// 
			// menuItemSolutionExplorer
			// 
			this.menuItemSolutionExplorer.Name = "menuItemSolutionExplorer";
			this.menuItemSolutionExplorer.Size = new System.Drawing.Size(192, 22);
			this.menuItemSolutionExplorer.Text = "&Solution Explorer";
			this.menuItemSolutionExplorer.Click += new System.EventHandler(this.menuItemSolutionExplorer_Click);
			// 
			// menuItemPropertyWindow
			// 
			this.menuItemPropertyWindow.Name = "menuItemPropertyWindow";
			this.menuItemPropertyWindow.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.menuItemPropertyWindow.Size = new System.Drawing.Size(192, 22);
			this.menuItemPropertyWindow.Text = "&Property Window";
			this.menuItemPropertyWindow.Click += new System.EventHandler(this.menuItemPropertyWindow_Click);
			// 
			// menuItemToolbox
			// 
			this.menuItemToolbox.Name = "menuItemToolbox";
			this.menuItemToolbox.Size = new System.Drawing.Size(192, 22);
			this.menuItemToolbox.Text = "&Toolbox";
			this.menuItemToolbox.Click += new System.EventHandler(this.menuItemToolbox_Click);
			// 
			// menuItemOutputWindow
			// 
			this.menuItemOutputWindow.Name = "menuItemOutputWindow";
			this.menuItemOutputWindow.Size = new System.Drawing.Size(192, 22);
			this.menuItemOutputWindow.Text = "&Output Window";
			this.menuItemOutputWindow.Click += new System.EventHandler(this.menuItemOutputWindow_Click);
			// 
			// menuItemTaskList
			// 
			this.menuItemTaskList.Name = "menuItemTaskList";
			this.menuItemTaskList.Size = new System.Drawing.Size(192, 22);
			this.menuItemTaskList.Text = "Task &List";
			this.menuItemTaskList.Click += new System.EventHandler(this.menuItemTaskList_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Name = "menuItem1";
			this.menuItem1.Size = new System.Drawing.Size(189, 6);
			// 
			// menuItemToolBar
			// 
			this.menuItemToolBar.Checked = true;
			this.menuItemToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItemToolBar.Name = "menuItemToolBar";
			this.menuItemToolBar.Size = new System.Drawing.Size(192, 22);
			this.menuItemToolBar.Text = "Tool &Bar";
			this.menuItemToolBar.Click += new System.EventHandler(this.menuItemToolBar_Click);
			// 
			// menuItemStatusBar
			// 
			this.menuItemStatusBar.Checked = true;
			this.menuItemStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItemStatusBar.Name = "menuItemStatusBar";
			this.menuItemStatusBar.Size = new System.Drawing.Size(192, 22);
			this.menuItemStatusBar.Text = "Status B&ar";
			this.menuItemStatusBar.Click += new System.EventHandler(this.menuItemStatusBar_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Name = "menuItem2";
			this.menuItem2.Size = new System.Drawing.Size(189, 6);
			// 
			// menuItemTools
			// 
			this.menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLockLayout,
            this.menuItemShowDocumentIcon,
            this.menuItem6,
            this.menuItemDockingMdi,
            this.menuItemDockingSdi,
            this.menuItemDockingWindow,
            this.menuItemSystemMdi});
			this.menuItemTools.MergeIndex = 2;
			this.menuItemTools.Name = "menuItemTools";
			this.menuItemTools.Size = new System.Drawing.Size(50, 20);
			this.menuItemTools.Text = "&Tools";
			this.menuItemTools.DropDownOpening += new System.EventHandler(this.menuItemTools_Popup);
			// 
			// menuItemLockLayout
			// 
			this.menuItemLockLayout.Name = "menuItemLockLayout";
			this.menuItemLockLayout.Size = new System.Drawing.Size(266, 22);
			this.menuItemLockLayout.Text = "&Lock Layout";
			this.menuItemLockLayout.Click += new System.EventHandler(this.menuItemLockLayout_Click);
			// 
			// menuItemShowDocumentIcon
			// 
			this.menuItemShowDocumentIcon.Name = "menuItemShowDocumentIcon";
			this.menuItemShowDocumentIcon.Size = new System.Drawing.Size(266, 22);
			this.menuItemShowDocumentIcon.Text = "&Show Document Icon";
			this.menuItemShowDocumentIcon.Click += new System.EventHandler(this.menuItemShowDocumentIcon_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Name = "menuItem6";
			this.menuItem6.Size = new System.Drawing.Size(263, 6);
			// 
			// menuItemDockingMdi
			// 
			this.menuItemDockingMdi.Checked = true;
			this.menuItemDockingMdi.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItemDockingMdi.Name = "menuItemDockingMdi";
			this.menuItemDockingMdi.Size = new System.Drawing.Size(266, 22);
			this.menuItemDockingMdi.Text = "Document Style: Docking &MDI";
			this.menuItemDockingMdi.Click += new System.EventHandler(this.SetDocumentStyle);
			// 
			// menuItemDockingSdi
			// 
			this.menuItemDockingSdi.Name = "menuItemDockingSdi";
			this.menuItemDockingSdi.Size = new System.Drawing.Size(266, 22);
			this.menuItemDockingSdi.Text = "Document Style: Docking &SDI";
			this.menuItemDockingSdi.Click += new System.EventHandler(this.SetDocumentStyle);
			// 
			// menuItemDockingWindow
			// 
			this.menuItemDockingWindow.Name = "menuItemDockingWindow";
			this.menuItemDockingWindow.Size = new System.Drawing.Size(266, 22);
			this.menuItemDockingWindow.Text = "Document Style: Docking &Window";
			this.menuItemDockingWindow.Click += new System.EventHandler(this.SetDocumentStyle);
			// 
			// menuItemSystemMdi
			// 
			this.menuItemSystemMdi.Name = "menuItemSystemMdi";
			this.menuItemSystemMdi.Size = new System.Drawing.Size(266, 22);
			this.menuItemSystemMdi.Text = "Document Style: S&ystem MDI";
			this.menuItemSystemMdi.Click += new System.EventHandler(this.SetDocumentStyle);
			// 
			// menuItemWindow
			// 
			this.menuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewWindow});
			this.menuItemWindow.MergeIndex = 2;
			this.menuItemWindow.Name = "menuItemWindow";
			this.menuItemWindow.Size = new System.Drawing.Size(66, 20);
			this.menuItemWindow.Text = "&Window";
			// 
			// menuItemNewWindow
			// 
			this.menuItemNewWindow.Name = "menuItemNewWindow";
			this.menuItemNewWindow.Size = new System.Drawing.Size(150, 22);
			this.menuItemNewWindow.Text = "&New Window";
			this.menuItemNewWindow.Click += new System.EventHandler(this.menuItemNewWindow_Click);
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
			this.menuItemHelp.MergeIndex = 3;
			this.menuItemHelp.Name = "menuItemHelp";
			this.menuItemHelp.Size = new System.Drawing.Size(46, 20);
			this.menuItemHelp.Text = "&Help";
			// 
			// menuItemAbout
			// 
			this.menuItemAbout.Name = "menuItemAbout";
			this.menuItemAbout.Size = new System.Drawing.Size(193, 22);
			this.menuItemAbout.Text = "&About DockSample...";
			this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
			// 
			// menuItemLayoutByCode
			// 
			this.menuItemLayoutByCode.Name = "menuItemLayoutByCode";
			this.menuItemLayoutByCode.Size = new System.Drawing.Size(192, 22);
			this.menuItemLayoutByCode.Text = "Layout By &Code";
			this.menuItemLayoutByCode.Click += new System.EventHandler(this.menuItemLayoutByCode_Click);
			// 
			// menuItemLayoutByXml
			// 
			this.menuItemLayoutByXml.Name = "menuItemLayoutByXml";
			this.menuItemLayoutByXml.Size = new System.Drawing.Size(192, 22);
			this.menuItemLayoutByXml.Text = "Layout By &XML";
			this.menuItemLayoutByXml.Click += new System.EventHandler(this.menuItemLayoutByXml_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Name = "menuItem3";
			this.menuItem3.Size = new System.Drawing.Size(263, 6);
			// 
			// menuItemSchemaVS2013Blue
			// 
			this.menuItemSchemaVS2013Blue.Name = "menuItemSchemaVS2013Blue";
			this.menuItemSchemaVS2013Blue.Size = new System.Drawing.Size(266, 22);
			this.menuItemSchemaVS2013Blue.Text = "Schema: VS2013 Light";
			this.menuItemSchemaVS2013Blue.Click += new System.EventHandler(this.SetSchema);
			// 
			// menuItemSchemaVS2012Light
			// 
			this.menuItemSchemaVS2012Light.Name = "menuItemSchemaVS2012Light";
			this.menuItemSchemaVS2012Light.Size = new System.Drawing.Size(266, 22);
			this.menuItemSchemaVS2012Light.Text = "Schema: VS2012 Light";
			this.menuItemSchemaVS2012Light.Click += new System.EventHandler(this.SetSchema);
			// 
			// menuItemSchemaVS2005
			// 
			this.menuItemSchemaVS2005.Checked = true;
			this.menuItemSchemaVS2005.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItemSchemaVS2005.Name = "menuItemSchemaVS2005";
			this.menuItemSchemaVS2005.Size = new System.Drawing.Size(266, 22);
			this.menuItemSchemaVS2005.Text = "Schema: VS200&5";
			this.menuItemSchemaVS2005.Click += new System.EventHandler(this.SetSchema);
			// 
			// menuItemSchemaVS2003
			// 
			this.menuItemSchemaVS2003.Name = "menuItemSchemaVS2003";
			this.menuItemSchemaVS2003.Size = new System.Drawing.Size(266, 22);
			this.menuItemSchemaVS2003.Text = "Schema: VS200&3";
			this.menuItemSchemaVS2003.Click += new System.EventHandler(this.SetSchema);
			// 
			// menuItem5
			// 
			this.menuItem5.Name = "menuItem5";
			this.menuItem5.Size = new System.Drawing.Size(263, 6);
			// 
			// showRightToLeft
			// 
			this.showRightToLeft.Name = "showRightToLeft";
			this.showRightToLeft.Size = new System.Drawing.Size(266, 22);
			this.showRightToLeft.Text = "Show &Right-To-Left";
			this.showRightToLeft.Click += new System.EventHandler(this.showRightToLeft_Click);
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
			this.statusBar.Location = new System.Drawing.Point(0, 387);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(579, 22);
			this.statusBar.TabIndex = 4;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "");
			this.imageList.Images.SetKeyName(1, "");
			this.imageList.Images.SetKeyName(2, "");
			this.imageList.Images.SetKeyName(3, "");
			this.imageList.Images.SetKeyName(4, "");
			this.imageList.Images.SetKeyName(5, "");
			this.imageList.Images.SetKeyName(6, "");
			this.imageList.Images.SetKeyName(7, "");
			this.imageList.Images.SetKeyName(8, "");
			// 
			// toolBar
			// 
			this.toolBar.ImageList = this.imageList;
			this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarButtonNew,
            this.toolBarButtonOpen,
            this.toolBarButtonSeparator1,
            this.toolBarButtonSolutionExplorer,
            this.toolBarButtonPropertyWindow,
            this.toolBarButtonToolbox,
            this.toolBarButtonOutputWindow,
            this.toolBarButtonTaskList,
            this.toolBarButtonSeparator2});
			this.toolBar.Location = new System.Drawing.Point(0, 24);
			this.toolBar.Name = "toolBar";
			this.toolBar.Size = new System.Drawing.Size(579, 25);
			this.toolBar.TabIndex = 6;
			this.toolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolBar_ButtonClick);
			// 
			// toolBarButtonNew
			// 
			this.toolBarButtonNew.ImageIndex = 0;
			this.toolBarButtonNew.Name = "toolBarButtonNew";
			this.toolBarButtonNew.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonNew.ToolTipText = "Show Layout From XML";
			// 
			// toolBarButtonOpen
			// 
			this.toolBarButtonOpen.ImageIndex = 1;
			this.toolBarButtonOpen.Name = "toolBarButtonOpen";
			this.toolBarButtonOpen.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonOpen.ToolTipText = "Open";
			// 
			// toolBarButtonSeparator1
			// 
			this.toolBarButtonSeparator1.Name = "toolBarButtonSeparator1";
			this.toolBarButtonSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolBarButtonSolutionExplorer
			// 
			this.toolBarButtonSolutionExplorer.ImageIndex = 2;
			this.toolBarButtonSolutionExplorer.Name = "toolBarButtonSolutionExplorer";
			this.toolBarButtonSolutionExplorer.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonSolutionExplorer.ToolTipText = "Solution Explorer";
			// 
			// toolBarButtonPropertyWindow
			// 
			this.toolBarButtonPropertyWindow.ImageIndex = 3;
			this.toolBarButtonPropertyWindow.Name = "toolBarButtonPropertyWindow";
			this.toolBarButtonPropertyWindow.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonPropertyWindow.ToolTipText = "Property Window";
			// 
			// toolBarButtonToolbox
			// 
			this.toolBarButtonToolbox.ImageIndex = 4;
			this.toolBarButtonToolbox.Name = "toolBarButtonToolbox";
			this.toolBarButtonToolbox.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonToolbox.ToolTipText = "Tool Box";
			// 
			// toolBarButtonOutputWindow
			// 
			this.toolBarButtonOutputWindow.ImageIndex = 5;
			this.toolBarButtonOutputWindow.Name = "toolBarButtonOutputWindow";
			this.toolBarButtonOutputWindow.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonOutputWindow.ToolTipText = "Output Window";
			// 
			// toolBarButtonTaskList
			// 
			this.toolBarButtonTaskList.ImageIndex = 6;
			this.toolBarButtonTaskList.Name = "toolBarButtonTaskList";
			this.toolBarButtonTaskList.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonTaskList.ToolTipText = "Task List";
			// 
			// toolBarButtonSeparator2
			// 
			this.toolBarButtonSeparator2.Name = "toolBarButtonSeparator2";
			this.toolBarButtonSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolBarButtonLayoutByCode
			// 
			this.toolBarButtonLayoutByCode.Name = "toolBarButtonLayoutByCode";
			this.toolBarButtonLayoutByCode.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonLayoutByCode.ToolTipText = "Show Layout By Code";
			// 
			// toolBarButtonLayoutByXml
			// 
			this.toolBarButtonLayoutByXml.Name = "toolBarButtonLayoutByXml";
			this.toolBarButtonLayoutByXml.Size = new System.Drawing.Size(23, 22);
			this.toolBarButtonLayoutByXml.ToolTipText = "Show layout by predefined XML file";
			// 
			// toolBarButtonDockPanelSkinDemo
			// 
			this.toolBarButtonDockPanelSkinDemo.CheckOnClick = true;
			this.toolBarButtonDockPanelSkinDemo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolBarButtonDockPanelSkinDemo.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButtonDockPanelSkinDemo.Image")));
			this.toolBarButtonDockPanelSkinDemo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolBarButtonDockPanelSkinDemo.Name = "toolBarButtonDockPanelSkinDemo";
			this.toolBarButtonDockPanelSkinDemo.Size = new System.Drawing.Size(132, 22);
			this.toolBarButtonDockPanelSkinDemo.Text = "DockPanelSkin Demo";
			this.toolBarButtonDockPanelSkinDemo.ToolTipText = "This will use the DockPanelSkin properties to demonstrate its capabilities.";
			// 
			// dockPanel
			// 
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
			this.dockPanel.DockBottomPortion = 150D;
			this.dockPanel.DockLeftPortion = 200D;
			this.dockPanel.DockRightPortion = 200D;
			this.dockPanel.DockTopPortion = 150D;
			this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.dockPanel.Location = new System.Drawing.Point(0, 55);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.RightToLeftLayout = true;
			this.dockPanel.Size = new System.Drawing.Size(579, 326);
			this.dockPanel.TabIndex = 0;
			this.dockPanel.ActiveDocumentChanged += new System.EventHandler(this.dockPanel_ActiveDocumentChanged);
			// 
			// topBar
			// 
			this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.topBar.Location = new System.Drawing.Point(0, 49);
			this.topBar.Name = "topBar";
			this.topBar.Size = new System.Drawing.Size(579, 6);
			this.topBar.TabIndex = 9;
			this.topBar.Visible = false;
			// 
			// bottomBar
			// 
			this.bottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bottomBar.Location = new System.Drawing.Point(0, 381);
			this.bottomBar.Name = "bottomBar";
			this.bottomBar.Size = new System.Drawing.Size(579, 6);
			this.bottomBar.TabIndex = 10;
			this.bottomBar.Visible = false;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(579, 409);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.bottomBar);
			this.Controls.Add(this.topBar);
			this.Controls.Add(this.toolBar);
			this.Controls.Add(this.mainMenu);
			this.Controls.Add(this.statusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "DockSample";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load2);
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton toolBarButtonNew;
        private System.Windows.Forms.ToolStripButton toolBarButtonOpen;
        private System.Windows.Forms.ToolStripSeparator toolBarButtonSeparator1;
        private System.Windows.Forms.ToolStripButton toolBarButtonSolutionExplorer;
        private System.Windows.Forms.ToolStripButton toolBarButtonPropertyWindow;
        private System.Windows.Forms.ToolStripButton toolBarButtonToolbox;
        private System.Windows.Forms.ToolStripButton toolBarButtonOutputWindow;
        private System.Windows.Forms.ToolStripButton toolBarButtonTaskList;
        private System.Windows.Forms.ToolStripSeparator toolBarButtonSeparator2;
        private System.Windows.Forms.ToolStripButton toolBarButtonLayoutByCode;
        private System.Windows.Forms.ToolStripButton toolBarButtonLayoutByXml;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAllButThisOne;
        private System.Windows.Forms.ToolStripSeparator menuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemSolutionExplorer;
        private System.Windows.Forms.ToolStripMenuItem menuItemPropertyWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolbox;
        private System.Windows.Forms.ToolStripMenuItem menuItemOutputWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemTaskList;
        private System.Windows.Forms.ToolStripSeparator menuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemStatusBar;
        private System.Windows.Forms.ToolStripSeparator menuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutByCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutByXml;
        private System.Windows.Forms.ToolStripMenuItem menuItemTools;
        private System.Windows.Forms.ToolStripMenuItem menuItemLockLayout;
        private System.Windows.Forms.ToolStripSeparator menuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2005;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2003;
        private System.Windows.Forms.ToolStripSeparator menuItem6;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingMdi;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingSdi;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemSystemMdi;
        private System.Windows.Forms.ToolStripSeparator menuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowDocumentIcon;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem showRightToLeft;
        private System.Windows.Forms.ToolStripMenuItem exitWithoutSavingLayout;
        private System.Windows.Forms.ToolStripButton toolBarButtonDockPanelSkinDemo;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2012Light;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2013Blue;
        #if DockSample	// todo
        private WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme vS2013BlueTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme vS2012LightTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2003Theme vS2003Theme1;
        private WeifenLuo.WinFormsUI.Docking.VS2005Theme vS2005Theme1;
        #endif
        #if DockSample	// todo
        private VSToolStripExtender vS2012ToolStripExtender1;
        #endif
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Panel bottomBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadDataFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
	}
}