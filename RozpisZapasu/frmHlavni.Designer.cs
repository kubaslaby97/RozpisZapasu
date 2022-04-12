
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHlavni));
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSpravaTymu = new System.Windows.Forms.Button();
            this.btnSpravaHrist = new System.Windows.Forms.Button();
            this.btnSpravaSkupin = new System.Windows.Forms.Button();
            this.lsvZapasyHriste = new System.Windows.Forms.ListView();
            this.colDomaci = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHoste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHriste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKolo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVytvoritTurnaj = new System.Windows.Forms.Button();
            this.btnUlozit = new System.Windows.Forms.Button();
            this.lsvZapasySkupina = new System.Windows.Forms.ListView();
            this.cmnDomaci = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnHoste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnSkupina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnKolo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblKazdy = new System.Windows.Forms.Label();
            this.lblZapasySkupiny = new System.Windows.Forms.Label();
            this.lblSkupinyTymy = new System.Windows.Forms.Label();
            this.lsvSkupinyTymy = new System.Windows.Forms.ListView();
            this.colTym = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSkupina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitHlavni = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableTlacitka = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitHlavni)).BeginInit();
            this.splitHlavni.Panel1.SuspendLayout();
            this.splitHlavni.Panel2.SuspendLayout();
            this.splitHlavni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableTlacitka.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(149, 4);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(137, 32);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Export do Excelu";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSpravaTymu
            // 
            this.btnSpravaTymu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpravaTymu.Location = new System.Drawing.Point(4, 4);
            this.btnSpravaTymu.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpravaTymu.Name = "btnSpravaTymu";
            this.btnSpravaTymu.Size = new System.Drawing.Size(137, 32);
            this.btnSpravaTymu.TabIndex = 1;
            this.btnSpravaTymu.Text = "Správa týmů";
            this.btnSpravaTymu.UseVisualStyleBackColor = true;
            this.btnSpravaTymu.Click += new System.EventHandler(this.btnSpravaTymu_Click);
            // 
            // btnSpravaHrist
            // 
            this.btnSpravaHrist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpravaHrist.Location = new System.Drawing.Point(149, 4);
            this.btnSpravaHrist.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpravaHrist.Name = "btnSpravaHrist";
            this.btnSpravaHrist.Size = new System.Drawing.Size(137, 32);
            this.btnSpravaHrist.TabIndex = 2;
            this.btnSpravaHrist.Text = "Správa hřišť";
            this.btnSpravaHrist.UseVisualStyleBackColor = true;
            this.btnSpravaHrist.Click += new System.EventHandler(this.btnSpravaHrist_Click);
            // 
            // btnSpravaSkupin
            // 
            this.btnSpravaSkupin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpravaSkupin.Location = new System.Drawing.Point(294, 4);
            this.btnSpravaSkupin.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpravaSkupin.Name = "btnSpravaSkupin";
            this.btnSpravaSkupin.Size = new System.Drawing.Size(137, 32);
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
            this.lsvZapasyHriste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvZapasyHriste.HideSelection = false;
            this.lsvZapasyHriste.Location = new System.Drawing.Point(4, 22);
            this.lsvZapasyHriste.Margin = new System.Windows.Forms.Padding(4);
            this.lsvZapasyHriste.Name = "lsvZapasyHriste";
            this.lsvZapasyHriste.Size = new System.Drawing.Size(499, 246);
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
            // btnVytvoritTurnaj
            // 
            this.btnVytvoritTurnaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVytvoritTurnaj.Location = new System.Drawing.Point(4, 4);
            this.btnVytvoritTurnaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnVytvoritTurnaj.Name = "btnVytvoritTurnaj";
            this.btnVytvoritTurnaj.Size = new System.Drawing.Size(137, 32);
            this.btnVytvoritTurnaj.TabIndex = 5;
            this.btnVytvoritTurnaj.Text = "Vytvořit turnaj";
            this.btnVytvoritTurnaj.UseVisualStyleBackColor = true;
            this.btnVytvoritTurnaj.Click += new System.EventHandler(this.btnVytvoritTurnaj_Click);
            // 
            // btnUlozit
            // 
            this.btnUlozit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUlozit.Location = new System.Drawing.Point(294, 4);
            this.btnUlozit.Margin = new System.Windows.Forms.Padding(4);
            this.btnUlozit.Name = "btnUlozit";
            this.btnUlozit.Size = new System.Drawing.Size(137, 32);
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
            this.lsvZapasySkupina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvZapasySkupina.HideSelection = false;
            this.lsvZapasySkupina.Location = new System.Drawing.Point(4, 23);
            this.lsvZapasySkupina.Margin = new System.Windows.Forms.Padding(4);
            this.lsvZapasySkupina.Name = "lsvZapasySkupina";
            this.lsvZapasySkupina.Size = new System.Drawing.Size(499, 297);
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
            // lblKazdy
            // 
            this.lblKazdy.AutoSize = true;
            this.lblKazdy.Location = new System.Drawing.Point(3, 0);
            this.lblKazdy.Name = "lblKazdy";
            this.lblKazdy.Size = new System.Drawing.Size(114, 17);
            this.lblKazdy.TabIndex = 8;
            this.lblKazdy.Text = "Každý s každým:";
            // 
            // lblZapasySkupiny
            // 
            this.lblZapasySkupiny.AutoSize = true;
            this.lblZapasySkupiny.Location = new System.Drawing.Point(3, 0);
            this.lblZapasySkupiny.Name = "lblZapasySkupiny";
            this.lblZapasySkupiny.Size = new System.Drawing.Size(146, 17);
            this.lblZapasySkupiny.TabIndex = 9;
            this.lblZapasySkupiny.Text = "Zápasy ve skupinách:";
            // 
            // lblSkupinyTymy
            // 
            this.lblSkupinyTymy.AutoSize = true;
            this.lblSkupinyTymy.Location = new System.Drawing.Point(3, 0);
            this.lblSkupinyTymy.Name = "lblSkupinyTymy";
            this.lblSkupinyTymy.Size = new System.Drawing.Size(133, 17);
            this.lblSkupinyTymy.TabIndex = 10;
            this.lblSkupinyTymy.Text = "Týmy ve skupinách:";
            // 
            // lsvSkupinyTymy
            // 
            this.lsvSkupinyTymy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTym,
            this.colSkupina});
            this.lsvSkupinyTymy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvSkupinyTymy.HideSelection = false;
            this.lsvSkupinyTymy.Location = new System.Drawing.Point(3, 22);
            this.lsvSkupinyTymy.Name = "lsvSkupinyTymy";
            this.lsvSkupinyTymy.Size = new System.Drawing.Size(370, 575);
            this.lsvSkupinyTymy.TabIndex = 11;
            this.lsvSkupinyTymy.UseCompatibleStateImageBehavior = false;
            this.lsvSkupinyTymy.View = System.Windows.Forms.View.Details;
            // 
            // colTym
            // 
            this.colTym.Text = "Tým";
            this.colTym.Width = 151;
            // 
            // colSkupina
            // 
            this.colSkupina.Text = "Skupina";
            this.colSkupina.Width = 100;
            // 
            // splitHlavni
            // 
            this.splitHlavni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHlavni.Location = new System.Drawing.Point(3, 3);
            this.splitHlavni.Name = "splitHlavni";
            // 
            // splitHlavni.Panel1
            // 
            this.splitHlavni.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitHlavni.Panel2
            // 
            this.splitHlavni.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitHlavni.Size = new System.Drawing.Size(887, 600);
            this.splitHlavni.SplitterDistance = 507;
            this.splitHlavni.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Size = new System.Drawing.Size(507, 600);
            this.splitContainer2.SplitterDistance = 272;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lsvZapasyHriste, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblKazdy, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.617647F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.38235F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(507, 272);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lsvZapasySkupina, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblZapasySkupiny, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.864198F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.1358F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(507, 324);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblSkupinyTymy, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lsvSkupinyTymy, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(376, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSpravaTymu);
            this.flowLayoutPanel1.Controls.Add(this.btnSpravaHrist);
            this.flowLayoutPanel1.Controls.Add(this.btnSpravaSkupin);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(436, 40);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableTlacitka, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.splitHlavni, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.95751F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.042489F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(893, 659);
            this.tableLayoutPanel4.TabIndex = 14;
            // 
            // tableTlacitka
            // 
            this.tableTlacitka.ColumnCount = 2;
            this.tableTlacitka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.05676F));
            this.tableTlacitka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.94324F));
            this.tableTlacitka.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableTlacitka.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableTlacitka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTlacitka.Location = new System.Drawing.Point(3, 609);
            this.tableTlacitka.Name = "tableTlacitka";
            this.tableTlacitka.RowCount = 1;
            this.tableTlacitka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableTlacitka.Size = new System.Drawing.Size(887, 47);
            this.tableTlacitka.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnVytvoritTurnaj);
            this.flowLayoutPanel2.Controls.Add(this.btnExcel);
            this.flowLayoutPanel2.Controls.Add(this.btnUlozit);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(447, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(437, 41);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // frmHlavni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 659);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHlavni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rozpis volejbalových zápasů";
            this.Load += new System.EventHandler(this.frmHlavni_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHlavni_KeyDown);
            this.splitHlavni.Panel1.ResumeLayout(false);
            this.splitHlavni.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitHlavni)).EndInit();
            this.splitHlavni.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableTlacitka.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnVytvoritTurnaj;
        private System.Windows.Forms.Button btnUlozit;
        private System.Windows.Forms.ColumnHeader colKolo;
        private System.Windows.Forms.ListView lsvZapasySkupina;
        private System.Windows.Forms.ColumnHeader cmnDomaci;
        private System.Windows.Forms.ColumnHeader cmnHoste;
        private System.Windows.Forms.ColumnHeader cmnSkupina;
        private System.Windows.Forms.ColumnHeader cmnKolo;
        private System.Windows.Forms.Label lblKazdy;
        private System.Windows.Forms.Label lblZapasySkupiny;
        private System.Windows.Forms.Label lblSkupinyTymy;
        private System.Windows.Forms.ListView lsvSkupinyTymy;
        private System.Windows.Forms.ColumnHeader colTym;
        private System.Windows.Forms.ColumnHeader colSkupina;
        private System.Windows.Forms.SplitContainer splitHlavni;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableTlacitka;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

