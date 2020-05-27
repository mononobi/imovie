namespace iMovie
{
    partial class frmMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovie));
            this.tab = new System.Windows.Forms.TabControl();
            this.tabSummary = new System.Windows.Forms.TabPage();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblFavValue = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.mnuContextMenuDeleteDirectors = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeDirectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDirectorValue = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblAddDate = new System.Windows.Forms.Label();
            this.lblLanguageValue = new System.Windows.Forms.Label();
            this.lblDurationValue = new System.Windows.Forms.Label();
            this.lblRateValue = new System.Windows.Forms.Label();
            this.lblGenreValue = new System.Windows.Forms.Label();
            this.lblAddDateValue = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.picQuality = new System.Windows.Forms.PictureBox();
            this.picIsSeen = new System.Windows.Forms.PictureBox();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.mnuContextExtra = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.requestCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabStory = new System.Windows.Forms.TabPage();
            this.lblStoryTitle = new System.Windows.Forms.Label();
            this.grpStory = new System.Windows.Forms.GroupBox();
            this.lblStoryText = new System.Windows.Forms.Label();
            this.tabDirector = new System.Windows.Forms.TabPage();
            this.repDirector = new iMovie.ucPersonRepeater();
            this.tabCasts = new System.Windows.Forms.TabPage();
            this.ucActorList = new iMovie.ucPersonList();
            this.tabSimilar = new System.Windows.Forms.TabPage();
            this.repMovie = new iMovie.ucMovieRepeater();
            this.lblSimilar = new System.Windows.Forms.Label();
            this.linkIMDB = new System.Windows.Forms.LinkLabel();
            this.linkFile = new System.Windows.Forms.LinkLabel();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tab.SuspendLayout();
            this.tabSummary.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.mnuContextMenuDeleteDirectors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsSeen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.mnuContextExtra.SuspendLayout();
            this.tabStory.SuspendLayout();
            this.grpStory.SuspendLayout();
            this.tabDirector.SuspendLayout();
            this.tabCasts.SuspendLayout();
            this.tabSimilar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tab.Controls.Add(this.tabSummary);
            this.tab.Controls.Add(this.tabStory);
            this.tab.Controls.Add(this.tabDirector);
            this.tab.Controls.Add(this.tabCasts);
            this.tab.Controls.Add(this.tabSimilar);
            this.tab.Dock = System.Windows.Forms.DockStyle.Top;
            this.tab.Location = new System.Drawing.Point(0, 24);
            this.tab.Multiline = true;
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(678, 431);
            this.tab.TabIndex = 5;
            // 
            // tabSummary
            // 
            this.tabSummary.BackColor = System.Drawing.SystemColors.Control;
            this.tabSummary.Controls.Add(this.lblMovieName);
            this.tabSummary.Controls.Add(this.grpDetails);
            this.tabSummary.Controls.Add(this.picQuality);
            this.tabSummary.Controls.Add(this.picIsSeen);
            this.tabSummary.Controls.Add(this.picPoster);
            this.tabSummary.Location = new System.Drawing.Point(4, 25);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabSummary.Size = new System.Drawing.Size(670, 402);
            this.tabSummary.TabIndex = 0;
            this.tabSummary.Text = "Summary";
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoEllipsis = true;
            this.lblMovieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieName.Location = new System.Drawing.Point(237, 17);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(406, 79);
            this.lblMovieName.TabIndex = 23;
            this.lblMovieName.Text = "N/A";
            this.lblMovieName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMovieName.UseMnemonic = false;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblFavValue);
            this.grpDetails.Controls.Add(this.lblDirector);
            this.grpDetails.Controls.Add(this.lblDirectorValue);
            this.grpDetails.Controls.Add(this.lblDuration);
            this.grpDetails.Controls.Add(this.lblAddDate);
            this.grpDetails.Controls.Add(this.lblLanguageValue);
            this.grpDetails.Controls.Add(this.lblDurationValue);
            this.grpDetails.Controls.Add(this.lblRateValue);
            this.grpDetails.Controls.Add(this.lblGenreValue);
            this.grpDetails.Controls.Add(this.lblAddDateValue);
            this.grpDetails.Controls.Add(this.lblLanguage);
            this.grpDetails.Controls.Add(this.lblGenre);
            this.grpDetails.Location = new System.Drawing.Point(237, 99);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(406, 282);
            this.grpDetails.TabIndex = 40;
            this.grpDetails.TabStop = false;
            // 
            // lblFavValue
            // 
            this.lblFavValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFavValue.ContextMenuStrip = this.mnuContextFavorite;
            this.lblFavValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFavValue.Image = global::iMovie.Properties.Resources.fav_rate_91;
            this.lblFavValue.Location = new System.Drawing.Point(306, 188);
            this.lblFavValue.Name = "lblFavValue";
            this.lblFavValue.Size = new System.Drawing.Size(91, 91);
            this.lblFavValue.TabIndex = 40;
            this.lblFavValue.Text = "-";
            this.lblFavValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tooltip.SetToolTip(this.lblFavValue, "Favorite Rate");
            // 
            // lblDirector
            // 
            this.lblDirector.AutoEllipsis = true;
            this.lblDirector.ContextMenuStrip = this.mnuContextMenuDeleteDirectors;
            this.lblDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDirector.Location = new System.Drawing.Point(94, 26);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(81, 27);
            this.lblDirector.TabIndex = 38;
            this.lblDirector.Text = "Director:";
            this.lblDirector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuContextMenuDeleteDirectors
            // 
            this.mnuContextMenuDeleteDirectors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeDirectorsToolStripMenuItem});
            this.mnuContextMenuDeleteDirectors.Name = "mnuContextMenuDeleteDirectors";
            this.mnuContextMenuDeleteDirectors.ShowImageMargin = false;
            this.mnuContextMenuDeleteDirectors.Size = new System.Drawing.Size(143, 26);
            // 
            // removeDirectorsToolStripMenuItem
            // 
            this.removeDirectorsToolStripMenuItem.Name = "removeDirectorsToolStripMenuItem";
            this.removeDirectorsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.removeDirectorsToolStripMenuItem.Text = "Remove Directors";
            this.removeDirectorsToolStripMenuItem.Click += new System.EventHandler(this.removeDirectorsToolStripMenuItem_Click);
            // 
            // lblDirectorValue
            // 
            this.lblDirectorValue.AutoEllipsis = true;
            this.lblDirectorValue.ContextMenuStrip = this.mnuContextMenuDeleteDirectors;
            this.lblDirectorValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDirectorValue.Location = new System.Drawing.Point(181, 24);
            this.lblDirectorValue.Name = "lblDirectorValue";
            this.lblDirectorValue.Size = new System.Drawing.Size(201, 30);
            this.lblDirectorValue.TabIndex = 39;
            this.lblDirectorValue.Text = "N/A";
            this.lblDirectorValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDirectorValue.UseMnemonic = false;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoEllipsis = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDuration.Location = new System.Drawing.Point(94, 120);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(81, 29);
            this.lblDuration.TabIndex = 28;
            this.lblDuration.Text = "Duration:";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAddDate
            // 
            this.lblAddDate.AutoEllipsis = true;
            this.lblAddDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAddDate.Location = new System.Drawing.Point(91, 154);
            this.lblAddDate.Name = "lblAddDate";
            this.lblAddDate.Size = new System.Drawing.Size(84, 27);
            this.lblAddDate.TabIndex = 29;
            this.lblAddDate.Text = "Date Archived:";
            this.lblAddDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLanguageValue
            // 
            this.lblLanguageValue.AutoEllipsis = true;
            this.lblLanguageValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLanguageValue.Location = new System.Drawing.Point(181, 87);
            this.lblLanguageValue.Name = "lblLanguageValue";
            this.lblLanguageValue.Size = new System.Drawing.Size(201, 29);
            this.lblLanguageValue.TabIndex = 37;
            this.lblLanguageValue.Text = "N/A";
            this.lblLanguageValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLanguageValue.UseMnemonic = false;
            // 
            // lblDurationValue
            // 
            this.lblDurationValue.AutoEllipsis = true;
            this.lblDurationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDurationValue.Location = new System.Drawing.Point(181, 120);
            this.lblDurationValue.Name = "lblDurationValue";
            this.lblDurationValue.Size = new System.Drawing.Size(99, 29);
            this.lblDurationValue.TabIndex = 30;
            this.lblDurationValue.Text = "N/A";
            this.lblDurationValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDurationValue.UseMnemonic = false;
            // 
            // lblRateValue
            // 
            this.lblRateValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblRateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateValue.Image = ((System.Drawing.Image)(resources.GetObject("lblRateValue.Image")));
            this.lblRateValue.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblRateValue.Location = new System.Drawing.Point(6, 170);
            this.lblRateValue.Name = "lblRateValue";
            this.lblRateValue.Size = new System.Drawing.Size(109, 109);
            this.lblRateValue.TabIndex = 27;
            this.lblRateValue.Text = "N/A";
            this.lblRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tooltip.SetToolTip(this.lblRateValue, "IMDb Rate");
            // 
            // lblGenreValue
            // 
            this.lblGenreValue.AutoEllipsis = true;
            this.lblGenreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGenreValue.Location = new System.Drawing.Point(181, 56);
            this.lblGenreValue.Name = "lblGenreValue";
            this.lblGenreValue.Size = new System.Drawing.Size(201, 30);
            this.lblGenreValue.TabIndex = 36;
            this.lblGenreValue.Text = "N/A";
            this.lblGenreValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGenreValue.UseMnemonic = false;
            // 
            // lblAddDateValue
            // 
            this.lblAddDateValue.AutoEllipsis = true;
            this.lblAddDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAddDateValue.Location = new System.Drawing.Point(181, 153);
            this.lblAddDateValue.Name = "lblAddDateValue";
            this.lblAddDateValue.Size = new System.Drawing.Size(99, 29);
            this.lblAddDateValue.TabIndex = 31;
            this.lblAddDateValue.Text = "N/A";
            this.lblAddDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddDateValue.UseMnemonic = false;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoEllipsis = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLanguage.Location = new System.Drawing.Point(97, 88);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(78, 27);
            this.lblLanguage.TabIndex = 35;
            this.lblLanguage.Text = "Language:";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoEllipsis = true;
            this.lblGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGenre.Location = new System.Drawing.Point(97, 58);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(78, 27);
            this.lblGenre.TabIndex = 34;
            this.lblGenre.Text = "Genre:";
            this.lblGenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picQuality
            // 
            this.picQuality.ContextMenuStrip = this.mnuContextQuality;
            this.picQuality.ErrorImage = global::iMovie.Properties.Resources.na;
            this.picQuality.Image = global::iMovie.Properties.Resources.na;
            this.picQuality.InitialImage = global::iMovie.Properties.Resources.na;
            this.picQuality.Location = new System.Drawing.Point(97, 17);
            this.picQuality.Name = "picQuality";
            this.picQuality.Size = new System.Drawing.Size(122, 65);
            this.picQuality.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuality.TabIndex = 25;
            this.picQuality.TabStop = false;
            this.tooltip.SetToolTip(this.picQuality, "Video Quality");
            // 
            // picIsSeen
            // 
            this.picIsSeen.ContextMenuStrip = this.mnuContextIsSeen;
            this.picIsSeen.ErrorImage = global::iMovie.Properties.Resources.not_seen;
            this.picIsSeen.Image = global::iMovie.Properties.Resources.not_seen;
            this.picIsSeen.InitialImage = global::iMovie.Properties.Resources.not_seen;
            this.picIsSeen.Location = new System.Drawing.Point(26, 17);
            this.picIsSeen.Name = "picIsSeen";
            this.picIsSeen.Size = new System.Drawing.Size(65, 65);
            this.picIsSeen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIsSeen.TabIndex = 24;
            this.picIsSeen.TabStop = false;
            this.tooltip.SetToolTip(this.picIsSeen, "This movie has not been watched yet");
            // 
            // picPoster
            // 
            this.picPoster.ContextMenuStrip = this.mnuContextExtra;
            this.picPoster.ErrorImage = global::iMovie.Properties.Resources.no_pic;
            this.picPoster.Image = global::iMovie.Properties.Resources.no_pic;
            this.picPoster.InitialImage = global::iMovie.Properties.Resources.no_pic;
            this.picPoster.Location = new System.Drawing.Point(26, 89);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(193, 292);
            this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPoster.TabIndex = 22;
            this.picPoster.TabStop = false;
            // 
            // mnuContextExtra
            // 
            this.mnuContextExtra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestCopyToolStripMenuItem});
            this.mnuContextExtra.Name = "mnuContextExtra";
            this.mnuContextExtra.ShowImageMargin = false;
            this.mnuContextExtra.Size = new System.Drawing.Size(123, 26);
            // 
            // requestCopyToolStripMenuItem
            // 
            this.requestCopyToolStripMenuItem.Name = "requestCopyToolStripMenuItem";
            this.requestCopyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.requestCopyToolStripMenuItem.Text = "Request Copy";
            this.requestCopyToolStripMenuItem.Click += new System.EventHandler(this.requestCopyToolStripMenuItem_Click);
            // 
            // tabStory
            // 
            this.tabStory.Controls.Add(this.lblStoryTitle);
            this.tabStory.Controls.Add(this.grpStory);
            this.tabStory.Location = new System.Drawing.Point(4, 25);
            this.tabStory.Name = "tabStory";
            this.tabStory.Padding = new System.Windows.Forms.Padding(3);
            this.tabStory.Size = new System.Drawing.Size(670, 402);
            this.tabStory.TabIndex = 4;
            this.tabStory.Text = "StoryLine";
            // 
            // lblStoryTitle
            // 
            this.lblStoryTitle.AutoSize = true;
            this.lblStoryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStoryTitle.Location = new System.Drawing.Point(32, 41);
            this.lblStoryTitle.Name = "lblStoryTitle";
            this.lblStoryTitle.Size = new System.Drawing.Size(113, 26);
            this.lblStoryTitle.TabIndex = 1;
            this.lblStoryTitle.Text = "StoryLine";
            // 
            // grpStory
            // 
            this.grpStory.Controls.Add(this.lblStoryText);
            this.grpStory.Location = new System.Drawing.Point(37, 67);
            this.grpStory.Name = "grpStory";
            this.grpStory.Size = new System.Drawing.Size(594, 268);
            this.grpStory.TabIndex = 0;
            this.grpStory.TabStop = false;
            // 
            // lblStoryText
            // 
            this.lblStoryText.AutoEllipsis = true;
            this.lblStoryText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStoryText.Location = new System.Drawing.Point(24, 25);
            this.lblStoryText.Name = "lblStoryText";
            this.lblStoryText.Size = new System.Drawing.Size(551, 224);
            this.lblStoryText.TabIndex = 0;
            this.lblStoryText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStoryText.UseMnemonic = false;
            // 
            // tabDirector
            // 
            this.tabDirector.BackColor = System.Drawing.SystemColors.Control;
            this.tabDirector.Controls.Add(this.repDirector);
            this.tabDirector.Location = new System.Drawing.Point(4, 25);
            this.tabDirector.Name = "tabDirector";
            this.tabDirector.Padding = new System.Windows.Forms.Padding(3);
            this.tabDirector.Size = new System.Drawing.Size(670, 402);
            this.tabDirector.TabIndex = 1;
            this.tabDirector.Text = "Directed By";
            // 
            // repDirector
            // 
            this.repDirector.DataSource = new iMovie.Person[0];
            this.repDirector.Location = new System.Drawing.Point(24, 23);
            this.repDirector.MaximumSize = new System.Drawing.Size(619, 196);
            this.repDirector.Name = "repDirector";
            this.repDirector.Size = new System.Drawing.Size(619, 196);
            this.repDirector.TabIndex = 6;
            // 
            // tabCasts
            // 
            this.tabCasts.Controls.Add(this.ucActorList);
            this.tabCasts.Location = new System.Drawing.Point(4, 25);
            this.tabCasts.Name = "tabCasts";
            this.tabCasts.Padding = new System.Windows.Forms.Padding(3);
            this.tabCasts.Size = new System.Drawing.Size(670, 402);
            this.tabCasts.TabIndex = 5;
            this.tabCasts.Text = "Cast";
            this.tabCasts.UseVisualStyleBackColor = true;
            // 
            // ucActorList
            // 
            this.ucActorList.Location = new System.Drawing.Point(136, 16);
            this.ucActorList.Name = "ucActorList";
            this.ucActorList.PersonType = "";
            this.ucActorList.Size = new System.Drawing.Size(379, 368);
            this.ucActorList.TabIndex = 0;
            // 
            // tabSimilar
            // 
            this.tabSimilar.BackColor = System.Drawing.SystemColors.Control;
            this.tabSimilar.Controls.Add(this.repMovie);
            this.tabSimilar.Controls.Add(this.lblSimilar);
            this.tabSimilar.Location = new System.Drawing.Point(4, 25);
            this.tabSimilar.Name = "tabSimilar";
            this.tabSimilar.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimilar.Size = new System.Drawing.Size(670, 402);
            this.tabSimilar.TabIndex = 2;
            this.tabSimilar.Text = "Similar Movies";
            // 
            // repMovie
            // 
            this.repMovie.DataSource = new iMovie.Movie[0];
            this.repMovie.EnableRightClickMenu = false;
            this.repMovie.Location = new System.Drawing.Point(6, 61);
            this.repMovie.MaximumSize = new System.Drawing.Size(660, 315);
            this.repMovie.MinimumSize = new System.Drawing.Size(660, 315);
            this.repMovie.Name = "repMovie";
            this.repMovie.RemoveOnNoneFavorite = false;
            this.repMovie.ShowCount = false;
            this.repMovie.Size = new System.Drawing.Size(660, 315);
            this.repMovie.TabIndex = 8;
            // 
            // lblSimilar
            // 
            this.lblSimilar.AutoSize = true;
            this.lblSimilar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSimilar.Location = new System.Drawing.Point(3, 29);
            this.lblSimilar.Name = "lblSimilar";
            this.lblSimilar.Size = new System.Drawing.Size(447, 20);
            this.lblSimilar.TabIndex = 1;
            this.lblSimilar.Text = "Here is a list of similar movies by genre you may want to watch:";
            // 
            // linkIMDB
            // 
            this.linkIMDB.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkIMDB.AutoSize = true;
            this.linkIMDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.linkIMDB.Location = new System.Drawing.Point(28, 456);
            this.linkIMDB.Name = "linkIMDB";
            this.linkIMDB.Size = new System.Drawing.Size(90, 17);
            this.linkIMDB.TabIndex = 0;
            this.linkIMDB.TabStop = true;
            this.linkIMDB.Text = "Visit on IMDb";
            this.linkIMDB.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkIMDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIMDB_LinkClicked);
            // 
            // linkFile
            // 
            this.linkFile.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkFile.AutoSize = true;
            this.linkFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.linkFile.Location = new System.Drawing.Point(532, 456);
            this.linkFile.Name = "linkFile";
            this.linkFile.Size = new System.Drawing.Size(115, 17);
            this.linkFile.TabIndex = 1;
            this.linkFile.TabStop = true;
            this.linkFile.Text = "Watch this Movie";
            this.linkFile.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFile_LinkClicked);
            // 
            // frmMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 488);
            this.Controls.Add(this.linkFile);
            this.Controls.Add(this.linkIMDB);
            this.Controls.Add(this.tab);
            this.Name = "frmMovie";
            this.Text = "Movie";
            this.Load += new System.EventHandler(this.frmMovie_Load);
            this.Controls.SetChildIndex(this.tab, 0);
            this.Controls.SetChildIndex(this.linkIMDB, 0);
            this.Controls.SetChildIndex(this.linkFile, 0);
            this.tab.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.mnuContextMenuDeleteDirectors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIsSeen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.mnuContextExtra.ResumeLayout(false);
            this.tabStory.ResumeLayout(false);
            this.tabStory.PerformLayout();
            this.grpStory.ResumeLayout(false);
            this.tabDirector.ResumeLayout(false);
            this.tabCasts.ResumeLayout(false);
            this.tabSimilar.ResumeLayout(false);
            this.tabSimilar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabSummary;
        private System.Windows.Forms.Label lblDirectorValue;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblLanguageValue;
        private System.Windows.Forms.Label lblGenreValue;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblAddDateValue;
        private System.Windows.Forms.Label lblDurationValue;
        private System.Windows.Forms.Label lblAddDate;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.PictureBox picQuality;
        private System.Windows.Forms.PictureBox picIsSeen;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Label lblRateValue;
        private System.Windows.Forms.TabPage tabDirector;
        private System.Windows.Forms.LinkLabel linkIMDB;
        private System.Windows.Forms.LinkLabel linkFile;
        private System.Windows.Forms.TabPage tabSimilar;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblSimilar;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label lblFavValue;
        private ucMovieRepeater repMovie;
        private ucPersonRepeater repDirector;
        private System.Windows.Forms.TabPage tabStory;
        private System.Windows.Forms.GroupBox grpStory;
        private System.Windows.Forms.Label lblStoryTitle;
        private System.Windows.Forms.Label lblStoryText;
        private System.Windows.Forms.ContextMenuStrip mnuContextExtra;
        private System.Windows.Forms.ToolStripMenuItem requestCopyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnuContextMenuDeleteDirectors;
        private System.Windows.Forms.ToolStripMenuItem removeDirectorsToolStripMenuItem;
        private System.Windows.Forms.TabPage tabCasts;
        private ucPersonList ucActorList;
    }
}