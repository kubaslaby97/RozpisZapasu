
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTurnaj));
            this.clbTymy = new System.Windows.Forms.CheckedListBox();
            this.lblTymy = new System.Windows.Forms.Label();
            this.lblHriste = new System.Windows.Forms.Label();
            this.lblSkupiny = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnStorno = new System.Windows.Forms.Button();
            this.clbHriste = new System.Windows.Forms.CheckedListBox();
            this.clbSkupiny = new System.Windows.Forms.CheckedListBox();
            this.lblBarvaPozadi = new System.Windows.Forms.Label();
            this.btnBarvaZapasu = new System.Windows.Forms.Button();
            this.picBarvaZapasu = new System.Windows.Forms.PictureBox();
            this.lblUkazka = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBarvaZapasu)).BeginInit();
            this.SuspendLayout();
            // 
            // clbTymy
            // 
            this.clbTymy.FormattingEnabled = true;
            this.clbTymy.Location = new System.Drawing.Point(11, 23);
            this.clbTymy.Margin = new System.Windows.Forms.Padding(2);
            this.clbTymy.Name = "clbTymy";
            this.clbTymy.Size = new System.Drawing.Size(183, 124);
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
            // lblHriste
            // 
            this.lblHriste.AutoSize = true;
            this.lblHriste.Location = new System.Drawing.Point(9, 152);
            this.lblHriste.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHriste.Name = "lblHriste";
            this.lblHriste.Size = new System.Drawing.Size(82, 13);
            this.lblHriste.TabIndex = 2;
            this.lblHriste.Text = "Hřiště na výběr:";
            // 
            // lblSkupiny
            // 
            this.lblSkupiny.AutoSize = true;
            this.lblSkupiny.Location = new System.Drawing.Point(202, 7);
            this.lblSkupiny.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSkupiny.Name = "lblSkupiny";
            this.lblSkupiny.Size = new System.Drawing.Size(92, 13);
            this.lblSkupiny.TabIndex = 3;
            this.lblSkupiny.Text = "Skupiny na výběr:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(307, 271);
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
            this.btnStorno.Location = new System.Drawing.Point(220, 271);
            this.btnStorno.Margin = new System.Windows.Forms.Padding(2);
            this.btnStorno.Name = "btnStorno";
            this.btnStorno.Size = new System.Drawing.Size(80, 25);
            this.btnStorno.TabIndex = 7;
            this.btnStorno.Text = "Storno";
            this.btnStorno.UseVisualStyleBackColor = true;
            this.btnStorno.Click += new System.EventHandler(this.btnStorno_Click);
            // 
            // clbHriste
            // 
            this.clbHriste.FormattingEnabled = true;
            this.clbHriste.Location = new System.Drawing.Point(11, 168);
            this.clbHriste.Margin = new System.Windows.Forms.Padding(2);
            this.clbHriste.Name = "clbHriste";
            this.clbHriste.Size = new System.Drawing.Size(183, 124);
            this.clbHriste.TabIndex = 8;
            // 
            // clbSkupiny
            // 
            this.clbSkupiny.FormattingEnabled = true;
            this.clbSkupiny.Location = new System.Drawing.Point(205, 24);
            this.clbSkupiny.Margin = new System.Windows.Forms.Padding(2);
            this.clbSkupiny.Name = "clbSkupiny";
            this.clbSkupiny.Size = new System.Drawing.Size(183, 124);
            this.clbSkupiny.TabIndex = 9;
            // 
            // lblBarvaPozadi
            // 
            this.lblBarvaPozadi.AutoSize = true;
            this.lblBarvaPozadi.Location = new System.Drawing.Point(217, 196);
            this.lblBarvaPozadi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBarvaPozadi.Name = "lblBarvaPozadi";
            this.lblBarvaPozadi.Size = new System.Drawing.Size(166, 13);
            this.lblBarvaPozadi.TabIndex = 10;
            this.lblBarvaPozadi.Text = "Barva pozadí přehledu a exportu:";
            // 
            // btnBarvaZapasu
            // 
            this.btnBarvaZapasu.Location = new System.Drawing.Point(291, 212);
            this.btnBarvaZapasu.Margin = new System.Windows.Forms.Padding(2);
            this.btnBarvaZapasu.Name = "btnBarvaZapasu";
            this.btnBarvaZapasu.Size = new System.Drawing.Size(74, 24);
            this.btnBarvaZapasu.TabIndex = 11;
            this.btnBarvaZapasu.Text = "Zvolit barvu";
            this.btnBarvaZapasu.UseVisualStyleBackColor = true;
            this.btnBarvaZapasu.Click += new System.EventHandler(this.btnZvolitBarvu_Click);
            // 
            // picBarvaZapasu
            // 
            this.picBarvaZapasu.Location = new System.Drawing.Point(219, 212);
            this.picBarvaZapasu.Margin = new System.Windows.Forms.Padding(2);
            this.picBarvaZapasu.Name = "picBarvaZapasu";
            this.picBarvaZapasu.Size = new System.Drawing.Size(68, 24);
            this.picBarvaZapasu.TabIndex = 12;
            this.picBarvaZapasu.TabStop = false;
            // 
            // lblUkazka
            // 
            this.lblUkazka.AutoSize = true;
            this.lblUkazka.Location = new System.Drawing.Point(226, 218);
            this.lblUkazka.Name = "lblUkazka";
            this.lblUkazka.Size = new System.Drawing.Size(44, 13);
            this.lblUkazka.TabIndex = 13;
            this.lblUkazka.Text = "Ukázka";
            // 
            // frmTurnaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 306);
            this.Controls.Add(this.lblUkazka);
            this.Controls.Add(this.picBarvaZapasu);
            this.Controls.Add(this.btnBarvaZapasu);
            this.Controls.Add(this.lblBarvaPozadi);
            this.Controls.Add(this.clbSkupiny);
            this.Controls.Add(this.clbHriste);
            this.Controls.Add(this.btnStorno);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblSkupiny);
            this.Controls.Add(this.lblHriste);
            this.Controls.Add(this.lblTymy);
            this.Controls.Add(this.clbTymy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTurnaj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametry turnaje";
            this.Load += new System.EventHandler(this.frmTurnaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBarvaZapasu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTymy;
        private System.Windows.Forms.Label lblTymy;
        private System.Windows.Forms.Label lblHriste;
        private System.Windows.Forms.Label lblSkupiny;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnStorno;
        private System.Windows.Forms.CheckedListBox clbHriste;
        private System.Windows.Forms.CheckedListBox clbSkupiny;
        private System.Windows.Forms.Label lblBarvaPozadi;
        private System.Windows.Forms.Button btnBarvaZapasu;
        private System.Windows.Forms.PictureBox picBarvaZapasu;
        private System.Windows.Forms.Label lblUkazka;
    }
}