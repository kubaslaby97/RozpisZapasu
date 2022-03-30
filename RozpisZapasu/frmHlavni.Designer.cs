
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
            this.grpZobrazeni = new System.Windows.Forms.GroupBox();
            this.optHriste = new System.Windows.Forms.RadioButton();
            this.optSkupina = new System.Windows.Forms.RadioButton();
            this.lsvZapasy = new System.Windows.Forms.ListView();
            this.colDomaci = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHoste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHriste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRozradit = new System.Windows.Forms.Button();
            this.btnUlozit = new System.Windows.Forms.Button();
            this.colKolo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpZobrazeni.SuspendLayout();
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
            // grpZobrazeni
            // 
            this.grpZobrazeni.Controls.Add(this.optHriste);
            this.grpZobrazeni.Controls.Add(this.optSkupina);
            this.grpZobrazeni.Location = new System.Drawing.Point(457, 108);
            this.grpZobrazeni.Name = "grpZobrazeni";
            this.grpZobrazeni.Size = new System.Drawing.Size(103, 88);
            this.grpZobrazeni.TabIndex = 4;
            this.grpZobrazeni.TabStop = false;
            this.grpZobrazeni.Text = "Zobrazit zápasy";
            // 
            // optHriste
            // 
            this.optHriste.AutoSize = true;
            this.optHriste.Location = new System.Drawing.Point(15, 53);
            this.optHriste.Name = "optHriste";
            this.optHriste.Size = new System.Drawing.Size(63, 17);
            this.optHriste.TabIndex = 1;
            this.optHriste.TabStop = true;
            this.optHriste.Text = "dle hřišť";
            this.optHriste.UseVisualStyleBackColor = true;
            // 
            // optSkupina
            // 
            this.optSkupina.AutoSize = true;
            this.optSkupina.Checked = true;
            this.optSkupina.Location = new System.Drawing.Point(15, 30);
            this.optSkupina.Name = "optSkupina";
            this.optSkupina.Size = new System.Drawing.Size(73, 17);
            this.optSkupina.TabIndex = 0;
            this.optSkupina.TabStop = true;
            this.optSkupina.Text = "dle skupin";
            this.optSkupina.UseVisualStyleBackColor = true;
            // 
            // lsvZapasy
            // 
            this.lsvZapasy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDomaci,
            this.colHoste,
            this.colCas,
            this.colHriste,
            this.colKolo});
            this.lsvZapasy.HideSelection = false;
            this.lsvZapasy.Location = new System.Drawing.Point(12, 12);
            this.lsvZapasy.Name = "lsvZapasy";
            this.lsvZapasy.Size = new System.Drawing.Size(439, 385);
            this.lsvZapasy.TabIndex = 0;
            this.lsvZapasy.UseCompatibleStateImageBehavior = false;
            this.lsvZapasy.View = System.Windows.Forms.View.Details;
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
            // colCas
            // 
            this.colCas.DisplayIndex = 3;
            this.colCas.Text = "Čas zápasu";
            this.colCas.Width = 97;
            // 
            // colHriste
            // 
            this.colHriste.DisplayIndex = 4;
            this.colHriste.Text = "Hřiště/Skupina";
            this.colHriste.Width = 100;
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
            // 
            // colKolo
            // 
            this.colKolo.DisplayIndex = 0;
            this.colKolo.Text = "Kolo";
            this.colKolo.Width = 40;
            // 
            // frmHlavni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 409);
            this.Controls.Add(this.lsvZapasy);
            this.Controls.Add(this.btnUlozit);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRozradit);
            this.Controls.Add(this.grpZobrazeni);
            this.Controls.Add(this.btnSpravaSkupin);
            this.Controls.Add(this.btnSpravaHrist);
            this.Controls.Add(this.btnSpravaTymu);
            this.MaximizeBox = false;
            this.Name = "frmHlavni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rozpis volejbalových zápasů";
            this.grpZobrazeni.ResumeLayout(false);
            this.grpZobrazeni.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnSpravaTymu;
        private System.Windows.Forms.Button btnSpravaHrist;
        private System.Windows.Forms.Button btnSpravaSkupin;
        private System.Windows.Forms.GroupBox grpZobrazeni;
        private System.Windows.Forms.ListView lsvZapasy;
        private System.Windows.Forms.ColumnHeader colDomaci;
        private System.Windows.Forms.ColumnHeader colHoste;
        private System.Windows.Forms.ColumnHeader colCas;
        private System.Windows.Forms.ColumnHeader colHriste;
        private System.Windows.Forms.Button btnRozradit;
        private System.Windows.Forms.Button btnUlozit;
        private System.Windows.Forms.RadioButton optHriste;
        private System.Windows.Forms.RadioButton optSkupina;
        private System.Windows.Forms.ColumnHeader colKolo;
    }
}

