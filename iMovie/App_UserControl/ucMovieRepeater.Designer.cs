namespace iMovie
{
    partial class ucMovieRepeater
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.repMovie = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.lblFavoriteRate = new System.Windows.Forms.Label();
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
            this.picIsSeen = new System.Windows.Forms.PictureBox();
            this.mnuContextIsSeen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextSeen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextNotSeen = new System.Windows.Forms.ToolStripMenuItem();
            this.lblIMDBRate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.mnuContextRequestCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripRequestCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.repMovie.ItemTemplate.SuspendLayout();
            this.repMovie.SuspendLayout();
			this.mnuContextFavorite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIsSeen)).BeginInit();
            this.mnuContextIsSeen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.mnuContextRequestCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // repMovie
            // 
            this.repMovie.AllowUserToAddItems = false;
            this.repMovie.AllowUserToDeleteItems = false;
            // 
            // repMovie.ItemTemplate
            // 
            this.repMovie.ItemTemplate.Controls.Add(this.lblFavoriteRate);
            this.repMovie.ItemTemplate.Controls.Add(this.picIsSeen);
            this.repMovie.ItemTemplate.Controls.Add(this.lblIMDBRate);
            this.repMovie.ItemTemplate.Controls.Add(this.lblTitle);
            this.repMovie.ItemTemplate.Controls.Add(this.picImage);
            this.repMovie.ItemTemplate.Size = new System.Drawing.Size(227, 279);
            this.repMovie.LayoutStyle = Microsoft.VisualBasic.PowerPacks.DataRepeaterLayoutStyles.Horizontal;
            this.repMovie.Location = new System.Drawing.Point(0, 0);
            this.repMovie.MaximumSize = new System.Drawing.Size(658, 287);
            this.repMovie.MinimumSize = new System.Drawing.Size(658, 287);
            this.repMovie.Name = "repMovie";
            this.repMovie.Size = new System.Drawing.Size(658, 287);
            this.repMovie.TabIndex = 3;
            // 
            // lblFavoriteRate
            // 
            this.lblFavoriteRate.ContextMenuStrip = this.mnuContextFavorite;
            this.lblFavoriteRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFavoriteRate.Image = global::iMovie.Properties.Resources.Favorite_61;
            this.lblFavoriteRate.Location = new System.Drawing.Point(159, 139);
            this.lblFavoriteRate.Name = "lblFavoriteRate";
            this.lblFavoriteRate.Size = new System.Drawing.Size(61, 65);
            this.lblFavoriteRate.TabIndex = 5;
            this.lblFavoriteRate.Text = "-";
            this.lblFavoriteRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.mnuContextNone.Click += new System.EventHandler(this.mnuContextNone_Click);
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
            this.mnuContext1.Click += new System.EventHandler(this.mnuContext1_Click);
            // 
            // mnuContext2
            // 
            this.mnuContext2.Name = "mnuContext2";
            this.mnuContext2.Size = new System.Drawing.Size(78, 22);
            this.mnuContext2.Text = "2";
            this.mnuContext2.Click += new System.EventHandler(this.mnuContext2_Click);
            // 
            // mnuContext3
            // 
            this.mnuContext3.Name = "mnuContext3";
            this.mnuContext3.Size = new System.Drawing.Size(78, 22);
            this.mnuContext3.Text = "3";
            this.mnuContext3.Click += new System.EventHandler(this.mnuContext3_Click);
            // 
            // mnuContext4
            // 
            this.mnuContext4.Name = "mnuContext4";
            this.mnuContext4.Size = new System.Drawing.Size(78, 22);
            this.mnuContext4.Text = "4";
            this.mnuContext4.Click += new System.EventHandler(this.mnuContext4_Click);
            // 
            // mnuContext5
            // 
            this.mnuContext5.Name = "mnuContext5";
            this.mnuContext5.Size = new System.Drawing.Size(78, 22);
            this.mnuContext5.Text = "5";
            this.mnuContext5.Click += new System.EventHandler(this.mnuContext5_Click);
            // 
            // mnuContext6
            // 
            this.mnuContext6.Name = "mnuContext6";
            this.mnuContext6.Size = new System.Drawing.Size(78, 22);
            this.mnuContext6.Text = "6";
            this.mnuContext6.Click += new System.EventHandler(this.mnuContext6_Click);
            // 
            // mnuContext7
            // 
            this.mnuContext7.Name = "mnuContext7";
            this.mnuContext7.Size = new System.Drawing.Size(78, 22);
            this.mnuContext7.Text = "7";
            this.mnuContext7.Click += new System.EventHandler(this.mnuContext7_Click);
            // 
            // mnuContext8
            // 
            this.mnuContext8.Name = "mnuContext8";
            this.mnuContext8.Size = new System.Drawing.Size(78, 22);
            this.mnuContext8.Text = "8";
            this.mnuContext8.Click += new System.EventHandler(this.mnuContext8_Click);
            // 
            // mnuContext9
            // 
            this.mnuContext9.Name = "mnuContext9";
            this.mnuContext9.Size = new System.Drawing.Size(78, 22);
            this.mnuContext9.Text = "9";
            this.mnuContext9.Click += new System.EventHandler(this.mnuContext9_Click);
            // 
            // mnuContext10
            // 
            this.mnuContext10.Name = "mnuContext10";
            this.mnuContext10.Size = new System.Drawing.Size(78, 22);
            this.mnuContext10.Text = "10";
            this.mnuContext10.Click += new System.EventHandler(this.mnuContext10_Click);
            // 
            // picIsSeen
            // 
            this.picIsSeen.ContextMenuStrip = this.mnuContextIsSeen;
            this.picIsSeen.ErrorImage = global::iMovie.Properties.Resources.not_seen_61;
            this.picIsSeen.Image = global::iMovie.Properties.Resources.not_seen_61;
            this.picIsSeen.InitialImage = global::iMovie.Properties.Resources.not_seen_61;
            this.picIsSeen.Location = new System.Drawing.Point(159, 3);
            this.picIsSeen.Name = "picIsSeen";
            this.picIsSeen.Size = new System.Drawing.Size(61, 63);
            this.picIsSeen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picIsSeen.TabIndex = 3;
            this.picIsSeen.TabStop = false;
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
            this.mnuContextSeen.Click += new System.EventHandler(this.mnuContextSeen_Click);
            // 
            // mnuContextNotSeen
            // 
            this.mnuContextNotSeen.Name = "mnuContextNotSeen";
            this.mnuContextNotSeen.Size = new System.Drawing.Size(119, 22);
            this.mnuContextNotSeen.Text = "Not Watched";
            this.mnuContextNotSeen.Click += new System.EventHandler(this.mnuContextNotSeen_Click);
            // 
            // lblIMDBRate
            // 
            this.lblIMDBRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMDBRate.Image = global::iMovie.Properties.Resources.rating_61;
            this.lblIMDBRate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblIMDBRate.Location = new System.Drawing.Point(155, 69);
            this.lblIMDBRate.Name = "lblIMDBRate";
            this.lblIMDBRate.Size = new System.Drawing.Size(68, 66);
            this.lblIMDBRate.TabIndex = 2;
            this.lblIMDBRate.Text = "N/A";
            this.lblIMDBRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(4, 209);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(216, 44);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "N/A";
            this.lblTitle.UseMnemonic = false;
            // 
            // picImage
            // 
            this.picImage.ContextMenuStrip = this.mnuContextRequestCopy;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImage.ErrorImage = global::iMovie.Properties.Resources.no_pic;
            this.picImage.Image = global::iMovie.Properties.Resources.no_pic;
            this.picImage.InitialImage = global::iMovie.Properties.Resources.no_pic;
            this.picImage.Location = new System.Drawing.Point(7, 3);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(145, 197);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // lblCountValue
            // 
            this.lblCountValue.AutoSize = true;
            this.lblCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCountValue.Location = new System.Drawing.Point(45, 295);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(13, 13);
            this.lblCountValue.TabIndex = 7;
            this.lblCountValue.Text = "0";
            this.lblCountValue.Visible = false;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCount.Location = new System.Drawing.Point(1, 294);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(38, 13);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Count:";
            this.lblCount.Visible = false;
            // 
            // mnuContextRequestCopy
            // 
            this.mnuContextRequestCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRequestCopy});
            this.mnuContextRequestCopy.Name = "mnuContextIsSeen";
            this.mnuContextRequestCopy.ShowImageMargin = false;
            this.mnuContextRequestCopy.Size = new System.Drawing.Size(123, 26);
            // 
            // toolStripRequestCopy
            // 
            this.toolStripRequestCopy.Name = "toolStripRequestCopy";
            this.toolStripRequestCopy.Size = new System.Drawing.Size(127, 22);
            this.toolStripRequestCopy.Text = "Request Copy";
            // 
            // ucMovieRepeater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCountValue);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.repMovie);
            this.MaximumSize = new System.Drawing.Size(660, 315);
            this.MinimumSize = new System.Drawing.Size(660, 315);
            this.Name = "ucMovieRepeater";
            this.Size = new System.Drawing.Size(660, 315);
            this.repMovie.ItemTemplate.ResumeLayout(false);
            this.repMovie.ResumeLayout(false);
			this.mnuContextFavorite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIsSeen)).EndInit();
            this.mnuContextIsSeen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.mnuContextRequestCopy.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater repMovie;
        private System.Windows.Forms.Label lblFavoriteRate;
        private System.Windows.Forms.PictureBox picIsSeen;
        private System.Windows.Forms.Label lblIMDBRate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picImage;
        protected System.Windows.Forms.ContextMenuStrip mnuContextFavorite;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextNone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
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
        protected System.Windows.Forms.ContextMenuStrip mnuContextIsSeen;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextSeen;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextNotSeen;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.Label lblCount;
        protected System.Windows.Forms.ContextMenuStrip mnuContextRequestCopy;
        protected System.Windows.Forms.ToolStripMenuItem toolStripRequestCopy;
    }
}
