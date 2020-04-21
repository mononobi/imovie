namespace iMovie
{
    partial class frmPersonList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonList));
            this.dgvPerson = new iMovie.ucListGridView();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPerson
            // 
            this.dgvPerson.AcceptDoubleClick = true;
            this.dgvPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPerson.AutoGenerateColumns = false;
            this.dgvPerson.DataSourceName = "Person";
            this.dgvPerson.DefaultText = "Search";
            this.dgvPerson.EnableRightClick = false;
            this.dgvPerson.ExitRequest = false;
            this.dgvPerson.HeaderHeight = 21;
            this.dgvPerson.IsActor = false;
            this.dgvPerson.IsCopyRequestable = false;
            this.dgvPerson.IsDeletable = true;
            this.dgvPerson.IsDirector = false;
            this.dgvPerson.IsForceUpdatable = false;
            this.dgvPerson.IsRemovable = false;
            this.dgvPerson.IsSelectable = false;
            this.dgvPerson.IsUpdatable = false;
            this.dgvPerson.IsUpdatableFromURL = false;
            this.dgvPerson.ListType = "";
            this.dgvPerson.Location = new System.Drawing.Point(8, 27);
            this.dgvPerson.Name = "dgvPerson";
            this.dgvPerson.SelectAll = false;
            this.dgvPerson.ShowCount = false;
            this.dgvPerson.Size = new System.Drawing.Size(169, 362);
            this.dgvPerson.TabIndex = 0;
            // 
            // picPhoto
            // 
            this.picPhoto.ErrorImage = global::iMovie.Properties.Resources.no_pic;
            this.picPhoto.Image = global::iMovie.Properties.Resources.no_pic;
            this.picPhoto.InitialImage = global::iMovie.Properties.Resources.no_pic;
            this.picPhoto.Location = new System.Drawing.Point(183, 93);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(193, 292);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 23;
            this.picPhoto.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(183, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(193, 52);
            this.lblName.TabIndex = 24;
            this.lblName.Text = "Not Selected";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblName.UseMnemonic = false;
            // 
            // frmPersonList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 392);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.dgvPerson);
            this.Name = "frmPersonList";
            this.Text = "Person List";
            this.Load += new System.EventHandler(this.frmPersonList_Load);
            this.Controls.SetChildIndex(this.dgvPerson, 0);
            this.Controls.SetChildIndex(this.picPhoto, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucListGridView dgvPerson;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblName;

    }
}