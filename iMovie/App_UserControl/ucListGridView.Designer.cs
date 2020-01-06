namespace iMovie
{
    partial class ucListGridView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.mnuContextRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextRequestCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextForceUpdateOnline = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextUpdateURL = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblUpdate = new System.Windows.Forms.Label();
            this.dgvSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvGenreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDirectorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvActorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhotoLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMovieName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProductYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIMDBRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvArchiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIsSeen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOriginalQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.mnuContextRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(10, 31);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 0;
            this.chkAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.ForeColor = System.Drawing.Color.Silver;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(167, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSelected,
            this.dgvGenreName,
            this.dgvDirectorName,
            this.dgvActorName,
            this.dgvPhotoLink,
            this.dgvMovieName,
            this.dgvProductYear,
            this.dgvIMDBRate,
            this.dgvDuration,
            this.dgvQuality,
            this.dgvArchiveDate,
            this.dgvIsSeen,
            this.dgvID,
            this.dgvOriginalQuality});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgv.Location = new System.Drawing.Point(0, 26);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.ShowCellErrors = false;
            this.dgv.ShowEditingIcon = false;
            this.dgv.ShowRowErrors = false;
            this.dgv.Size = new System.Drawing.Size(167, 273);
            this.dgv.TabIndex = 1;
            // 
            // mnuContextRight
            // 
            this.mnuContextRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextRequestCopy,
            this.mnuContextDeleteItem,
            this.mnuContextRemove,
            this.mnuContextUpdate,
            this.mnuContextForceUpdateOnline,
            this.mnuContextUpdateURL});
            this.mnuContextRight.Name = "mnuContextDelete";
            this.mnuContextRight.ShowImageMargin = false;
            this.mnuContextRight.Size = new System.Drawing.Size(175, 136);
            // 
            // mnuContextRequestCopy
            // 
            this.mnuContextRequestCopy.Name = "mnuContextRequestCopy";
            this.mnuContextRequestCopy.Size = new System.Drawing.Size(174, 22);
            this.mnuContextRequestCopy.Text = "Request Copy";
            this.mnuContextRequestCopy.Click += new System.EventHandler(this.mnuContextRequestCopy_Click);
            // 
            // mnuContextDeleteItem
            // 
            this.mnuContextDeleteItem.Name = "mnuContextDeleteItem";
            this.mnuContextDeleteItem.Size = new System.Drawing.Size(174, 22);
            this.mnuContextDeleteItem.Text = "Delete";
            this.mnuContextDeleteItem.Click += new System.EventHandler(this.mnuContextDeleteItem_Click);
            // 
            // mnuContextRemove
            // 
            this.mnuContextRemove.Name = "mnuContextRemove";
            this.mnuContextRemove.Size = new System.Drawing.Size(174, 22);
            this.mnuContextRemove.Text = "Remove";
            this.mnuContextRemove.Click += new System.EventHandler(this.mnuContextRemove_Click);
            // 
            // mnuContextUpdate
            // 
            this.mnuContextUpdate.Name = "mnuContextUpdate";
            this.mnuContextUpdate.Size = new System.Drawing.Size(174, 22);
            this.mnuContextUpdate.Text = "Update";
            this.mnuContextUpdate.Click += new System.EventHandler(this.mnuContextUpdate_Click);
            // 
            // mnuContextForceUpdateOnline
            // 
            this.mnuContextForceUpdateOnline.Name = "mnuContextForceUpdateOnline";
            this.mnuContextForceUpdateOnline.Size = new System.Drawing.Size(174, 22);
            this.mnuContextForceUpdateOnline.Text = "Force Update";
            this.mnuContextForceUpdateOnline.Click += new System.EventHandler(this.mnuContextForceUpdateOnline_Click);
            // 
            // mnuContextUpdateURL
            // 
            this.mnuContextUpdateURL.Name = "mnuContextUpdateURL";
            this.mnuContextUpdateURL.Size = new System.Drawing.Size(174, 22);
            this.mnuContextUpdateURL.Text = "Force Update From URL";
            this.mnuContextUpdateURL.Click += new System.EventHandler(this.mnuContextUpdateURL_Click);
            // 
            // lblCountValue
            // 
            this.lblCountValue.Location = new System.Drawing.Point(40, 0);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(50, 17);
            this.lblCountValue.TabIndex = 10;
            this.lblCountValue.Text = "0";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(-3, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(38, 13);
            this.lblCount.TabIndex = 9;
            this.lblCount.Text = "Count:";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 300;
            this.toolTip.ReshowDelay = 100;
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdate.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblUpdate.Image = global::iMovie.Properties.Resources.update_60_X_20__2_;
            this.lblUpdate.Location = new System.Drawing.Point(-65, 0);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(60, 20);
            this.lblUpdate.TabIndex = 11;
            this.toolTip.SetToolTip(this.lblUpdate, "Updating...");
            this.lblUpdate.Visible = false;
            // 
            // dgvSelected
            // 
            this.dgvSelected.FalseValue = "0";
            this.dgvSelected.HeaderText = "";
            this.dgvSelected.Name = "dgvSelected";
            this.dgvSelected.ReadOnly = true;
            this.dgvSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelected.TrueValue = "1";
            this.dgvSelected.Visible = false;
            this.dgvSelected.Width = 30;
            // 
            // dgvGenreName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvGenreName.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGenreName.HeaderText = "Genre Name";
            this.dgvGenreName.Name = "dgvGenreName";
            this.dgvGenreName.ReadOnly = true;
            this.dgvGenreName.Visible = false;
            this.dgvGenreName.Width = 134;
            // 
            // dgvDirectorName
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDirectorName.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDirectorName.HeaderText = "Director Name";
            this.dgvDirectorName.Name = "dgvDirectorName";
            this.dgvDirectorName.ReadOnly = true;
            this.dgvDirectorName.Visible = false;
            this.dgvDirectorName.Width = 134;
            // 
            // dgvActorName
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvActorName.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvActorName.HeaderText = "Actor Name";
            this.dgvActorName.Name = "dgvActorName";
            this.dgvActorName.ReadOnly = true;
            this.dgvActorName.Visible = false;
            this.dgvActorName.Width = 134;
            // 
            // dgvPhotoLink
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhotoLink.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPhotoLink.HeaderText = "Photo Link";
            this.dgvPhotoLink.Name = "dgvPhotoLink";
            this.dgvPhotoLink.ReadOnly = true;
            this.dgvPhotoLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvPhotoLink.Visible = false;
            // 
            // dgvMovieName
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMovieName.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMovieName.HeaderText = "Movie Title";
            this.dgvMovieName.Name = "dgvMovieName";
            this.dgvMovieName.ReadOnly = true;
            this.dgvMovieName.Visible = false;
            this.dgvMovieName.Width = 200;
            // 
            // dgvProductYear
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "-";
            this.dgvProductYear.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProductYear.HeaderText = "Release Year";
            this.dgvProductYear.Name = "dgvProductYear";
            this.dgvProductYear.ReadOnly = true;
            this.dgvProductYear.Visible = false;
            this.dgvProductYear.Width = 80;
            // 
            // dgvIMDBRate
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvIMDBRate.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvIMDBRate.HeaderText = "IMDb Rate";
            this.dgvIMDBRate.Name = "dgvIMDBRate";
            this.dgvIMDBRate.ReadOnly = true;
            this.dgvIMDBRate.Visible = false;
            this.dgvIMDBRate.Width = 80;
            // 
            // dgvDuration
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDuration.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDuration.HeaderText = "Duration";
            this.dgvDuration.Name = "dgvDuration";
            this.dgvDuration.ReadOnly = true;
            this.dgvDuration.Visible = false;
            this.dgvDuration.Width = 90;
            // 
            // dgvQuality
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvQuality.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvQuality.HeaderText = "Quality";
            this.dgvQuality.Name = "dgvQuality";
            this.dgvQuality.ReadOnly = true;
            this.dgvQuality.Visible = false;
            this.dgvQuality.Width = 70;
            // 
            // dgvArchiveDate
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvArchiveDate.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvArchiveDate.HeaderText = "Date Archived";
            this.dgvArchiveDate.Name = "dgvArchiveDate";
            this.dgvArchiveDate.ReadOnly = true;
            this.dgvArchiveDate.Visible = false;
            this.dgvArchiveDate.Width = 110;
            // 
            // dgvIsSeen
            // 
            this.dgvIsSeen.FalseValue = "0";
            this.dgvIsSeen.HeaderText = "Watched";
            this.dgvIsSeen.Name = "dgvIsSeen";
            this.dgvIsSeen.ReadOnly = true;
            this.dgvIsSeen.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIsSeen.TrueValue = "1";
            this.dgvIsSeen.Visible = false;
            this.dgvIsSeen.Width = 83;
            // 
            // dgvID
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvID.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvID.HeaderText = "ID";
            this.dgvID.Name = "dgvID";
            this.dgvID.ReadOnly = true;
            this.dgvID.Visible = false;
            // 
            // dgvOriginalQuality
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvOriginalQuality.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvOriginalQuality.HeaderText = "Original Quality";
            this.dgvOriginalQuality.Name = "dgvOriginalQuality";
            this.dgvOriginalQuality.ReadOnly = true;
            this.dgvOriginalQuality.Visible = false;
            // 
            // ucListGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblCountValue);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgv);
            this.Name = "ucListGridView";
            this.Size = new System.Drawing.Size(169, 304);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.mnuContextRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ContextMenuStrip mnuContextRight;
        private System.Windows.Forms.ToolStripMenuItem mnuContextDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem mnuContextForceUpdateOnline;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.ToolTip toolTip;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextUpdate;
        protected System.Windows.Forms.ToolStripMenuItem mnuContextUpdateURL;
        private System.Windows.Forms.ToolStripMenuItem mnuContextRequestCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuContextRemove;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGenreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDirectorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvActorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhotoLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMovieName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProductYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIMDBRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvArchiveDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvIsSeen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOriginalQuality;
    }
}
