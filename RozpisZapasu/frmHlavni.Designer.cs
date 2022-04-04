
namespace RozpisZapasu
{
    partial class frmHlavni
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSpravaTymu = new System.Windows.Forms.Button();
            this.btnSpravaHrist = new System.Windows.Forms.Button();
            this.btnSpravaSkupin = new System.Windows.Forms.Button();
            this.lsvZapasyHriste = new System.Windows.Forms.ListView();
            this.colDomaci = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHoste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHriste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKolo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRozradit = new System.Windows.Forms.Button();
            this.btnUlozit = new System.Windows.Forms.Button();
            this.lsvZapasySkupina = new System.Windows.Forms.ListView();
            this.cmnDomaci = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnHoste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnSkupina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnKolo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(457, 340);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(103, 25);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Export do Excelu";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSpravaTymu
            // 
            this.btnSpravaTymu.Location = new System.Drawing.Point(457, 12);
            this.btnSpravaTymu.Name = "btnSpravaTymu";
            this.btnSpravaTymu.Size = new System.Drawing.Size(103, 26);
            this.btnSpravaTymu.TabIndex = 1;
            this.btnSpravaTymu.Text = "Správa týmů";
            this.btnSpravaTymu.UseVisualStyleBackColor = true;
            this.btnSpravaTymu.Click += new System.EventHandler(this.btnSpravaTymu_Click);
            // 
            // btnSpravaHrist
            // 
            this.btnSpravaHrist.Location = new System.Drawing.Point(457, 44);
            this.btnSpravaHrist.Name = "btnSpravaHrist";
            this.btnSpravaHrist.Size = new System.Drawing.Size(103, 26);
            this.btnSpravaHrist.TabIndex = 2;
            this.btnSpravaHrist.Text = "Správa hřišť";
            this.btnSpravaHrist.UseVisualStyleBackColor = true;
            this.btnSpravaHrist.Click += new System.EventHandler(this.btnSpravaHrist_Click);
            // 
            // btnSpravaSkupin
            // 
            this.btnSpravaSkupin.Location = new System.Drawing.Point(457, 76);
            this.btnSpravaSkupin.Name = "btnSpravaSkupin";
            this.btnSpravaSkupin.Size = new System.Drawing.Size(103, 26);
            this.btnSpravaSkupin.TabIndex = 3;
            this.btnSpravaSkupin.Text = "Správa skupin";
            this.btnSpravaSkupin.UseVisualStyleBackColor = true;
            this.btnSpravaSkupin.Click += new System.EventHandler(this.btnSpravaSkupin_Click);
            // 
            // lsvZapasyHriste
            // 
            this.lsvZapasyHriste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDomaci,
            this.colHoste,
            this.colHriste,
            this.colKolo});
            this.lsvZapasyHriste.HideSelection = false;
            this.lsvZapasyHriste.Location = new System.Drawing.Point(12, 12);
            this.lsvZapasyHriste.Name = "lsvZapasyHriste";
            this.lsvZapasyHriste.Size = new System.Drawing.Size(439, 184);
            this.lsvZapasyHriste.TabIndex = 0;
            this.lsvZapasyHriste.UseCompatibleStateImageBehavior = false;
            this.lsvZapasyHriste.View = System.Windows.Forms.View.Details;
            // 
            // colDomaci
            // 
            this.colDomaci.DisplayIndex = 1;
            this.colDomaci.Text = "Domácí";
            this.colDomaci.Width = 100;
            // 
            // colHoste
            // 
            this.colHoste.DisplayIndex = 2;
            this.colHoste.Text = "Hosté";
            this.colHoste.Width = 90;
            // 
            // colHriste
            // 
            this.colHriste.DisplayIndex = 3;
            this.colHriste.Text = "Hřiště";
            this.colHriste.Width = 100;
            // 
            // colKolo
            // 
            this.colKolo.DisplayIndex = 0;
            this.colKolo.Text = "Kolo";
            this.colKolo.Width = 40;
            // 
            // btnRozradit
            // 
            this.btnRozradit.Location = new System.Drawing.Point(457, 308);
            this.btnRozradit.Name = "btnRozradit";
            this.btnRozradit.Size = new System.Drawing.Size(103, 26);
            this.btnRozradit.TabIndex = 5;
            this.btnRozradit.Text = "Rozřadit týmy";
            this.btnRozradit.UseVisualStyleBackColor = true;
            this.btnRozradit.Click += new System.EventHandler(this.btnRozradit_Click);
            // 
            // btnUlozit
            // 
            this.btnUlozit.Location = new System.Drawing.Point(457, 372);
            this.btnUlozit.Name = "btnUlozit";
            this.btnUlozit.Size = new System.Drawing.Size(103, 26);
            this.btnUlozit.TabIndex = 6;
            this.btnUlozit.Text = "Uložit změny";
            this.btnUlozit.UseVisualStyleBackColor = true;
            this.btnUlozit.Click += new System.EventHandler(this.btnUlozit_Click);
            // 
            // lsvZapasySkupina
            // 
            this.lsvZapasySkupina.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cmnDomaci,
            this.cmnHoste,
            this.cmnSkupina,
            this.cmnKolo});
            this.lsvZapasySkupina.HideSelection = false;
            this.lsvZapasySkupina.Location = new System.Drawing.Point(12, 202);
            this.lsvZapasySkupina.Name = "lsvZapasySkupina";
            this.lsvZapasySkupina.Size = new System.Drawing.Size(439, 195);
            this.lsvZapasySkupina.TabIndex = 7;
            this.lsvZapasySkupina.UseCompatibleStateImageBehavior = false;
            this.lsvZapasySkupina.View = System.Windows.Forms.View.Details;
            // 
            // cmnDomaci
            // 
            this.cmnDomaci.DisplayIndex = 1;
            this.cmnDomaci.Text = "Domácí";
            this.cmnDomaci.Width = 100;
            // 
            // cmnHoste
            // 
            this.cmnHoste.DisplayIndex = 2;
            this.cmnHoste.Text = "Hosté";
            this.cmnHoste.Width = 90;
            // 
            // cmnSkupina
            // 
            this.cmnSkupina.DisplayIndex = 3;
            this.cmnSkupina.Text = "Skupina";
            this.cmnSkupina.Width = 100;
            // 
            // cmnKolo
            // 
            this.cmnKolo.DisplayIndex = 0;
            this.cmnKolo.Text = "Kolo";
            this.cmnKolo.Width = 40;
            // 
            // frmHlavni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 409);
            this.Controls.Add(this.lsvZapasySkupina);
            this.Controls.Add(this.lsvZapasyHriste);
            this.Controls.Add(this.btnUlozit);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRozradit);
            this.Controls.Add(this.btnSpravaSkupin);
            this.Controls.Add(this.btnSpravaHrist);
            this.Controls.Add(this.btnSpravaTymu);
            this.MaximizeBox = false;
            this.Name = "frmHlavni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rozpis volejbalových zápasů";
            this.Load += new System.EventHandler(this.frmHlavni_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHlavni_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnSpravaTymu;
        private System.Windows.Forms.Button btnSpravaHrist;
        private System.Windows.Forms.Button btnSpravaSkupin;
        private System.Windows.Forms.ListView lsvZapasyHriste;
        private System.Windows.Forms.ColumnHeader colDomaci;
        private System.Windows.Forms.ColumnHeader colHoste;
        private System.Windows.Forms.ColumnHeader colHriste;
        private System.Windows.Forms.Button btnRozradit;
        private System.Windows.Forms.Button btnUlozit;
        private System.Windows.Forms.ColumnHeader colKolo;
        private System.Windows.Forms.ListView lsvZapasySkupina;
        private System.Windows.Forms.ColumnHeader cmnDomaci;
        private System.Windows.Forms.ColumnHeader cmnHoste;
        private System.Windows.Forms.ColumnHeader cmnSkupina;
        private System.Windows.Forms.ColumnHeader cmnKolo;
    }
}

