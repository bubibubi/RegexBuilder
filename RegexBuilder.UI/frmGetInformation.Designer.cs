namespace RegexBuilder.UI
{
    partial class frmGetInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetInformation));
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbInformationType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtInformation
            // 
            this.txtInformation.Location = new System.Drawing.Point(12, 12);
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(141, 20);
            this.txtInformation.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(296, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbInformationType
            // 
            this.cmbInformationType.FormattingEnabled = true;
            this.cmbInformationType.Location = new System.Drawing.Point(159, 11);
            this.cmbInformationType.Name = "cmbInformationType";
            this.cmbInformationType.Size = new System.Drawing.Size(121, 21);
            this.cmbInformationType.TabIndex = 1;
            // 
            // frmGetInformation
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 48);
            this.Controls.Add(this.cmbInformationType);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetInformation";
            this.Text = "Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbInformationType;
    }
}