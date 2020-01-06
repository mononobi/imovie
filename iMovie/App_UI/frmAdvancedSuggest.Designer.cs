namespace iMovie
{
    partial class frmAdvancedSuggest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvancedSuggest));
            this.tabSuggest = new System.Windows.Forms.TabControl();
            this.tabBase = new System.Windows.Forms.TabPage();
            this.grpPreset = new System.Windows.Forms.GroupBox();
            this.dropPreset = new System.Windows.Forms.ComboBox();
            this.lblPreset = new System.Windows.Forms.Label();
            this.grpLanguage = new System.Windows.Forms.GroupBox();
            this.radAnyLanguage = new System.Windows.Forms.RadioButton();
            this.radExactLanguage = new System.Windows.Forms.RadioButton();
            this.chkLanguage = new iMovie.ucCheckBoxList();
            this.grpRange = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDurationUp = new System.Windows.Forms.MaskedTextBox();
            this.txtProductUp = new System.Windows.Forms.MaskedTextBox();
            this.dropRateUp = new System.Windows.Forms.ComboBox();
            this.txtDurationLow = new System.Windows.Forms.MaskedTextBox();
            this.txtProductLow = new System.Windows.Forms.MaskedTextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.dropRateLow = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.grpQuality = new System.Windows.Forms.GroupBox();
            this.chkQuality = new iMovie.ucCheckBoxList();
            this.grpBase = new System.Windows.Forms.GroupBox();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.chkNotSeen = new System.Windows.Forms.CheckBox();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.chkSeen = new System.Windows.Forms.CheckBox();
            this.chkFavorite = new System.Windows.Forms.CheckBox();
            this.txtCount = new System.Windows.Forms.NumericUpDown();
            this.lblCount = new System.Windows.Forms.Label();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.grpActor = new System.Windows.Forms.GroupBox();
            this.radAnyActor = new System.Windows.Forms.RadioButton();
            this.radExactActor = new System.Windows.Forms.RadioButton();
            this.dgvActor = new iMovie.ucListGridView();
            this.grpDirector = new System.Windows.Forms.GroupBox();
            this.radAnyDirector = new System.Windows.Forms.RadioButton();
            this.radExactDirector = new System.Windows.Forms.RadioButton();
            this.dgvDirector = new iMovie.ucListGridView();
            this.grpGenre = new System.Windows.Forms.GroupBox();
            this.radAnyGenre = new System.Windows.Forms.RadioButton();
            this.radExactGenre = new System.Windows.Forms.RadioButton();
            this.dgvGenre = new iMovie.ucListGridView();
            this.tabExcluded = new System.Windows.Forms.TabPage();
            this.pathListBox = new iMovie.ucPathListBox();
            this.btnView = new System.Windows.Forms.Button();
            this.dataGridViewColumn1 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn2 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn3 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn4 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn5 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn6 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn7 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn8 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn9 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn10 = new System.Windows.Forms.DataGridViewColumn();
            this.dataGridViewColumn11 = new System.Windows.Forms.DataGridViewColumn();
            this.tabSuggest.SuspendLayout();
            this.tabBase.SuspendLayout();
            this.grpPreset.SuspendLayout();
            this.grpLanguage.SuspendLayout();
            this.grpRange.SuspendLayout();
            this.grpQuality.SuspendLayout();
            this.grpBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount)).BeginInit();
            this.tabDetail.SuspendLayout();
            this.grpActor.SuspendLayout();
            this.grpDirector.SuspendLayout();
            this.grpGenre.SuspendLayout();
            this.tabExcluded.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSuggest
            // 
            this.tabSuggest.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSuggest.Controls.Add(this.tabBase);
            this.tabSuggest.Controls.Add(this.tabDetail);
            this.tabSuggest.Controls.Add(this.tabExcluded);
            this.tabSuggest.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSuggest.HotTrack = true;
            this.tabSuggest.Location = new System.Drawing.Point(0, 24);
            this.tabSuggest.Name = "tabSuggest";
            this.tabSuggest.SelectedIndex = 0;
            this.tabSuggest.Size = new System.Drawing.Size(612, 386);
            this.tabSuggest.TabIndex = 15;
            // 
            // tabBase
            // 
            this.tabBase.BackColor = System.Drawing.SystemColors.Control;
            this.tabBase.Controls.Add(this.grpPreset);
            this.tabBase.Controls.Add(this.grpLanguage);
            this.tabBase.Controls.Add(this.grpRange);
            this.tabBase.Controls.Add(this.grpQuality);
            this.tabBase.Controls.Add(this.grpBase);
            this.tabBase.Location = new System.Drawing.Point(4, 25);
            this.tabBase.Name = "tabBase";
            this.tabBase.Padding = new System.Windows.Forms.Padding(3);
            this.tabBase.Size = new System.Drawing.Size(604, 357);
            this.tabBase.TabIndex = 0;
            this.tabBase.Text = "Basics";
            // 
            // grpPreset
            // 
            this.grpPreset.Controls.Add(this.dropPreset);
            this.grpPreset.Controls.Add(this.lblPreset);
            this.grpPreset.Location = new System.Drawing.Point(306, 9);
            this.grpPreset.Name = "grpPreset";
            this.grpPreset.Size = new System.Drawing.Size(277, 58);
            this.grpPreset.TabIndex = 20;
            this.grpPreset.TabStop = false;
            this.grpPreset.Text = "Presets:";
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
            this.dropPreset.Location = new System.Drawing.Point(78, 22);
            this.dropPreset.MaxDropDownItems = 21;
            this.dropPreset.Name = "dropPreset";
            this.dropPreset.Size = new System.Drawing.Size(172, 21);
            this.dropPreset.TabIndex = 0;
            this.dropPreset.SelectedIndexChanged += new System.EventHandler(this.dropPreset_SelectedIndexChanged);
            // 
            // lblPreset
            // 
            this.lblPreset.AutoSize = true;
            this.lblPreset.Location = new System.Drawing.Point(23, 25);
            this.lblPreset.Name = "lblPreset";
            this.lblPreset.Size = new System.Drawing.Size(40, 13);
            this.lblPreset.TabIndex = 6;
            this.lblPreset.Text = "Preset:";
            // 
            // grpLanguage
            // 
            this.grpLanguage.Controls.Add(this.radAnyLanguage);
            this.grpLanguage.Controls.Add(this.radExactLanguage);
            this.grpLanguage.Controls.Add(this.chkLanguage);
            this.grpLanguage.Location = new System.Drawing.Point(306, 205);
            this.grpLanguage.Name = "grpLanguage";
            this.grpLanguage.Size = new System.Drawing.Size(277, 146);
            this.grpLanguage.TabIndex = 24;
            this.grpLanguage.TabStop = false;
            this.grpLanguage.Text = "Language:";
            // 
            // radAnyLanguage
            // 
            this.radAnyLanguage.AutoSize = true;
            this.radAnyLanguage.Checked = true;
            this.radAnyLanguage.Location = new System.Drawing.Point(39, 116);
            this.radAnyLanguage.Name = "radAnyLanguage";
            this.radAnyLanguage.Size = new System.Drawing.Size(43, 17);
            this.radAnyLanguage.TabIndex = 16;
            this.radAnyLanguage.TabStop = true;
            this.radAnyLanguage.Text = "Any";
            this.radAnyLanguage.UseVisualStyleBackColor = true;
            // 
            // radExactLanguage
            // 
            this.radExactLanguage.AutoSize = true;
            this.radExactLanguage.Location = new System.Drawing.Point(89, 116);
            this.radExactLanguage.Name = "radExactLanguage";
            this.radExactLanguage.Size = new System.Drawing.Size(52, 17);
            this.radExactLanguage.TabIndex = 15;
            this.radExactLanguage.Text = "Exact";
            this.radExactLanguage.UseVisualStyleBackColor = true;
            // 
            // chkLanguage
            // 
            this.chkLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLanguage.DataSourceName = "Language";
            this.chkLanguage.Location = new System.Drawing.Point(26, 20);
            this.chkLanguage.Name = "chkLanguage";
            this.chkLanguage.SelectAll = true;
            this.chkLanguage.Size = new System.Drawing.Size(224, 104);
            this.chkLanguage.TabIndex = 13;
            // 
            // grpRange
            // 
            this.grpRange.Controls.Add(this.label3);
            this.grpRange.Controls.Add(this.label2);
            this.grpRange.Controls.Add(this.label1);
            this.grpRange.Controls.Add(this.txtDurationUp);
            this.grpRange.Controls.Add(this.txtProductUp);
            this.grpRange.Controls.Add(this.dropRateUp);
            this.grpRange.Controls.Add(this.txtDurationLow);
            this.grpRange.Controls.Add(this.txtProductLow);
            this.grpRange.Controls.Add(this.lblDuration);
            this.grpRange.Controls.Add(this.dropRateLow);
            this.grpRange.Controls.Add(this.lblProduct);
            this.grpRange.Controls.Add(this.lblRate);
            this.grpRange.Location = new System.Drawing.Point(21, 205);
            this.grpRange.Name = "grpRange";
            this.grpRange.Size = new System.Drawing.Size(276, 146);
            this.grpRange.TabIndex = 22;
            this.grpRange.TabStop = false;
            this.grpRange.Text = "Values Ranges:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "-";
            // 
            // txtDurationUp
            // 
            this.txtDurationUp.AllowPromptAsInput = false;
            this.txtDurationUp.BeepOnError = true;
            this.txtDurationUp.Location = new System.Drawing.Point(198, 103);
            this.txtDurationUp.Mask = "00:00:00";
            this.txtDurationUp.Name = "txtDurationUp";
            this.txtDurationUp.RejectInputOnFirstFailure = true;
            this.txtDurationUp.Size = new System.Drawing.Size(61, 20);
            this.txtDurationUp.TabIndex = 11;
            this.txtDurationUp.Text = "200000";
            this.txtDurationUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProductUp
            // 
            this.txtProductUp.AllowPromptAsInput = false;
            this.txtProductUp.BeepOnError = true;
            this.txtProductUp.Location = new System.Drawing.Point(198, 72);
            this.txtProductUp.Mask = "0000";
            this.txtProductUp.Name = "txtProductUp";
            this.txtProductUp.RejectInputOnFirstFailure = true;
            this.txtProductUp.Size = new System.Drawing.Size(61, 20);
            this.txtProductUp.TabIndex = 9;
            this.txtProductUp.Text = "2100";
            this.txtProductUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dropRateUp
            // 
            this.dropRateUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropRateUp.FormattingEnabled = true;
            this.dropRateUp.Items.AddRange(new object[] {
            "10",
            "9.5",
            "9",
            "8.5",
            "8",
            "7.5",
            "7",
            "6.5",
            "6",
            "5.5",
            "5",
            "4.5",
            "4",
            "3.5",
            "3",
            "2.5",
            "2",
            "1.5",
            "1",
            "0.5",
            "0"});
            this.dropRateUp.Location = new System.Drawing.Point(198, 41);
            this.dropRateUp.Name = "dropRateUp";
            this.dropRateUp.Size = new System.Drawing.Size(61, 21);
            this.dropRateUp.TabIndex = 7;
            // 
            // txtDurationLow
            // 
            this.txtDurationLow.AllowPromptAsInput = false;
            this.txtDurationLow.BeepOnError = true;
            this.txtDurationLow.Location = new System.Drawing.Point(104, 103);
            this.txtDurationLow.Mask = "00:00:00";
            this.txtDurationLow.Name = "txtDurationLow";
            this.txtDurationLow.RejectInputOnFirstFailure = true;
            this.txtDurationLow.Size = new System.Drawing.Size(61, 20);
            this.txtDurationLow.TabIndex = 10;
            this.txtDurationLow.Text = "000000";
            this.txtDurationLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProductLow
            // 
            this.txtProductLow.AllowPromptAsInput = false;
            this.txtProductLow.BeepOnError = true;
            this.txtProductLow.Location = new System.Drawing.Point(104, 72);
            this.txtProductLow.Mask = "0000";
            this.txtProductLow.Name = "txtProductLow";
            this.txtProductLow.RejectInputOnFirstFailure = true;
            this.txtProductLow.Size = new System.Drawing.Size(61, 20);
            this.txtProductLow.TabIndex = 8;
            this.txtProductLow.Text = "1900";
            this.txtProductLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(36, 106);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 5;
            this.lblDuration.Text = "Duration:";
            // 
            // dropRateLow
            // 
            this.dropRateLow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropRateLow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dropRateLow.FormattingEnabled = true;
            this.dropRateLow.Items.AddRange(new object[] {
            "0",
            "0.5",
            "1",
            "1.5",
            "2",
            "2.5",
            "3",
            "3.5",
            "4",
            "4.5",
            "5",
            "5.5",
            "6",
            "6.5",
            "7",
            "7.5",
            "8",
            "8.5",
            "9",
            "9.5",
            "10"});
            this.dropRateLow.Location = new System.Drawing.Point(104, 41);
            this.dropRateLow.MaxDropDownItems = 21;
            this.dropRateLow.Name = "dropRateLow";
            this.dropRateLow.Size = new System.Drawing.Size(61, 21);
            this.dropRateLow.TabIndex = 6;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(14, 75);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(72, 13);
            this.lblProduct.TabIndex = 2;
            this.lblProduct.Text = "Product Year:";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(23, 44);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(63, 13);
            this.lblRate.TabIndex = 0;
            this.lblRate.Text = "IMDB Rate:";
            // 
            // grpQuality
            // 
            this.grpQuality.Controls.Add(this.chkQuality);
            this.grpQuality.Location = new System.Drawing.Point(306, 69);
            this.grpQuality.Name = "grpQuality";
            this.grpQuality.Size = new System.Drawing.Size(277, 134);
            this.grpQuality.TabIndex = 23;
            this.grpQuality.TabStop = false;
            this.grpQuality.Text = "Quality:";
            // 
            // chkQuality
            // 
            this.chkQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkQuality.DataSourceName = "Quality";
            this.chkQuality.Location = new System.Drawing.Point(26, 21);
            this.chkQuality.Name = "chkQuality";
            this.chkQuality.SelectAll = true;
            this.chkQuality.Size = new System.Drawing.Size(224, 104);
            this.chkQuality.TabIndex = 12;
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.txtMovieName);
            this.grpBase.Controls.Add(this.chkNotSeen);
            this.grpBase.Controls.Add(this.lblMovieName);
            this.grpBase.Controls.Add(this.chkSeen);
            this.grpBase.Controls.Add(this.chkFavorite);
            this.grpBase.Controls.Add(this.txtCount);
            this.grpBase.Controls.Add(this.lblCount);
            this.grpBase.Location = new System.Drawing.Point(21, 9);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(276, 194);
            this.grpBase.TabIndex = 21;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "Basics:";
            // 
            // txtMovieName
            // 
            this.txtMovieName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtMovieName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMovieName.Location = new System.Drawing.Point(102, 38);
            this.txtMovieName.MaxLength = 100;
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(140, 20);
            this.txtMovieName.TabIndex = 1;
            // 
            // chkNotSeen
            // 
            this.chkNotSeen.AutoSize = true;
            this.chkNotSeen.Checked = true;
            this.chkNotSeen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotSeen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkNotSeen.Location = new System.Drawing.Point(37, 145);
            this.chkNotSeen.Name = "chkNotSeen";
            this.chkNotSeen.Size = new System.Drawing.Size(153, 17);
            this.chkNotSeen.TabIndex = 5;
            this.chkNotSeen.Text = "Include unwatched movies";
            this.chkNotSeen.UseVisualStyleBackColor = true;
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Location = new System.Drawing.Point(34, 41);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(62, 13);
            this.lblMovieName.TabIndex = 0;
            this.lblMovieName.Text = "Movie Title:";
            // 
            // chkSeen
            // 
            this.chkSeen.AutoSize = true;
            this.chkSeen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkSeen.Location = new System.Drawing.Point(37, 121);
            this.chkSeen.Name = "chkSeen";
            this.chkSeen.Size = new System.Drawing.Size(141, 17);
            this.chkSeen.TabIndex = 4;
            this.chkSeen.Text = "Include watched movies";
            this.chkSeen.UseVisualStyleBackColor = true;
            // 
            // chkFavorite
            // 
            this.chkFavorite.AutoSize = true;
            this.chkFavorite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkFavorite.Location = new System.Drawing.Point(37, 97);
            this.chkFavorite.Name = "chkFavorite";
            this.chkFavorite.Size = new System.Drawing.Size(135, 17);
            this.chkFavorite.TabIndex = 3;
            this.chkFavorite.Text = "Include favorite movies";
            this.chkFavorite.UseVisualStyleBackColor = true;
            // 
            // txtCount
            // 
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.Location = new System.Drawing.Point(102, 69);
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
            this.txtCount.Size = new System.Drawing.Size(56, 20);
            this.txtCount.TabIndex = 2;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(34, 71);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(38, 13);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count:";
            // 
            // tabDetail
            // 
            this.tabDetail.BackColor = System.Drawing.SystemColors.Control;
            this.tabDetail.Controls.Add(this.grpActor);
            this.tabDetail.Controls.Add(this.grpDirector);
            this.tabDetail.Controls.Add(this.grpGenre);
            this.tabDetail.Location = new System.Drawing.Point(4, 25);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetail.Size = new System.Drawing.Size(604, 357);
            this.tabDetail.TabIndex = 1;
            this.tabDetail.Text = "Extra Details";
            // 
            // grpActor
            // 
            this.grpActor.Controls.Add(this.radAnyActor);
            this.grpActor.Controls.Add(this.radExactActor);
            this.grpActor.Controls.Add(this.dgvActor);
            this.grpActor.Location = new System.Drawing.Point(405, 2);
            this.grpActor.Name = "grpActor";
            this.grpActor.Size = new System.Drawing.Size(196, 350);
            this.grpActor.TabIndex = 27;
            this.grpActor.TabStop = false;
            this.grpActor.Text = "Actor:";
            // 
            // radAnyActor
            // 
            this.radAnyActor.AutoSize = true;
            this.radAnyActor.Checked = true;
            this.radAnyActor.Location = new System.Drawing.Point(17, 327);
            this.radAnyActor.Name = "radAnyActor";
            this.radAnyActor.Size = new System.Drawing.Size(43, 17);
            this.radAnyActor.TabIndex = 25;
            this.radAnyActor.TabStop = true;
            this.radAnyActor.Text = "Any";
            this.radAnyActor.UseVisualStyleBackColor = true;
            // 
            // radExactActor
            // 
            this.radExactActor.AutoSize = true;
            this.radExactActor.Location = new System.Drawing.Point(67, 327);
            this.radExactActor.Name = "radExactActor";
            this.radExactActor.Size = new System.Drawing.Size(52, 17);
            this.radExactActor.TabIndex = 24;
            this.radExactActor.Text = "Exact";
            this.radExactActor.UseVisualStyleBackColor = true;
            // 
            // dgvActor
            // 
            this.dgvActor.AcceptDoubleClick = false;
            this.dgvActor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActor.AutoGenerateColumns = false;
            this.dgvActor.DataSourceName = "Person";
            this.dgvActor.DefaultText = "Search Actors";
            this.dgvActor.EnableRightClick = false;
            this.dgvActor.ExitRequest = false;
            this.dgvActor.HeaderHeight = 9;
            this.dgvActor.IsActor = true;
            this.dgvActor.IsCopyRequestable = false;
            this.dgvActor.IsDeletable = false;
            this.dgvActor.IsDirector = false;
            this.dgvActor.IsForceUpdatable = false;
            this.dgvActor.IsRemovable = false;
            this.dgvActor.IsSelectable = true;
            this.dgvActor.IsUpdatable = false;
            this.dgvActor.IsUpdatableFromURL = false;
            this.dgvActor.ListType = "";
            this.dgvActor.Location = new System.Drawing.Point(14, 25);
            this.dgvActor.Name = "dgvActor";
            this.dgvActor.SelectAll = true;
            this.dgvActor.ShowCount = false;
            this.dgvActor.Size = new System.Drawing.Size(169, 304);
            this.dgvActor.TabIndex = 18;
            // 
            // grpDirector
            // 
            this.grpDirector.Controls.Add(this.radAnyDirector);
            this.grpDirector.Controls.Add(this.radExactDirector);
            this.grpDirector.Controls.Add(this.dgvDirector);
            this.grpDirector.Location = new System.Drawing.Point(205, 2);
            this.grpDirector.Name = "grpDirector";
            this.grpDirector.Size = new System.Drawing.Size(196, 350);
            this.grpDirector.TabIndex = 26;
            this.grpDirector.TabStop = false;
            this.grpDirector.Text = "Director:";
            // 
            // radAnyDirector
            // 
            this.radAnyDirector.AutoSize = true;
            this.radAnyDirector.Checked = true;
            this.radAnyDirector.Location = new System.Drawing.Point(17, 327);
            this.radAnyDirector.Name = "radAnyDirector";
            this.radAnyDirector.Size = new System.Drawing.Size(43, 17);
            this.radAnyDirector.TabIndex = 25;
            this.radAnyDirector.TabStop = true;
            this.radAnyDirector.Text = "Any";
            this.radAnyDirector.UseVisualStyleBackColor = true;
            // 
            // radExactDirector
            // 
            this.radExactDirector.AutoSize = true;
            this.radExactDirector.Location = new System.Drawing.Point(67, 327);
            this.radExactDirector.Name = "radExactDirector";
            this.radExactDirector.Size = new System.Drawing.Size(52, 17);
            this.radExactDirector.TabIndex = 24;
            this.radExactDirector.Text = "Exact";
            this.radExactDirector.UseVisualStyleBackColor = true;
            // 
            // dgvDirector
            // 
            this.dgvDirector.AcceptDoubleClick = false;
            this.dgvDirector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDirector.AutoGenerateColumns = false;
            this.dgvDirector.DataSourceName = "Person";
            this.dgvDirector.DefaultText = "Search Directors";
            this.dgvDirector.EnableRightClick = false;
            this.dgvDirector.ExitRequest = false;
            this.dgvDirector.HeaderHeight = 9;
            this.dgvDirector.IsActor = false;
            this.dgvDirector.IsCopyRequestable = false;
            this.dgvDirector.IsDeletable = false;
            this.dgvDirector.IsDirector = true;
            this.dgvDirector.IsForceUpdatable = false;
            this.dgvDirector.IsRemovable = false;
            this.dgvDirector.IsSelectable = true;
            this.dgvDirector.IsUpdatable = false;
            this.dgvDirector.IsUpdatableFromURL = false;
            this.dgvDirector.ListType = "";
            this.dgvDirector.Location = new System.Drawing.Point(14, 25);
            this.dgvDirector.Name = "dgvDirector";
            this.dgvDirector.SelectAll = true;
            this.dgvDirector.ShowCount = false;
            this.dgvDirector.Size = new System.Drawing.Size(169, 304);
            this.dgvDirector.TabIndex = 17;
            // 
            // grpGenre
            // 
            this.grpGenre.Controls.Add(this.radAnyGenre);
            this.grpGenre.Controls.Add(this.radExactGenre);
            this.grpGenre.Controls.Add(this.dgvGenre);
            this.grpGenre.Location = new System.Drawing.Point(5, 2);
            this.grpGenre.Name = "grpGenre";
            this.grpGenre.Size = new System.Drawing.Size(196, 350);
            this.grpGenre.TabIndex = 25;
            this.grpGenre.TabStop = false;
            this.grpGenre.Text = "Genre:";
            // 
            // radAnyGenre
            // 
            this.radAnyGenre.AutoSize = true;
            this.radAnyGenre.Checked = true;
            this.radAnyGenre.Location = new System.Drawing.Point(17, 327);
            this.radAnyGenre.Name = "radAnyGenre";
            this.radAnyGenre.Size = new System.Drawing.Size(43, 17);
            this.radAnyGenre.TabIndex = 23;
            this.radAnyGenre.TabStop = true;
            this.radAnyGenre.Text = "Any";
            this.radAnyGenre.UseVisualStyleBackColor = true;
            // 
            // radExactGenre
            // 
            this.radExactGenre.AutoSize = true;
            this.radExactGenre.Location = new System.Drawing.Point(67, 327);
            this.radExactGenre.Name = "radExactGenre";
            this.radExactGenre.Size = new System.Drawing.Size(52, 17);
            this.radExactGenre.TabIndex = 22;
            this.radExactGenre.Text = "Exact";
            this.radExactGenre.UseVisualStyleBackColor = true;
            // 
            // dgvGenre
            // 
            this.dgvGenre.AcceptDoubleClick = false;
            this.dgvGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGenre.AutoGenerateColumns = false;
            this.dgvGenre.DataSourceName = "Genre";
            this.dgvGenre.DefaultText = "Search Genres";
            this.dgvGenre.EnableRightClick = false;
            this.dgvGenre.ExitRequest = false;
            this.dgvGenre.HeaderHeight = 9;
            this.dgvGenre.IsActor = false;
            this.dgvGenre.IsCopyRequestable = false;
            this.dgvGenre.IsDeletable = false;
            this.dgvGenre.IsDirector = false;
            this.dgvGenre.IsForceUpdatable = false;
            this.dgvGenre.IsRemovable = false;
            this.dgvGenre.IsSelectable = true;
            this.dgvGenre.IsUpdatable = false;
            this.dgvGenre.IsUpdatableFromURL = false;
            this.dgvGenre.ListType = "";
            this.dgvGenre.Location = new System.Drawing.Point(14, 25);
            this.dgvGenre.Name = "dgvGenre";
            this.dgvGenre.SelectAll = true;
            this.dgvGenre.ShowCount = false;
            this.dgvGenre.Size = new System.Drawing.Size(169, 303);
            this.dgvGenre.TabIndex = 16;
            // 
            // tabExcluded
            // 
            this.tabExcluded.Controls.Add(this.pathListBox);
            this.tabExcluded.Location = new System.Drawing.Point(4, 25);
            this.tabExcluded.Name = "tabExcluded";
            this.tabExcluded.Padding = new System.Windows.Forms.Padding(3);
            this.tabExcluded.Size = new System.Drawing.Size(604, 357);
            this.tabExcluded.TabIndex = 2;
            this.tabExcluded.Text = "Excluded Paths";
            this.tabExcluded.UseVisualStyleBackColor = true;
            // 
            // pathListBox
            // 
            this.pathListBox.Location = new System.Drawing.Point(9, 10);
            this.pathListBox.Name = "pathListBox";
            this.pathListBox.Path = "";
            this.pathListBox.Size = new System.Drawing.Size(586, 325);
            this.pathListBox.TabIndex = 0;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(480, 410);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(108, 35);
            this.btnView.TabIndex = 19;
            this.btnView.Text = "View Result";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dataGridViewColumn1
            // 
            this.dataGridViewColumn1.Name = "dataGridViewColumn1";
            this.dataGridViewColumn1.ReadOnly = true;
            // 
            // dataGridViewColumn2
            // 
            this.dataGridViewColumn2.Name = "dataGridViewColumn2";
            this.dataGridViewColumn2.ReadOnly = true;
            // 
            // dataGridViewColumn3
            // 
            this.dataGridViewColumn3.Name = "dataGridViewColumn3";
            this.dataGridViewColumn3.ReadOnly = true;
            // 
            // dataGridViewColumn4
            // 
            this.dataGridViewColumn4.Name = "dataGridViewColumn4";
            this.dataGridViewColumn4.ReadOnly = true;
            // 
            // dataGridViewColumn5
            // 
            this.dataGridViewColumn5.Name = "dataGridViewColumn5";
            this.dataGridViewColumn5.ReadOnly = true;
            // 
            // dataGridViewColumn6
            // 
            this.dataGridViewColumn6.DataPropertyName = "GenreID";
            this.dataGridViewColumn6.Name = "dataGridViewColumn6";
            this.dataGridViewColumn6.ReadOnly = true;
            // 
            // dataGridViewColumn7
            // 
            this.dataGridViewColumn7.Name = "dataGridViewColumn7";
            this.dataGridViewColumn7.ReadOnly = true;
            // 
            // dataGridViewColumn8
            // 
            this.dataGridViewColumn8.Name = "dataGridViewColumn8";
            this.dataGridViewColumn8.ReadOnly = true;
            // 
            // dataGridViewColumn9
            // 
            this.dataGridViewColumn9.Name = "dataGridViewColumn9";
            this.dataGridViewColumn9.ReadOnly = true;
            // 
            // dataGridViewColumn10
            // 
            this.dataGridViewColumn10.DataPropertyName = "GenreID";
            this.dataGridViewColumn10.Name = "dataGridViewColumn10";
            this.dataGridViewColumn10.ReadOnly = true;
            // 
            // dataGridViewColumn11
            // 
            this.dataGridViewColumn11.Name = "dataGridViewColumn11";
            this.dataGridViewColumn11.ReadOnly = true;
            // 
            // frmAdvancedSuggest
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 453);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tabSuggest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdvancedSuggest";
            this.Text = "iMovie - Advanced Suggestion";
            this.Load += new System.EventHandler(this.frmAdvancedSuggest_Load);
            this.Controls.SetChildIndex(this.tabSuggest, 0);
            this.Controls.SetChildIndex(this.btnView, 0);
            this.tabSuggest.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            this.grpPreset.ResumeLayout(false);
            this.grpPreset.PerformLayout();
            this.grpLanguage.ResumeLayout(false);
            this.grpLanguage.PerformLayout();
            this.grpRange.ResumeLayout(false);
            this.grpRange.PerformLayout();
            this.grpQuality.ResumeLayout(false);
            this.grpBase.ResumeLayout(false);
            this.grpBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount)).EndInit();
            this.tabDetail.ResumeLayout(false);
            this.grpActor.ResumeLayout(false);
            this.grpActor.PerformLayout();
            this.grpDirector.ResumeLayout(false);
            this.grpDirector.PerformLayout();
            this.grpGenre.ResumeLayout(false);
            this.grpGenre.PerformLayout();
            this.tabExcluded.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSuggest;
        private System.Windows.Forms.TabPage tabBase;
        private System.Windows.Forms.GroupBox grpBase;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown txtCount;
        private System.Windows.Forms.CheckBox chkFavorite;
        private System.Windows.Forms.CheckBox chkSeen;
        private System.Windows.Forms.CheckBox chkNotSeen;
        private System.Windows.Forms.GroupBox grpQuality;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.GroupBox grpRange;
        private System.Windows.Forms.ComboBox dropRateLow;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.MaskedTextBox txtDurationLow;
        private System.Windows.Forms.MaskedTextBox txtProductLow;
        private System.Windows.Forms.MaskedTextBox txtDurationUp;
        private System.Windows.Forms.MaskedTextBox txtProductUp;
        private System.Windows.Forms.ComboBox dropRateUp;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpLanguage;
        private System.Windows.Forms.TabPage tabDetail;
        private System.Windows.Forms.GroupBox grpActor;
        private System.Windows.Forms.GroupBox grpDirector;
        private System.Windows.Forms.GroupBox grpGenre;
        private ucListGridView dgvGenre;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn1;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn2;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn3;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn4;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn5;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn6;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn7;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn8;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn9;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn10;
        private ucListGridView dgvDirector;
        private ucListGridView dgvActor;
        private ucCheckBoxList chkLanguage;
        private System.Windows.Forms.GroupBox grpPreset;
        private ucCheckBoxList chkQuality;
        private System.Windows.Forms.DataGridViewColumn dataGridViewColumn11;
        private System.Windows.Forms.ComboBox dropPreset;
        private System.Windows.Forms.Label lblPreset;
        private System.Windows.Forms.RadioButton radAnyLanguage;
        private System.Windows.Forms.RadioButton radExactLanguage;
        private System.Windows.Forms.RadioButton radAnyGenre;
        private System.Windows.Forms.RadioButton radExactGenre;
        private System.Windows.Forms.RadioButton radAnyDirector;
        private System.Windows.Forms.RadioButton radExactDirector;
        private System.Windows.Forms.RadioButton radAnyActor;
        private System.Windows.Forms.RadioButton radExactActor;
        private System.Windows.Forms.TabPage tabExcluded;
        private ucPathListBox pathListBox;
    }
}