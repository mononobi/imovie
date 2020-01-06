namespace iMovie
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpSuggest = new System.Windows.Forms.GroupBox();
            this.dropPreset = new System.Windows.Forms.ComboBox();
            this.chkFavorite = new System.Windows.Forms.CheckBox();
            this.lblSuggestCount = new System.Windows.Forms.Label();
            this.chkSeen = new System.Windows.Forms.CheckBox();
            this.chkNotSeen = new System.Windows.Forms.CheckBox();
            this.txtCount = new System.Windows.Forms.NumericUpDown();
            this.btnAdvanceSuggest = new System.Windows.Forms.Button();
            this.btnQuick = new System.Windows.Forms.Button();
            this.grpPlace = new System.Windows.Forms.GroupBox();
            this.btnActorList = new System.Windows.Forms.Button();
            this.btnDirectorList = new System.Windows.Forms.Button();
            this.btnMovieList = new System.Windows.Forms.Button();
            this.grpSuggest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount)).BeginInit();
            this.grpPlace.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSuggest
            // 
            this.grpSuggest.Controls.Add(this.dropPreset);
            this.grpSuggest.Controls.Add(this.chkFavorite);
            this.grpSuggest.Controls.Add(this.lblSuggestCount);
            this.grpSuggest.Controls.Add(this.chkSeen);
            this.grpSuggest.Controls.Add(this.chkNotSeen);
            this.grpSuggest.Controls.Add(this.txtCount);
            this.grpSuggest.Controls.Add(this.btnAdvanceSuggest);
            this.grpSuggest.Controls.Add(this.btnQuick);
            this.grpSuggest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpSuggest.Location = new System.Drawing.Point(8, 28);
            this.grpSuggest.Name = "grpSuggest";
            this.grpSuggest.Size = new System.Drawing.Size(397, 151);
            this.grpSuggest.TabIndex = 9;
            this.grpSuggest.TabStop = false;
            this.grpSuggest.Text = "Suggest Movies:";
            // 
            // dropPreset
            // 
            this.dropPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropPreset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dropPreset.FormattingEnabled = true;
            this.dropPreset.Items.AddRange(new object[] {
            "All Movies",
            "Top Movies",
            "High Rated Movies",
            "High Quality Movies",
            "Recent Movies",
            "Old Movies",
            "Short Movies",
            "Long Movies"});
            this.dropPreset.Location = new System.Drawing.Point(223, 25);
            this.dropPreset.MaxDropDownItems = 21;
            this.dropPreset.Name = "dropPreset";
            this.dropPreset.Size = new System.Drawing.Size(160, 24);
            this.dropPreset.TabIndex = 1;
            // 
            // chkFavorite
            // 
            this.chkFavorite.AutoSize = true;
            this.chkFavorite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkFavorite.Location = new System.Drawing.Point(13, 71);
            this.chkFavorite.Name = "chkFavorite";
            this.chkFavorite.Size = new System.Drawing.Size(135, 17);
            this.chkFavorite.TabIndex = 3;
            this.chkFavorite.Text = "Include favorite movies";
            this.chkFavorite.UseVisualStyleBackColor = true;
            // 
            // lblSuggestCount
            // 
            this.lblSuggestCount.AutoSize = true;
            this.lblSuggestCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSuggestCount.Location = new System.Drawing.Point(10, 29);
            this.lblSuggestCount.Name = "lblSuggestCount";
            this.lblSuggestCount.Size = new System.Drawing.Size(94, 13);
            this.lblSuggestCount.TabIndex = 5;
            this.lblSuggestCount.Text = "Suggestion Count:";
            // 
            // chkSeen
            // 
            this.chkSeen.AutoSize = true;
            this.chkSeen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkSeen.Location = new System.Drawing.Point(13, 96);
            this.chkSeen.Name = "chkSeen";
            this.chkSeen.Size = new System.Drawing.Size(141, 17);
            this.chkSeen.TabIndex = 4;
            this.chkSeen.Text = "Include watched movies";
            this.chkSeen.UseVisualStyleBackColor = true;
            this.chkSeen.CheckedChanged += new System.EventHandler(this.chkSeen_CheckedChanged);
            // 
            // chkNotSeen
            // 
            this.chkNotSeen.AutoSize = true;
            this.chkNotSeen.Checked = true;
            this.chkNotSeen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotSeen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkNotSeen.Location = new System.Drawing.Point(13, 121);
            this.chkNotSeen.Name = "chkNotSeen";
            this.chkNotSeen.Size = new System.Drawing.Size(153, 17);
            this.chkNotSeen.TabIndex = 5;
            this.chkNotSeen.Text = "Include unwatched movies";
            this.chkNotSeen.UseVisualStyleBackColor = true;
            this.chkNotSeen.CheckedChanged += new System.EventHandler(this.chkNotSeen_CheckedChanged);
            // 
            // txtCount
            // 
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.Location = new System.Drawing.Point(110, 25);
            this.txtCount.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(56, 23);
            this.txtCount.TabIndex = 2;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAdvanceSuggest
            // 
            this.btnAdvanceSuggest.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdvanceSuggest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdvanceSuggest.Location = new System.Drawing.Point(223, 98);
            this.btnAdvanceSuggest.Name = "btnAdvanceSuggest";
            this.btnAdvanceSuggest.Size = new System.Drawing.Size(160, 40);
            this.btnAdvanceSuggest.TabIndex = 6;
            this.btnAdvanceSuggest.Text = "Advanced Mode";
            this.btnAdvanceSuggest.UseVisualStyleBackColor = true;
            this.btnAdvanceSuggest.Click += new System.EventHandler(this.btnAdvanceSuggest_Click);
            // 
            // btnQuick
            // 
            this.btnQuick.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuick.Location = new System.Drawing.Point(223, 56);
            this.btnQuick.Name = "btnQuick";
            this.btnQuick.Size = new System.Drawing.Size(160, 40);
            this.btnQuick.TabIndex = 0;
            this.btnQuick.Text = "Suggest Now";
            this.btnQuick.UseVisualStyleBackColor = true;
            this.btnQuick.Click += new System.EventHandler(this.btnQuick_Click);
            // 
            // grpPlace
            // 
            this.grpPlace.Controls.Add(this.btnActorList);
            this.grpPlace.Controls.Add(this.btnDirectorList);
            this.grpPlace.Controls.Add(this.btnMovieList);
            this.grpPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grpPlace.Location = new System.Drawing.Point(8, 185);
            this.grpPlace.Name = "grpPlace";
            this.grpPlace.Size = new System.Drawing.Size(397, 67);
            this.grpPlace.TabIndex = 10;
            this.grpPlace.TabStop = false;
            this.grpPlace.Text = "Places:";
            // 
            // btnActorList
            // 
            this.btnActorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnActorList.Location = new System.Drawing.Point(292, 22);
            this.btnActorList.Name = "btnActorList";
            this.btnActorList.Size = new System.Drawing.Size(91, 34);
            this.btnActorList.TabIndex = 9;
            this.btnActorList.Text = "Actors";
            this.btnActorList.UseVisualStyleBackColor = true;
            this.btnActorList.Click += new System.EventHandler(this.btnActorList_Click);
            // 
            // btnDirectorList
            // 
            this.btnDirectorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDirectorList.Location = new System.Drawing.Point(153, 22);
            this.btnDirectorList.Name = "btnDirectorList";
            this.btnDirectorList.Size = new System.Drawing.Size(91, 34);
            this.btnDirectorList.TabIndex = 8;
            this.btnDirectorList.Text = "Directors";
            this.btnDirectorList.UseVisualStyleBackColor = true;
            this.btnDirectorList.Click += new System.EventHandler(this.btnDirectorList_Click);
            // 
            // btnMovieList
            // 
            this.btnMovieList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMovieList.Location = new System.Drawing.Point(13, 22);
            this.btnMovieList.Name = "btnMovieList";
            this.btnMovieList.Size = new System.Drawing.Size(91, 34);
            this.btnMovieList.TabIndex = 7;
            this.btnMovieList.Text = "Movies";
            this.btnMovieList.UseVisualStyleBackColor = true;
            this.btnMovieList.Click += new System.EventHandler(this.btnMovieList_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnQuick;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 261);
            this.Controls.Add(this.grpPlace);
            this.Controls.Add(this.grpSuggest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "iMovie - Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Controls.SetChildIndex(this.grpSuggest, 0);
            this.Controls.SetChildIndex(this.grpPlace, 0);
            this.grpSuggest.ResumeLayout(false);
            this.grpSuggest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount)).EndInit();
            this.grpPlace.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSuggest;
        private System.Windows.Forms.Button btnQuick;
        private System.Windows.Forms.Button btnAdvanceSuggest;
        private System.Windows.Forms.NumericUpDown txtCount;
        private System.Windows.Forms.CheckBox chkSeen;
        private System.Windows.Forms.CheckBox chkNotSeen;
        private System.Windows.Forms.Label lblSuggestCount;
        private System.Windows.Forms.GroupBox grpPlace;
        private System.Windows.Forms.Button btnActorList;
        private System.Windows.Forms.Button btnDirectorList;
        private System.Windows.Forms.Button btnMovieList;
        private System.Windows.Forms.CheckBox chkFavorite;
        private System.Windows.Forms.ComboBox dropPreset;
    }
}