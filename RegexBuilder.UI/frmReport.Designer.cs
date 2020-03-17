namespace RegexBuilder.UI
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTruePositives = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFalsePositives = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFalseTotals = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrueTotal = new System.Windows.Forms.TextBox();
            this.lstSentences = new System.Windows.Forms.ListBox();
            this.lstVariables = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "True positives";
            // 
            // txtTruePositives
            // 
            this.txtTruePositives.Location = new System.Drawing.Point(94, 6);
            this.txtTruePositives.Name = "txtTruePositives";
            this.txtTruePositives.ReadOnly = true;
            this.txtTruePositives.Size = new System.Drawing.Size(100, 20);
            this.txtTruePositives.TabIndex = 1;
            this.txtTruePositives.Text = "(computing)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "False positives";
            // 
            // txtFalsePositives
            // 
            this.txtFalsePositives.Location = new System.Drawing.Point(94, 32);
            this.txtFalsePositives.Name = "txtFalsePositives";
            this.txtFalsePositives.ReadOnly = true;
            this.txtFalsePositives.Size = new System.Drawing.Size(100, 20);
            this.txtFalsePositives.TabIndex = 5;
            this.txtFalsePositives.Text = "(computing)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "on";
            // 
            // txtFalseTotals
            // 
            this.txtFalseTotals.Location = new System.Drawing.Point(225, 32);
            this.txtFalseTotals.Name = "txtFalseTotals";
            this.txtFalseTotals.ReadOnly = true;
            this.txtFalseTotals.Size = new System.Drawing.Size(100, 20);
            this.txtFalseTotals.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "on";
            // 
            // txtTrueTotal
            // 
            this.txtTrueTotal.Location = new System.Drawing.Point(225, 6);
            this.txtTrueTotal.Name = "txtTrueTotal";
            this.txtTrueTotal.ReadOnly = true;
            this.txtTrueTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTrueTotal.TabIndex = 3;
            // 
            // lstSentences
            // 
            this.lstSentences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSentences.FormattingEnabled = true;
            this.lstSentences.IntegralHeight = false;
            this.lstSentences.Location = new System.Drawing.Point(12, 97);
            this.lstSentences.Name = "lstSentences";
            this.lstSentences.Size = new System.Drawing.Size(420, 342);
            this.lstSentences.TabIndex = 10;
            this.lstSentences.SelectedIndexChanged += new System.EventHandler(this.lstSentences_SelectedIndexChanged);
            // 
            // lstVariables
            // 
            this.lstVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVariables.FormattingEnabled = true;
            this.lstVariables.IntegralHeight = false;
            this.lstVariables.Location = new System.Drawing.Point(438, 97);
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.Size = new System.Drawing.Size(350, 342);
            this.lstVariables.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Regex";
            // 
            // txtRegex
            // 
            this.txtRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegex.Location = new System.Drawing.Point(94, 64);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(694, 20);
            this.txtRegex.TabIndex = 9;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstVariables);
            this.Controls.Add(this.lstSentences);
            this.Controls.Add(this.txtTrueTotal);
            this.Controls.Add(this.txtFalseTotals);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.txtFalsePositives);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTruePositives);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTruePositives;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFalsePositives;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFalseTotals;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrueTotal;
        private System.Windows.Forms.ListBox lstSentences;
        private System.Windows.Forms.ListBox lstVariables;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRegex;
    }
}