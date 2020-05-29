namespace iMovie
{
    partial class frmOnlineMovieUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOnlineMovieUpdate));
            this.chkIgnore = new System.Windows.Forms.CheckBox();
            this.chkImage = new System.Windows.Forms.CheckBox();
            this.chkRate = new System.Windows.Forms.CheckBox();
            this.chkLink = new System.Windows.Forms.CheckBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkActorPhoto = new System.Windows.Forms.CheckBox();
            this.chkDirectorPhoto = new System.Windows.Forms.CheckBox();
            this.chkLanguage = new System.Windows.Forms.CheckBox();
            this.chkDirector = new System.Windows.Forms.CheckBox();
            this.chkActors = new System.Windows.Forms.CheckBox();
            this.chkGenre = new System.Windows.Forms.CheckBox();
            this.chkStory = new System.Windows.Forms.CheckBox();
            this.chkDuration = new System.Windows.Forms.CheckBox();
            this.chkYear = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.prgUpdate = new System.Windows.Forms.ProgressBar();
            this.lblMovie = new System.Windows.Forms.Label();
            this.chkWarn = new System.Windows.Forms.CheckBox();
            this.grpDateRange = new System.Windows.Forms.GroupBox();
            this.datePickTo = new System.Windows.Forms.DateTimePicker();
            this.datePickFrom = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.grpOptions.SuspendLayout();
            this.grpDateRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkIgnore
            // 
            this.chkIgnore.AutoSize = true;
            this.chkIgnore.Checked = true;
            this.chkIgnore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnore.Location = new System.Drawing.Point(5, 209);
            this.chkIgnore.Name = "chkIgnore";
            this.chkIgnore.Size = new System.Drawing.Size(228, 17);
            this.chkIgnore.TabIndex = 1;
            this.chkIgnore.Text = "Do not update fields that have valid values";
            this.chkIgnore.UseVisualStyleBackColor = true;
            this.chkIgnore.CheckedChanged += new System.EventHandler(this.chkIgnore_CheckedChanged);
            // 
            // chkImage
            // 
            this.chkImage.AutoSize = true;
            this.chkImage.Location = new System.Drawing.Point(21, 22);
            this.chkImage.Name = "chkImage";
            this.chkImage.Size = new System.Drawing.Size(87, 17);
            this.chkImage.TabIndex = 2;
            this.chkImage.Text = "Movie poster";
            this.chkImage.UseVisualStyleBackColor = true;
            this.chkImage.CheckedChanged += new System.EventHandler(this.chkImage_CheckedChanged);
            // 
            // chkRate
            // 
            this.chkRate.AutoSize = true;
            this.chkRate.Checked = true;
            this.chkRate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRate.Location = new System.Drawing.Point(148, 22);
            this.chkRate.Name = "chkRate";
            this.chkRate.Size = new System.Drawing.Size(73, 17);
            this.chkRate.TabIndex = 3;
            this.chkRate.Text = "IMDb rate";
            this.chkRate.UseVisualStyleBackColor = true;
            // 
            // chkLink
            // 
            this.chkLink.AutoSize = true;
            this.chkLink.Checked = true;
            this.chkLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLink.Location = new System.Drawing.Point(148, 46);
            this.chkLink.Name = "chkLink";
            this.chkLink.Size = new System.Drawing.Size(98, 17);
            this.chkLink.TabIndex = 4;
            this.chkLink.Text = "IMDb page link";
            this.chkLink.UseVisualStyleBackColor = true;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkActorPhoto);
            this.grpOptions.Controls.Add(this.chkDirectorPhoto);
            this.grpOptions.Controls.Add(this.chkLanguage);
            this.grpOptions.Controls.Add(this.chkDirector);
            this.grpOptions.Controls.Add(this.chkActors);
            this.grpOptions.Controls.Add(this.chkGenre);
            this.grpOptions.Controls.Add(this.chkStory);
            this.grpOptions.Controls.Add(this.chkDuration);
            this.grpOptions.Controls.Add(this.chkYear);
            this.grpOptions.Controls.Add(this.chkLink);
            this.grpOptions.Controls.Add(this.chkImage);
            this.grpOptions.Controls.Add(this.chkRate);
            this.grpOptions.Location = new System.Drawing.Point(5, 83);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(381, 122);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "What to update:";
            // 
            // chkActorPhoto
            // 
            this.chkActorPhoto.AutoSize = true;
            this.chkActorPhoto.Location = new System.Drawing.Point(272, 96);
            this.chkActorPhoto.Name = "chkActorPhoto";
            this.chkActorPhoto.Size = new System.Drawing.Size(86, 17);
            this.chkActorPhoto.TabIndex = 13;
            this.chkActorPhoto.Text = "Actors photo";
            this.chkActorPhoto.UseVisualStyleBackColor = true;
            this.chkActorPhoto.CheckedChanged += new System.EventHandler(this.chkActorPhoto_CheckedChanged);
            // 
            // chkDirectorPhoto
            // 
            this.chkDirectorPhoto.AutoSize = true;
            this.chkDirectorPhoto.Location = new System.Drawing.Point(21, 96);
            this.chkDirectorPhoto.Name = "chkDirectorPhoto";
            this.chkDirectorPhoto.Size = new System.Drawing.Size(98, 17);
            this.chkDirectorPhoto.TabIndex = 12;
            this.chkDirectorPhoto.Text = "Directors photo";
            this.chkDirectorPhoto.UseVisualStyleBackColor = true;
            this.chkDirectorPhoto.CheckedChanged += new System.EventHandler(this.chkDirectorPhoto_CheckedChanged);
            // 
            // chkLanguage
            // 
            this.chkLanguage.AutoSize = true;
            this.chkLanguage.Checked = true;
            this.chkLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLanguage.Location = new System.Drawing.Point(148, 71);
            this.chkLanguage.Name = "chkLanguage";
            this.chkLanguage.Size = new System.Drawing.Size(79, 17);
            this.chkLanguage.TabIndex = 11;
            this.chkLanguage.Text = "Languages";
            this.chkLanguage.UseVisualStyleBackColor = true;
            // 
            // chkDirector
            // 
            this.chkDirector.AutoSize = true;
            this.chkDirector.Checked = true;
            this.chkDirector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDirector.Location = new System.Drawing.Point(272, 71);
            this.chkDirector.Name = "chkDirector";
            this.chkDirector.Size = new System.Drawing.Size(68, 17);
            this.chkDirector.TabIndex = 10;
            this.chkDirector.Text = "Directors";
            this.chkDirector.UseVisualStyleBackColor = true;
            // 
            // chkActors
            // 
            this.chkActors.AutoSize = true;
            this.chkActors.Checked = true;
            this.chkActors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActors.Location = new System.Drawing.Point(148, 96);
            this.chkActors.Name = "chkActors";
            this.chkActors.Size = new System.Drawing.Size(56, 17);
            this.chkActors.TabIndex = 9;
            this.chkActors.Text = "Actors";
            this.chkActors.UseVisualStyleBackColor = true;
            // 
            // chkGenre
            // 
            this.chkGenre.AutoSize = true;
            this.chkGenre.Checked = true;
            this.chkGenre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenre.Location = new System.Drawing.Point(21, 71);
            this.chkGenre.Name = "chkGenre";
            this.chkGenre.Size = new System.Drawing.Size(60, 17);
            this.chkGenre.TabIndex = 8;
            this.chkGenre.Text = "Genres";
            this.chkGenre.UseVisualStyleBackColor = true;
            // 
            // chkStory
            // 
            this.chkStory.AutoSize = true;
            this.chkStory.Checked = true;
            this.chkStory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStory.Location = new System.Drawing.Point(272, 22);
            this.chkStory.Name = "chkStory";
            this.chkStory.Size = new System.Drawing.Size(66, 17);
            this.chkStory.TabIndex = 7;
            this.chkStory.Text = "Storyline";
            this.chkStory.UseVisualStyleBackColor = true;
            // 
            // chkDuration
            // 
            this.chkDuration.AutoSize = true;
            this.chkDuration.Checked = true;
            this.chkDuration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDuration.Location = new System.Drawing.Point(272, 46);
            this.chkDuration.Name = "chkDuration";
            this.chkDuration.Size = new System.Drawing.Size(66, 17);
            this.chkDuration.TabIndex = 6;
            this.chkDuration.Text = "Duration";
            this.chkDuration.UseVisualStyleBackColor = true;
            // 
            // chkYear
            // 
            this.chkYear.AutoSize = true;
            this.chkYear.Checked = true;
            this.chkYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkYear.Location = new System.Drawing.Point(21, 46);
            this.chkYear.Name = "chkYear";
            this.chkYear.Size = new System.Drawing.Size(88, 17);
            this.chkYear.TabIndex = 5;
            this.chkYear.Text = "Release year";
            this.chkYear.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(304, 289);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 31);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // prgUpdate
            // 
            this.prgUpdate.Location = new System.Drawing.Point(5, 290);
            this.prgUpdate.Name = "prgUpdate";
            this.prgUpdate.Size = new System.Drawing.Size(293, 28);
            this.prgUpdate.Step = 1;
            this.prgUpdate.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgUpdate.TabIndex = 8;
            // 
            // lblMovie
            // 
            this.lblMovie.AutoEllipsis = true;
            this.lblMovie.Location = new System.Drawing.Point(3, 253);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(383, 31);
            this.lblMovie.TabIndex = 100;
            this.lblMovie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMovie.UseMnemonic = false;
            // 
            // chkWarn
            // 
            this.chkWarn.AutoSize = true;
            this.chkWarn.Location = new System.Drawing.Point(5, 230);
            this.chkWarn.Name = "chkWarn";
            this.chkWarn.Size = new System.Drawing.Size(169, 17);
            this.chkWarn.TabIndex = 101;
            this.chkWarn.Text = "Warn about connection status";
            this.chkWarn.UseVisualStyleBackColor = true;
            // 
            // grpDateRange
            // 
            this.grpDateRange.Controls.Add(this.datePickTo);
            this.grpDateRange.Controls.Add(this.datePickFrom);
            this.grpDateRange.Controls.Add(this.lblToDate);
            this.grpDateRange.Controls.Add(this.lblFromDate);
            this.grpDateRange.Location = new System.Drawing.Point(5, 1);
            this.grpDateRange.Name = "grpDateRange";
            this.grpDateRange.Size = new System.Drawing.Size(381, 81);
            this.grpDateRange.TabIndex = 102;
            this.grpDateRange.TabStop = false;
            this.grpDateRange.Text = "Archive date range:";
            // 
            // datePickTo
            // 
            this.datePickTo.CustomFormat = "yyyy-MM-dd   HH:mm:ss";
            this.datePickTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickTo.Location = new System.Drawing.Point(69, 47);
            this.datePickTo.Name = "datePickTo";
            this.datePickTo.ShowCheckBox = true;
            this.datePickTo.Size = new System.Drawing.Size(162, 20);
            this.datePickTo.TabIndex = 104;
            // 
            // datePickFrom
            // 
            this.datePickFrom.CustomFormat = "yyyy-MM-dd   HH:mm:ss";
            this.datePickFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickFrom.Location = new System.Drawing.Point(69, 21);
            this.datePickFrom.Name = "datePickFrom";
            this.datePickFrom.ShowCheckBox = true;
            this.datePickFrom.Size = new System.Drawing.Size(162, 20);
            this.datePickFrom.TabIndex = 103;
            this.datePickFrom.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoEllipsis = true;
            this.lblToDate.Location = new System.Drawing.Point(24, 45);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(38, 23);
            this.lblToDate.TabIndex = 102;
            this.lblToDate.Text = "To:";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblToDate.UseMnemonic = false;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoEllipsis = true;
            this.lblFromDate.Location = new System.Drawing.Point(14, 18);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(38, 23);
            this.lblFromDate.TabIndex = 101;
            this.lblFromDate.Text = "From:";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFromDate.UseMnemonic = false;
            // 
            // frmOnlineMovieUpdate
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 324);
            this.Controls.Add(this.grpDateRange);
            this.Controls.Add(this.chkWarn);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.prgUpdate);
            this.Controls.Add(this.chkIgnore);
            this.Controls.Add(this.grpOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOnlineMovieUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Movie Update";
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpDateRange.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIgnore;
        private System.Windows.Forms.CheckBox chkImage;
        private System.Windows.Forms.CheckBox chkRate;
        private System.Windows.Forms.CheckBox chkLink;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ProgressBar prgUpdate;
        private System.Windows.Forms.CheckBox chkDuration;
        private System.Windows.Forms.CheckBox chkYear;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.CheckBox chkStory;
        private System.Windows.Forms.CheckBox chkGenre;
        private System.Windows.Forms.CheckBox chkLanguage;
        private System.Windows.Forms.CheckBox chkDirector;
        private System.Windows.Forms.CheckBox chkActors;
        private System.Windows.Forms.CheckBox chkDirectorPhoto;
        private System.Windows.Forms.CheckBox chkActorPhoto;
        private System.Windows.Forms.CheckBox chkWarn;
        private System.Windows.Forms.GroupBox grpDateRange;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker datePickTo;
        private System.Windows.Forms.DateTimePicker datePickFrom;
    }
}