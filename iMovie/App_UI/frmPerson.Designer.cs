namespace iMovie
{
    partial class frmPerson
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
            this.linkIMDB = new System.Windows.Forms.LinkLabel();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabSummary = new System.Windows.Forms.TabPage();
            this.lblDownValue = new System.Windows.Forms.Label();
            this.lblUpValue = new System.Windows.Forms.Label();
            this.lblDown = new System.Windows.Forms.Label();
            this.lblUp = new System.Windows.Forms.Label();
            this.lblActorName = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.tabDirected = new System.Windows.Forms.TabPage();
            this.repDirected = new iMovie.ucMovieRepeater();
            this.tabActed = new System.Windows.Forms.TabPage();
            this.repActed = new iMovie.ucMovieRepeater();
            this.tab.SuspendLayout();
            this.tabSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.tabDirected.SuspendLayout();
            this.tabActed.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkIMDB
            // 
            this.linkIMDB.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkIMDB.AutoSize = true;
            this.linkIMDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.linkIMDB.Location = new System.Drawing.Point(12, 378);
            this.linkIMDB.Name = "linkIMDB";
            this.linkIMDB.Size = new System.Drawing.Size(90, 17);
            this.linkIMDB.TabIndex = 0;
            this.linkIMDB.TabStop = true;
            this.linkIMDB.Text = "Visit on IMDb";
            this.linkIMDB.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkIMDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIMDB_LinkClicked);
            // 
            // tab
            // 
            this.tab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tab.Controls.Add(this.tabSummary);
            this.tab.Controls.Add(this.tabDirected);
            this.tab.Controls.Add(this.tabActed);
            this.tab.Dock = System.Windows.Forms.DockStyle.Top;
            this.tab.Location = new System.Drawing.Point(0, 24);
            this.tab.Multiline = true;
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(678, 354);
            this.tab.TabIndex = 3;
            // 
            // tabSummary
            // 
            this.tabSummary.BackColor = System.Drawing.SystemColors.Control;
            this.tabSummary.Controls.Add(this.lblDownValue);
            this.tabSummary.Controls.Add(this.lblUpValue);
            this.tabSummary.Controls.Add(this.lblDown);
            this.tabSummary.Controls.Add(this.lblUp);
            this.tabSummary.Controls.Add(this.lblActorName);
            this.tabSummary.Controls.Add(this.picPhoto);
            this.tabSummary.Location = new System.Drawing.Point(4, 25);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabSummary.Size = new System.Drawing.Size(670, 325);
            this.tabSummary.TabIndex = 0;
            this.tabSummary.Text = "Summary";
            // 
            // lblDownValue
            // 
            this.lblDownValue.AutoEllipsis = true;
            this.lblDownValue.Location = new System.Drawing.Point(442, 288);
            this.lblDownValue.Name = "lblDownValue";
            this.lblDownValue.Size = new System.Drawing.Size(124, 23);
            this.lblDownValue.TabIndex = 27;
            this.lblDownValue.Text = "N/A";
            // 
            // lblUpValue
            // 
            this.lblUpValue.AutoEllipsis = true;
            this.lblUpValue.Location = new System.Drawing.Point(442, 261);
            this.lblUpValue.Name = "lblUpValue";
            this.lblUpValue.Size = new System.Drawing.Size(124, 23);
            this.lblUpValue.TabIndex = 26;
            this.lblUpValue.Text = "N/A";
            // 
            // lblDown
            // 
            this.lblDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDown.Location = new System.Drawing.Point(248, 286);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(188, 23);
            this.lblDown.TabIndex = 25;
            this.lblDown.Text = "Number of Movies Acted:";
            this.lblDown.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUp
            // 
            this.lblUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUp.Location = new System.Drawing.Point(248, 259);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(188, 23);
            this.lblUp.TabIndex = 24;
            this.lblUp.Text = "Number of Movies Directed:";
            this.lblUp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblActorName
            // 
            this.lblActorName.AutoEllipsis = true;
            this.lblActorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActorName.Location = new System.Drawing.Point(239, 17);
            this.lblActorName.Name = "lblActorName";
            this.lblActorName.Size = new System.Drawing.Size(404, 115);
            this.lblActorName.TabIndex = 23;
            this.lblActorName.Text = "N/A";
            this.lblActorName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblActorName.UseMnemonic = false;
            // 
            // picPhoto
            // 
            this.picPhoto.ErrorImage = global::iMovie.Properties.Resources.no_pic;
            this.picPhoto.Image = global::iMovie.Properties.Resources.no_pic;
            this.picPhoto.InitialImage = global::iMovie.Properties.Resources.no_pic;
            this.picPhoto.Location = new System.Drawing.Point(24, 16);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(193, 292);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 22;
            this.picPhoto.TabStop = false;
            // 
            // tabDirected
            // 
            this.tabDirected.BackColor = System.Drawing.SystemColors.Control;
            this.tabDirected.Controls.Add(this.repDirected);
            this.tabDirected.Location = new System.Drawing.Point(4, 25);
            this.tabDirected.Name = "tabDirected";
            this.tabDirected.Padding = new System.Windows.Forms.Padding(3);
            this.tabDirected.Size = new System.Drawing.Size(670, 325);
            this.tabDirected.TabIndex = 1;
            this.tabDirected.Text = "Movies Directed";
            // 
            // repDirected
            // 
            this.repDirected.DataSource = new iMovie.Movie[0];
            this.repDirected.EnableRightClickMenu = false;
            this.repDirected.Location = new System.Drawing.Point(6, 6);
            this.repDirected.MaximumSize = new System.Drawing.Size(660, 315);
            this.repDirected.MinimumSize = new System.Drawing.Size(660, 315);
            this.repDirected.Name = "repDirected";
            this.repDirected.RemoveOnNoneFavorite = false;
            this.repDirected.ShowCount = false;
            this.repDirected.Size = new System.Drawing.Size(660, 315);
            this.repDirected.TabIndex = 0;
            // 
            // tabActed
            // 
            this.tabActed.BackColor = System.Drawing.SystemColors.Control;
            this.tabActed.Controls.Add(this.repActed);
            this.tabActed.Location = new System.Drawing.Point(4, 25);
            this.tabActed.Name = "tabActed";
            this.tabActed.Padding = new System.Windows.Forms.Padding(3);
            this.tabActed.Size = new System.Drawing.Size(670, 325);
            this.tabActed.TabIndex = 2;
            this.tabActed.Text = "Movies Acted";
            // 
            // repActed
            // 
            this.repActed.DataSource = new iMovie.Movie[0];
            this.repActed.EnableRightClickMenu = false;
            this.repActed.Location = new System.Drawing.Point(6, 6);
            this.repActed.MaximumSize = new System.Drawing.Size(660, 315);
            this.repActed.MinimumSize = new System.Drawing.Size(660, 315);
            this.repActed.Name = "repActed";
            this.repActed.RemoveOnNoneFavorite = false;
            this.repActed.ShowCount = false;
            this.repActed.Size = new System.Drawing.Size(660, 315);
            this.repActed.TabIndex = 0;
            // 
            // frmPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 407);
            this.Controls.Add(this.linkIMDB);
            this.Controls.Add(this.tab);
            this.Name = "frmPerson";
            this.Text = "Person";
            this.Load += new System.EventHandler(this.frmPerson_Load);
            this.Controls.SetChildIndex(this.tab, 0);
            this.Controls.SetChildIndex(this.linkIMDB, 0);
            this.tab.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.tabDirected.ResumeLayout(false);
            this.tabActed.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkIMDB;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabSummary;
        private System.Windows.Forms.Label lblActorName;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.TabPage tabDirected;
        private System.Windows.Forms.TabPage tabActed;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.Label lblDownValue;
        private System.Windows.Forms.Label lblUpValue;
        private ucMovieRepeater repDirected;
        private ucMovieRepeater repActed;
    }
}