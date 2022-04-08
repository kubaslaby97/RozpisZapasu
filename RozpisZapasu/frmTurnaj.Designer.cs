
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
            this.numHriste = new System.Windows.Forms.NumericUpDown();
            this.numSkupiny = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnStorno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHriste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkupiny)).BeginInit();
            this.SuspendLayout();
            // 
            // clbTymy
            // 
            this.clbTymy.FormattingEnabled = true;
            this.clbTymy.Location = new System.Drawing.Point(9, 24);
            this.clbTymy.Margin = new System.Windows.Forms.Padding(2);
            this.clbTymy.Name = "clbTymy";
            this.clbTymy.Size = new System.Drawing.Size(278, 139);
            this.clbTymy.TabIndex = 0;
            // 
            // lblTymy
            // 
            this.lblTymy.AutoSize = true;
            this.lblTymy.Location = new System.Drawing.Point(9, 7);
            this.lblTymy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTymy.Name = "lblTymy";
            this.lblTymy.Size = new System.Drawing.Size(79, 13);
            this.lblTymy.TabIndex = 1;
            this.lblTymy.Text = "Týmy na výběr:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 168);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Počet hřišť:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Počet skupin:";
            // 
            // numHriste
            // 
            this.numHriste.Location = new System.Drawing.Point(9, 184);
            this.numHriste.Margin = new System.Windows.Forms.Padding(2);
            this.numHriste.Name = "numHriste";
            this.numHriste.Size = new System.Drawing.Size(90, 20);
            this.numHriste.TabIndex = 4;
            // 
            // numSkupiny
            // 
            this.numSkupiny.Location = new System.Drawing.Point(9, 221);
            this.numSkupiny.Margin = new System.Windows.Forms.Padding(2);
            this.numSkupiny.Name = "numSkupiny";
            this.numSkupiny.Size = new System.Drawing.Size(90, 20);
            this.numSkupiny.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(206, 214);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnStorno
            // 
            this.btnStorno.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStorno.Location = new System.Drawing.Point(121, 214);
            this.btnStorno.Margin = new System.Windows.Forms.Padding(2);
            this.btnStorno.Name = "btnStorno";
            this.btnStorno.Size = new System.Drawing.Size(80, 25);
            this.btnStorno.TabIndex = 7;
            this.btnStorno.Text = "Storno";
            this.btnStorno.UseVisualStyleBackColor = true;
            this.btnStorno.Click += new System.EventHandler(this.btnStorno_Click);
            // 
            // frmTurnaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 249);
            this.Controls.Add(this.btnStorno);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numSkupiny);
            this.Controls.Add(this.numHriste);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTymy);
            this.Controls.Add(this.clbTymy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTurnaj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametry turnaje";
            this.Load += new System.EventHandler(this.frmTurnaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHriste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkupiny)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTymy;
        private System.Windows.Forms.Label lblTymy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numHriste;
        private System.Windows.Forms.NumericUpDown numSkupiny;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnStorno;
    }
}