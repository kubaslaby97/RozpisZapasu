
namespace RozpisZapasu
{
    partial class frmTurnaj
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
            this.clbTymy = new System.Windows.Forms.CheckedListBox();
            this.lblTymy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnStorno = new System.Windows.Forms.Button();
            this.clbHriste = new System.Windows.Forms.CheckedListBox();
            this.clbSkupiny = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // clbTymy
            // 
            this.clbTymy.FormattingEnabled = true;
            this.clbTymy.Location = new System.Drawing.Point(15, 28);
            this.clbTymy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbTymy.Name = "clbTymy";
            this.clbTymy.Size = new System.Drawing.Size(243, 157);
            this.clbTymy.TabIndex = 0;
            // 
            // lblTymy
            // 
            this.lblTymy.AutoSize = true;
            this.lblTymy.Location = new System.Drawing.Point(12, 9);
            this.lblTymy.Name = "lblTymy";
            this.lblTymy.Size = new System.Drawing.Size(105, 17);
            this.lblTymy.TabIndex = 1;
            this.lblTymy.Text = "Týmy na výběr:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hřiště na výběr:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Skupiny na výběr:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(409, 334);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(107, 31);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnStorno
            // 
            this.btnStorno.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStorno.Location = new System.Drawing.Point(294, 334);
            this.btnStorno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStorno.Name = "btnStorno";
            this.btnStorno.Size = new System.Drawing.Size(107, 31);
            this.btnStorno.TabIndex = 7;
            this.btnStorno.Text = "Storno";
            this.btnStorno.UseVisualStyleBackColor = true;
            this.btnStorno.Click += new System.EventHandler(this.btnStorno_Click);
            // 
            // clbHriste
            // 
            this.clbHriste.FormattingEnabled = true;
            this.clbHriste.Location = new System.Drawing.Point(15, 207);
            this.clbHriste.Name = "clbHriste";
            this.clbHriste.Size = new System.Drawing.Size(243, 157);
            this.clbHriste.TabIndex = 8;
            // 
            // clbSkupiny
            // 
            this.clbSkupiny.FormattingEnabled = true;
            this.clbSkupiny.Location = new System.Drawing.Point(273, 30);
            this.clbSkupiny.Name = "clbSkupiny";
            this.clbSkupiny.Size = new System.Drawing.Size(243, 157);
            this.clbSkupiny.TabIndex = 9;
            // 
            // frmTurnaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 376);
            this.Controls.Add(this.clbSkupiny);
            this.Controls.Add(this.clbHriste);
            this.Controls.Add(this.btnStorno);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTymy);
            this.Controls.Add(this.clbTymy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTurnaj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametry turnaje";
            this.Load += new System.EventHandler(this.frmTurnaj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTymy;
        private System.Windows.Forms.Label lblTymy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnStorno;
        private System.Windows.Forms.CheckedListBox clbHriste;
        private System.Windows.Forms.CheckedListBox clbSkupiny;
    }
}