namespace RegexBuilder.UI
{
    partial class frmGetSimilarSentence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetSimilarSentence));
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.ctlList = new RegexBuilder.UI.ctlList();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSentence
            // 
            this.txtSentence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSentence.HideSelection = false;
            this.txtSentence.Location = new System.Drawing.Point(0, 0);
            this.txtSentence.Multiline = true;
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(343, 136);
            this.txtSentence.TabIndex = 0;
            // 
            // ctlList
            // 
            this.ctlList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlList.ButtonsEnabled = true;
            this.ctlList.Location = new System.Drawing.Point(0, 161);
            this.ctlList.Name = "ctlList";
            this.ctlList.Size = new System.Drawing.Size(343, 93);
            this.ctlList.TabIndex = 2;
            this.ctlList.Add += new System.EventHandler(this.ctlList_Add);
            this.ctlList.Remove += new System.EventHandler(this.ctlList_Remove);
            this.ctlList.SelectedItemChanged += new System.EventHandler(this.ctlList_SelectedItemChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Informations";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(256, 260);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmGetSimilarSentence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 288);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlList);
            this.Controls.Add(this.txtSentence);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGetSimilarSentence";
            this.Text = "Sentence";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSentence;
        private ctlList ctlList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
    }
}