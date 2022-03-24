
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
            this.grpZapasy = new System.Windows.Forms.GroupBox();
            this.lsvZapasy = new System.Windows.Forms.ListView();
            this.colDomaci = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHoste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHriste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRozradit = new System.Windows.Forms.Button();
            this.btnUlozit = new System.Windows.Forms.Button();
            this.grpZapasy.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(613, 419);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(137, 31);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Export do Excelu";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSpravaTymu
            // 
            this.btnSpravaTymu.Location = new System.Drawing.Point(609, 15);
            this.btnSpravaTymu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSpravaTymu.Name = "btnSpravaTymu";
            this.btnSpravaTymu.Size = new System.Drawing.Size(137, 32);
            this.btnSpravaTymu.TabIndex = 1;
            this.btnSpravaTymu.Text = "Správa týmů";
            this.btnSpravaTymu.UseVisualStyleBackColor = true;
            this.btnSpravaTymu.Click += new System.EventHandler(this.btnSpravaTymu_Click);
            // 
            // btnSpravaHrist
            // 
            this.btnSpravaHrist.Location = new System.Drawing.Point(609, 54);
            this.btnSpravaHrist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSpravaHrist.Name = "btnSpravaHrist";
            this.btnSpravaHrist.Size = new System.Drawing.Size(137, 32);
            this.btnSpravaHrist.TabIndex = 2;
            this.btnSpravaHrist.Text = "Správa hřišť";
            this.btnSpravaHrist.UseVisualStyleBackColor = true;
            this.btnSpravaHrist.Click += new System.EventHandler(this.btnSpravaHrist_Click);
            // 
            // btnSpravaSkupin
            // 
            this.btnSpravaSkupin.Location = new System.Drawing.Point(609, 94);
            this.btnSpravaSkupin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSpravaSkupin.Name = "btnSpravaSkupin";
            this.btnSpravaSkupin.Size = new System.Drawing.Size(137, 32);
            this.btnSpravaSkupin.TabIndex = 3;
            this.btnSpravaSkupin.Text = "Správa skupin";
            this.btnSpravaSkupin.UseVisualStyleBackColor = true;
            this.btnSpravaSkupin.Click += new System.EventHandler(this.btnSpravaSkupin_Click);
            // 
            // grpZapasy
            // 
            this.grpZapasy.Controls.Add(this.lsvZapasy);
            this.grpZapasy.Location = new System.Drawing.Point(16, 15);
            this.grpZapasy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpZapasy.Name = "grpZapasy";
            this.grpZapasy.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpZapasy.Size = new System.Drawing.Size(585, 474);
            this.grpZapasy.TabIndex = 4;
            this.grpZapasy.TabStop = false;
            this.grpZapasy.Text = "Zápasy";
            // 
            // lsvZapasy
            // 
            this.lsvZapasy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDomaci,
            this.colHoste,
            this.colCas,
            this.colHriste});
            this.lsvZapasy.HideSelection = false;
            this.lsvZapasy.Location = new System.Drawing.Point(8, 23);
            this.lsvZapasy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsvZapasy.Name = "lsvZapasy";
            this.lsvZapasy.Size = new System.Drawing.Size(568, 442);
            this.lsvZapasy.TabIndex = 0;
            this.lsvZapasy.UseCompatibleStateImageBehavior = false;
            this.lsvZapasy.View = System.Windows.Forms.View.Details;
            // 
            // colDomaci
            // 
            this.colDomaci.Text = "Domácí";
            this.colDomaci.Width = 90;
            // 
            // colHoste
            // 
            this.colHoste.Text = "Hosté";
            this.colHoste.Width = 90;
            // 
            // colCas
            // 
            this.colCas.Text = "Čas zápasu";
            this.colCas.Width = 97;
            // 
            // colHriste
            // 
            this.colHriste.Text = "Hřiště";
            this.colHriste.Width = 90;
            // 
            // btnRozradit
            // 
            this.btnRozradit.Location = new System.Drawing.Point(613, 379);
            this.btnRozradit.Margin = new System.Windows.Forms.Padding(4);
            this.btnRozradit.Name = "btnRozradit";
            this.btnRozradit.Size = new System.Drawing.Size(137, 32);
            this.btnRozradit.TabIndex = 5;
            this.btnRozradit.Text = "Rozřadit týmy";
            this.btnRozradit.UseVisualStyleBackColor = true;
            // 
            // btnUlozit
            // 
            this.btnUlozit.Location = new System.Drawing.Point(613, 458);
            this.btnUlozit.Margin = new System.Windows.Forms.Padding(4);
            this.btnUlozit.Name = "btnUlozit";
            this.btnUlozit.Size = new System.Drawing.Size(137, 32);
            this.btnUlozit.TabIndex = 6;
            this.btnUlozit.Text = "Uložit změny";
            this.btnUlozit.UseVisualStyleBackColor = true;
            // 
            // frmHlavni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 503);
            this.Controls.Add(this.btnUlozit);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRozradit);
            this.Controls.Add(this.grpZapasy);
            this.Controls.Add(this.btnSpravaSkupin);
            this.Controls.Add(this.btnSpravaHrist);
            this.Controls.Add(this.btnSpravaTymu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmHlavni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rozpis volejbalových zápasů";
            this.Load += new System.EventHandler(this.frmHlavni_Load);
            this.grpZapasy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnSpravaTymu;
        private System.Windows.Forms.Button btnSpravaHrist;
        private System.Windows.Forms.Button btnSpravaSkupin;
        private System.Windows.Forms.GroupBox grpZapasy;
        private System.Windows.Forms.ListView lsvZapasy;
        private System.Windows.Forms.ColumnHeader colDomaci;
        private System.Windows.Forms.ColumnHeader colHoste;
        private System.Windows.Forms.ColumnHeader colCas;
        private System.Windows.Forms.ColumnHeader colHriste;
        private System.Windows.Forms.Button btnRozradit;
        private System.Windows.Forms.Button btnUlozit;
    }
}

