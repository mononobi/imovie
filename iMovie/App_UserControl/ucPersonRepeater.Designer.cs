namespace iMovie
{
    partial class ucPersonRepeater
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
            this.repPerson = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.picPerson = new System.Windows.Forms.PictureBox();
            this.repPerson.ItemTemplate.SuspendLayout();
            this.repPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // repPerson
            // 
            this.repPerson.AllowUserToAddItems = false;
            this.repPerson.AllowUserToDeleteItems = false;
            // 
            // repPerson.ItemTemplate
            // 
            this.repPerson.ItemTemplate.Controls.Add(this.lblPersonName);
            this.repPerson.ItemTemplate.Controls.Add(this.picPerson);
            this.repPerson.ItemTemplate.Size = new System.Drawing.Size(113, 183);
            this.repPerson.LayoutStyle = Microsoft.VisualBasic.PowerPacks.DataRepeaterLayoutStyles.Horizontal;
            this.repPerson.Location = new System.Drawing.Point(3, 3);
            this.repPerson.MaximumSize = new System.Drawing.Size(614, 191);
            this.repPerson.Name = "repPerson";
            this.repPerson.Size = new System.Drawing.Size(614, 191);
            this.repPerson.TabIndex = 1;
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoEllipsis = true;
            this.lblPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPersonName.Location = new System.Drawing.Point(0, 131);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(109, 32);
            this.lblPersonName.TabIndex = 1;
            this.lblPersonName.Text = "N/A";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPersonName.UseMnemonic = false;
            // 
            // picPerson
            // 
            this.picPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPerson.ErrorImage = global::iMovie.Properties.Resources.no_pic;
            this.picPerson.Image = global::iMovie.Properties.Resources.no_pic;
            this.picPerson.InitialImage = global::iMovie.Properties.Resources.no_pic;
            this.picPerson.Location = new System.Drawing.Point(6, 2);
            this.picPerson.Name = "picPerson";
            this.picPerson.Size = new System.Drawing.Size(96, 124);
            this.picPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPerson.TabIndex = 0;
            this.picPerson.TabStop = false;
            this.picPerson.Click += new System.EventHandler(this.picPerson_Click);
            // 
            // ucPersonRepeater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.repPerson);
            this.MaximumSize = new System.Drawing.Size(619, 196);
            this.Name = "ucPersonRepeater";
            this.Size = new System.Drawing.Size(619, 196);
            this.repPerson.ItemTemplate.ResumeLayout(false);
            this.repPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater repPerson;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.PictureBox picPerson;
    }
}
