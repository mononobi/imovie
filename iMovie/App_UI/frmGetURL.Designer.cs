namespace iMovie
{
    partial class frmGetURL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetURL));
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.grpMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMessage
            // 
            this.grpMessage.Controls.Add(this.txtURL);
            this.grpMessage.Controls.Add(this.btnUpdate);
            this.grpMessage.Controls.Add(this.lblItemName);
            this.grpMessage.Location = new System.Drawing.Point(7, 5);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(378, 104);
            this.grpMessage.TabIndex = 4;
            this.grpMessage.TabStop = false;
            this.grpMessage.Text = "Set IMDb Page URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(17, 59);
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(250, 26);
            this.txtURL.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(285, 57);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoEllipsis = true;
            this.lblItemName.Location = new System.Drawing.Point(14, 25);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(346, 29);
            this.lblItemName.TabIndex = 5;
            this.lblItemName.UseMnemonic = false;
            // 
            // frmGetURL
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 117);
            this.Controls.Add(this.grpMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGetURL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Force Update From URL";
            this.Load += new System.EventHandler(this.frmGetURL_Load);
            this.grpMessage.ResumeLayout(false);
            this.grpMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblItemName;

    }
}