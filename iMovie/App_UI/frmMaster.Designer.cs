namespace iMovie
{
    partial class frmMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaster));
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuStripAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.generateConfigFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripClearCache = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripClearAllMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStripKeepMain = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripSingleMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripBatchMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripOnlineMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripRootPath = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripAllMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripOfflineMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRequestListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStripSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStripQuick = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStripReportConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripStats = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextFavorite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextNone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContext1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext7 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext9 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext10 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextIsSeen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextSeen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextNotSeen = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuContextQuality = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextIndeterminate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContext1080 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContext720 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextDVD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextVCD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStrip.SuspendLayout();
            this.mnuContextFavorite.SuspendLayout();
            this.mnuContextIsSeen.SuspendLayout();
            this.mnuContextQuality.SuspendLayout();
            this.mnuContextDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStrip
            // 
            this.mnuStrip.BackColor = System.Drawing.Color.Transparent;
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripAdmin,
            this.mnuStripInsert,
            this.mnuStripView,
            this.mnuStripHelp});
            this.mnuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.MdiWindowListItem = this.mnuStripAdmin;
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(694, 24);
            this.mnuStrip.TabIndex = 0;
            // 
            // mnuStripAdmin
            // 
            this.mnuStripAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateConfigFilesToolStripMenuItem,
            this.mnuStripClearCache,
            this.mnuStripClearAllMovie,
            this.toolStripSeparator1,
            this.mnuStripKeepMain,
            this.mnuStripExit});
            this.mnuStripAdmin.Name = "mnuStripAdmin";
            this.mnuStripAdmin.ShortcutKeyDisplayString = "";
            this.mnuStripAdmin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.mnuStripAdmin.Size = new System.Drawing.Size(58, 20);
            this.mnuStripAdmin.Text = "ADMIN";
            // 
            // generateConfigFilesToolStripMenuItem
            // 
            this.generateConfigFilesToolStripMenuItem.Name = "generateConfigFilesToolStripMenuItem";
            this.generateConfigFilesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.generateConfigFilesToolStripMenuItem.Text = "Generate Config Files";
            this.generateConfigFilesToolStripMenuItem.Click += new System.EventHandler(this.generateConfigFilesToolStripMenuItem_Click);
            // 
            // mnuStripClearCache
            // 
            this.mnuStripClearCache.Name = "mnuStripClearCache";
            this.mnuStripClearCache.Size = new System.Drawing.Size(218, 22);
            this.mnuStripClearCache.Text = "Clear Suggestion Cache";
            this.mnuStripClearCache.Click += new System.EventHandler(this.mnuStripClearCache_Click);
            // 
            // mnuStripClearAllMovie
            // 
            this.mnuStripClearAllMovie.Name = "mnuStripClearAllMovie";
            this.mnuStripClearAllMovie.Size = new System.Drawing.Size(218, 22);
            this.mnuStripClearAllMovie.Text = "Clear All Movies";
            this.mnuStripClearAllMovie.Click += new System.EventHandler(this.mnuStripClearAllMovie_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuStripKeepMain
            // 
            this.mnuStripKeepMain.Name = "mnuStripKeepMain";
            this.mnuStripKeepMain.Size = new System.Drawing.Size(218, 22);
            this.mnuStripKeepMain.Text = "Close All But Main Window";
            this.mnuStripKeepMain.Click += new System.EventHandler(this.mnuStripKeepMain_Click);
            // 
            // mnuStripExit
            // 
            this.mnuStripExit.Image = global::iMovie.Properties.Resources.menu_exit;
            this.mnuStripExit.Name = "mnuStripExit";
            this.mnuStripExit.Size = new System.Drawing.Size(218, 22);
            this.mnuStripExit.Text = "Exit iMovie";
            this.mnuStripExit.Click += new System.EventHandler(this.mnuStripExit_Click);
            // 
            // mnuStripInsert
            // 
            this.mnuStripInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripMovie,
            this.mnuStripRootPath});
            this.mnuStripInsert.Name = "mnuStripInsert";
            this.mnuStripInsert.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.mnuStripInsert.Size = new System.Drawing.Size(55, 20);
            this.mnuStripInsert.Text = "INSERT";
            // 
            // mnuStripMovie
            // 
            this.mnuStripMovie.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripSingleMovie,
            this.mnuStripBatchMovie,
            this.mnuStripOnlineMovie});
            this.mnuStripMovie.Name = "mnuStripMovie";
            this.mnuStripMovie.Size = new System.Drawing.Size(162, 22);
            this.mnuStripMovie.Text = "Movie";
            // 
            // mnuStripSingleMovie
            // 
            this.mnuStripSingleMovie.Name = "mnuStripSingleMovie";
            this.mnuStripSingleMovie.Size = new System.Drawing.Size(170, 22);
            this.mnuStripSingleMovie.Text = "Force Single Insert";
            this.mnuStripSingleMovie.Click += new System.EventHandler(this.mnuStripSingleMovie_Click);
            // 
            // mnuStripBatchMovie
            // 
            this.mnuStripBatchMovie.Name = "mnuStripBatchMovie";
            this.mnuStripBatchMovie.Size = new System.Drawing.Size(170, 22);
            this.mnuStripBatchMovie.Text = "Batch Insert";
            this.mnuStripBatchMovie.Click += new System.EventHandler(this.mnuStripBatchMovie_Click);
            // 
            // mnuStripOnlineMovie
            // 
            this.mnuStripOnlineMovie.Name = "mnuStripOnlineMovie";
            this.mnuStripOnlineMovie.Size = new System.Drawing.Size(170, 22);
            this.mnuStripOnlineMovie.Text = "Online Update";
            this.mnuStripOnlineMovie.Click += new System.EventHandler(this.mnuStripOnlineMovie_Click);
            // 
            // mnuStripRootPath
            // 
            this.mnuStripRootPath.Name = "mnuStripRootPath";
            this.mnuStripRootPath.Size = new System.Drawing.Size(162, 22);
            this.mnuStripRootPath.Text = "Movie Root Path";
            this.mnuStripRootPath.Click += new System.EventHandler(this.mnuStripRootPath_Click);
            // 
            // mnuStripView
            // 
            this.mnuStripView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripFavorite,
            this.mnuStripAllMovie,
            this.mnuStripOfflineMovie,
            this.copyRequestListToolStripMenuItem,
            this.mnuStripDuplicate,
            this.toolStripSeparator8,
            this.mnuStripSearch,
            this.mnuStripMain,
            this.toolStripSeparator3,
            this.mnuStripQuick,
            this.toolStripSeparator2,
            this.mnuStripReportConsole,
            this.mnuStripStats});
            this.mnuStripView.Name = "mnuStripView";
            this.mnuStripView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.mnuStripView.Size = new System.Drawing.Size(46, 20);
            this.mnuStripView.Text = "VIEW";
            // 
            // mnuStripFavorite
            // 
            this.mnuStripFavorite.Image = global::iMovie.Properties.Resources.menu_favorite;
            this.mnuStripFavorite.Name = "mnuStripFavorite";
            this.mnuStripFavorite.Size = new System.Drawing.Size(218, 22);
            this.mnuStripFavorite.Text = "Favorite List";
            this.mnuStripFavorite.Click += new System.EventHandler(this.mnuStripFavorite_Click);
            // 
            // mnuStripAllMovie
            // 
            this.mnuStripAllMovie.Name = "mnuStripAllMovie";
            this.mnuStripAllMovie.Size = new System.Drawing.Size(218, 22);
            this.mnuStripAllMovie.Text = "All Movies List";
            this.mnuStripAllMovie.Click += new System.EventHandler(this.mnuStripAllMovie_Click);
            // 
            // mnuStripOfflineMovie
            // 
            this.mnuStripOfflineMovie.Name = "mnuStripOfflineMovie";
            this.mnuStripOfflineMovie.Size = new System.Drawing.Size(218, 22);
            this.mnuStripOfflineMovie.Text = "Offline Movies List";
            this.mnuStripOfflineMovie.Click += new System.EventHandler(this.mnuStripOfflineMovie_Click);
            // 
            // copyRequestListToolStripMenuItem
            // 
            this.copyRequestListToolStripMenuItem.Name = "copyRequestListToolStripMenuItem";
            this.copyRequestListToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.copyRequestListToolStripMenuItem.Text = "Copy Request List";
            this.copyRequestListToolStripMenuItem.Click += new System.EventHandler(this.copyRequestListToolStripMenuItem_Click);
            // 
            // mnuStripDuplicate
            // 
            this.mnuStripDuplicate.Image = global::iMovie.Properties.Resources.duplicate_menu;
            this.mnuStripDuplicate.Name = "mnuStripDuplicate";
            this.mnuStripDuplicate.Size = new System.Drawing.Size(218, 22);
            this.mnuStripDuplicate.Text = "Duplicate Movies (Approx.)";
            this.mnuStripDuplicate.Click += new System.EventHandler(this.mnuStripDuplicate_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuStripSearch
            // 
            this.mnuStripSearch.Image = global::iMovie.Properties.Resources.search;
            this.mnuStripSearch.Name = "mnuStripSearch";
            this.mnuStripSearch.Size = new System.Drawing.Size(218, 22);
            this.mnuStripSearch.Text = "Search Area";
            this.mnuStripSearch.Click += new System.EventHandler(this.mnuStripSearch_Click);
            // 
            // mnuStripMain
            // 
            this.mnuStripMain.Name = "mnuStripMain";
            this.mnuStripMain.Size = new System.Drawing.Size(218, 22);
            this.mnuStripMain.Text = "Main Window";
            this.mnuStripMain.Click += new System.EventHandler(this.mnuStripMain_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuStripQuick
            // 
            this.mnuStripQuick.Image = global::iMovie.Properties.Resources.menu_random;
            this.mnuStripQuick.Name = "mnuStripQuick";
            this.mnuStripQuick.Size = new System.Drawing.Size(218, 22);
            this.mnuStripQuick.Text = "Quick Suggestion";
            this.mnuStripQuick.Click += new System.EventHandler(this.mnuStripQuick_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuStripReportConsole
            // 
            this.mnuStripReportConsole.Name = "mnuStripReportConsole";
            this.mnuStripReportConsole.Size = new System.Drawing.Size(218, 22);
            this.mnuStripReportConsole.Text = "SQL Report Console";
            this.mnuStripReportConsole.Click += new System.EventHandler(this.mnuStripReportConsole_Click);
            // 
            // mnuStripStats
            // 
            this.mnuStripStats.Image = global::iMovie.Properties.Resources.menu_stats;
            this.mnuStripStats.Name = "mnuStripStats";
            this.mnuStripStats.Size = new System.Drawing.Size(218, 22);
            this.mnuStripStats.Text = "Statistics";
            this.mnuStripStats.Click += new System.EventHandler(this.mnuStripStats_Click);
            // 
            // mnuStripHelp
            // 
            this.mnuStripHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripGuide,
            this.mnuStripAbout});
            this.mnuStripHelp.Name = "mnuStripHelp";
            this.mnuStripHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.mnuStripHelp.Size = new System.Drawing.Size(47, 20);
            this.mnuStripHelp.Text = "HELP";
            // 
            // mnuStripGuide
            // 
            this.mnuStripGuide.Image = global::iMovie.Properties.Resources.menu_guide;
            this.mnuStripGuide.Name = "mnuStripGuide";
            this.mnuStripGuide.Size = new System.Drawing.Size(131, 22);
            this.mnuStripGuide.Text = "User Guide";
            // 
            // mnuStripAbout
            // 
            this.mnuStripAbout.Image = global::iMovie.Properties.Resources.menu_about;
            this.mnuStripAbout.Name = "mnuStripAbout";
            this.mnuStripAbout.Size = new System.Drawing.Size(131, 22);
            this.mnuStripAbout.Text = "About";
            this.mnuStripAbout.Click += new System.EventHandler(this.mnuStripAbout_Click);
            // 
            // mnuContextFavorite
            // 
            this.mnuContextFavorite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextNone,
            this.toolStripSeparator5,
            this.mnuContext1,
            this.mnuContext2,
            this.mnuContext3,
            this.mnuContext4,
            this.mnuContext5,
            this.mnuContext6,
            this.mnuContext7,
            this.mnuContext8,
            this.mnuContext9,
            this.mnuContext10});
            this.mnuContextFavorite.Name = "contextMenuStrip1";
            this.mnuContextFavorite.ShowImageMargin = false;
            this.mnuContextFavorite.Size = new System.Drawing.Size(79, 252);
            // 
            // mnuContextNone
            // 
            this.mnuContextNone.Name = "mnuContextNone";
            this.mnuContextNone.Size = new System.Drawing.Size(78, 22);
            this.mnuContextNone.Text = "None";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(75, 6);
            // 
            // mnuContext1
            // 
            this.mnuContext1.Name = "mnuContext1";
            this.mnuContext1.Size = new System.Drawing.Size(78, 22);
            this.mnuContext1.Text = "1";
            // 
            // mnuContext2
            // 
            this.mnuContext2.Name = "mnuContext2";
            this.mnuContext2.Size = new System.Drawing.Size(78, 22);
            this.mnuContext2.Text = "2";
            // 
            // mnuContext3
            // 
            this.mnuContext3.Name = "mnuContext3";
            this.mnuContext3.Size = new System.Drawing.Size(78, 22);
            this.mnuContext3.Text = "3";
            // 
            // mnuContext4
            // 
            this.mnuContext4.Name = "mnuContext4";
            this.mnuContext4.Size = new System.Drawing.Size(78, 22);
            this.mnuContext4.Text = "4";
            // 
            // mnuContext5
            // 
            this.mnuContext5.Name = "mnuContext5";
            this.mnuContext5.Size = new System.Drawing.Size(78, 22);
            this.mnuContext5.Text = "5";
            // 
            // mnuContext6
            // 
            this.mnuContext6.Name = "mnuContext6";
            this.mnuContext6.Size = new System.Drawing.Size(78, 22);
            this.mnuContext6.Text = "6";
            // 
            // mnuContext7
            // 
            this.mnuContext7.Name = "mnuContext7";
            this.mnuContext7.Size = new System.Drawing.Size(78, 22);
            this.mnuContext7.Text = "7";
            // 
            // mnuContext8
            // 
            this.mnuContext8.Name = "mnuContext8";
            this.mnuContext8.Size = new System.Drawing.Size(78, 22);
            this.mnuContext8.Text = "8";
            // 
            // mnuContext9
            // 
            this.mnuContext9.Name = "mnuContext9";
            this.mnuContext9.Size = new System.Drawing.Size(78, 22);
            this.mnuContext9.Text = "9";
            // 
            // mnuContext10
            // 
            this.mnuContext10.Name = "mnuContext10";
            this.mnuContext10.Size = new System.Drawing.Size(78, 22);
            this.mnuContext10.Text = "10";
            // 
            // mnuContextIsSeen
            // 
            this.mnuContextIsSeen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextSeen,
            this.mnuContextNotSeen});
            this.mnuContextIsSeen.Name = "mnuContextIsSeen";
            this.mnuContextIsSeen.ShowImageMargin = false;
            this.mnuContextIsSeen.Size = new System.Drawing.Size(120, 48);
            // 
            // mnuContextSeen
            // 
            this.mnuContextSeen.Name = "mnuContextSeen";
            this.mnuContextSeen.Size = new System.Drawing.Size(119, 22);
            this.mnuContextSeen.Text = "Watched";
            // 
            // mnuContextNotSeen
            // 
            this.mnuContextNotSeen.Name = "mnuContextNotSeen";
            this.mnuContextNotSeen.Size = new System.Drawing.Size(119, 22);
            this.mnuContextNotSeen.Text = "Not Watched";
            // 
            // masterToolTip
            // 
            this.masterToolTip.IsBalloon = true;
            // 
            // mnuContextQuality
            // 
            this.mnuContextQuality.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextIndeterminate,
            this.toolStripSeparator6,
            this.mnuContext1080,
            this.mnuContext720,
            this.mnuContextDVD,
            this.mnuContextVCD});
            this.mnuContextQuality.Name = "mnuContextQuality";
            this.mnuContextQuality.ShowImageMargin = false;
            this.mnuContextQuality.Size = new System.Drawing.Size(124, 120);
            // 
            // mnuContextIndeterminate
            // 
            this.mnuContextIndeterminate.Name = "mnuContextIndeterminate";
            this.mnuContextIndeterminate.Size = new System.Drawing.Size(123, 22);
            this.mnuContextIndeterminate.Text = "Indeterminate";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(120, 6);
            // 
            // mnuContext1080
            // 
            this.mnuContext1080.Name = "mnuContext1080";
            this.mnuContext1080.Size = new System.Drawing.Size(123, 22);
            this.mnuContext1080.Text = "1080p";
            // 
            // mnuContext720
            // 
            this.mnuContext720.Name = "mnuContext720";
            this.mnuContext720.Size = new System.Drawing.Size(123, 22);
            this.mnuContext720.Text = "720p";
            // 
            // mnuContextDVD
            // 
            this.mnuContextDVD.Name = "mnuContextDVD";
            this.mnuContextDVD.Size = new System.Drawing.Size(123, 22);
            this.mnuContextDVD.Text = "DVD";
            // 
            // mnuContextVCD
            // 
            this.mnuContextVCD.Name = "mnuContextVCD";
            this.mnuContextVCD.Size = new System.Drawing.Size(123, 22);
            this.mnuContextVCD.Text = "VCD";
            // 
            // mnuContextDelete
            // 
            this.mnuContextDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextDeleteItem});
            this.mnuContextDelete.Name = "mnuContextDelete";
            this.mnuContextDelete.ShowImageMargin = false;
            this.mnuContextDelete.Size = new System.Drawing.Size(83, 26);
            // 
            // mnuContextDeleteItem
            // 
            this.mnuContextDeleteItem.Name = "mnuContextDeleteItem";
            this.mnuContextDeleteItem.Size = new System.Drawing.Size(82, 22);
            this.mnuContextDeleteItem.Text = "Delete";
            // 
            // frmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 526);
            this.Controls.Add(this.mnuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuStrip;
            this.MaximizeBox = false;
            this.Name = "frmMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMaster_Load);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.mnuContextFavorite.ResumeLayout(false);
            this.mnuContextIsSeen.ResumeLayout(false);
            this.mnuContextQuality.ResumeLayout(false);
            this.mnuContextDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.MenuStrip mnuStrip;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripAdmin;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripHelp;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripGuide;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripAbout;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripView;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripStats;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripInsert;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripMovie;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripMain;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripKeepMain;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripExit;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripFavorite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripQuick;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripClearCache;
        protected System.Windows.Forms.ContextMenuStrip mnuContextFavorite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        protected System.Windows.Forms.ContextMenuStrip mnuContextIsSeen;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextNone;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext1;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext2;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext3;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext4;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext5;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext6;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext7;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext8;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext9;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext10;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextSeen;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextNotSeen;
        protected System.Windows.Forms.ToolTip masterToolTip;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripSearch;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripBatchMovie;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripSingleMovie;
        protected System.Windows.Forms.ContextMenuStrip mnuContextQuality;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextIndeterminate;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext1080;
        protected System.Windows.Forms.ToolStripMenuItem mnuContext720;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextDVD;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextVCD;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripOnlineMovie;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripRootPath;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripDuplicate;
        protected System.Windows.Forms.ContextMenuStrip mnuContextDelete;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextDeleteItem;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripClearAllMovie;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripAllMovie;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem copyRequestListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuStripReportConsole;
        protected System.Windows.Forms.ToolStripMenuItem generateConfigFilesToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem mnuStripOfflineMovie;
    }
}

