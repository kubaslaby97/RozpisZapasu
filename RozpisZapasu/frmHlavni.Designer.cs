
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
            this.tableHlavni = new System.Windows.Forms.TableLayoutPanel();
            this.tableTlacitka = new System.Windows.Forms.TableLayoutPanel();
            this.flowTlacitkaSprava = new System.Windows.Forms.FlowLayoutPanel();
            this.flowTlacitkaOstatni = new System.Windows.Forms.FlowLayoutPanel();
            this.splitPrehled = new System.Windows.Forms.SplitContainer();
            this.splitZapasy = new System.Windows.Forms.SplitContainer();
            this.tableZapasyHriste = new System.Windows.Forms.TableLayoutPanel();
            this.tableZapasySkupiny = new System.Windows.Forms.TableLayoutPanel();
            this.tableTymySkupiny = new System.Windows.Forms.TableLayoutPanel();
            this.tableHlavni.SuspendLayout();
            this.tableTlacitka.SuspendLayout();
            this.flowTlacitkaSprava.SuspendLayout();
            this.flowTlacitkaOstatni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPrehled)).BeginInit();
            this.splitPrehled.Panel1.SuspendLayout();
            this.splitPrehled.Panel2.SuspendLayout();
            this.splitPrehled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitZapasy)).BeginInit();
            this.splitZapasy.Panel1.SuspendLayout();
            this.splitZapasy.Panel2.SuspendLayout();
            this.splitZapasy.SuspendLayout();
            this.tableZapasyHriste.SuspendLayout();
            this.tableZapasySkupiny.SuspendLayout();
            this.tableTymySkupiny.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lsvZapasyHriste.Location = new System.Drawing.Point(4, 24);
            this.lsvZapasyHriste.Margin = new System.Windows.Forms.Padding(4);
            this.lsvZapasyHriste.Name = "lsvZapasyHriste";
            this.lsvZapasyHriste.Size = new System.Drawing.Size(380, 211);
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
            this.btnVytvoritTurnaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnUlozit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lsvZapasySkupina.Location = new System.Drawing.Point(4, 24);
            this.lsvZapasySkupina.Margin = new System.Windows.Forms.Padding(4);
            this.lsvZapasySkupina.Name = "lsvZapasySkupina";
            this.lsvZapasySkupina.Size = new System.Drawing.Size(380, 330);
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
            this.lsvSkupinyTymy.Location = new System.Drawing.Point(3, 23);
            this.lsvSkupinyTymy.Name = "lsvSkupinyTymy";
            this.lsvSkupinyTymy.Size = new System.Drawing.Size(485, 575);
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
            // tableHlavni
            // 
            this.tableHlavni.ColumnCount = 1;
            this.tableHlavni.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableHlavni.Controls.Add(this.tableTlacitka, 0, 1);
            this.tableHlavni.Controls.Add(this.splitPrehled, 0, 0);
            this.tableHlavni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableHlavni.Location = new System.Drawing.Point(0, 0);
            this.tableHlavni.Name = "tableHlavni";
            this.tableHlavni.RowCount = 2;
            this.tableHlavni.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableHlavni.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableHlavni.Size = new System.Drawing.Size(889, 659);
            this.tableHlavni.TabIndex = 15;
            // 
            // tableTlacitka
            // 
            this.tableTlacitka.ColumnCount = 2;
            this.tableTlacitka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTlacitka.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTlacitka.Controls.Add(this.flowTlacitkaSprava, 0, 0);
            this.tableTlacitka.Controls.Add(this.flowTlacitkaOstatni, 1, 0);
            this.tableTlacitka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTlacitka.Location = new System.Drawing.Point(3, 610);
            this.tableTlacitka.Name = "tableTlacitka";
            this.tableTlacitka.RowCount = 1;
            this.tableTlacitka.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTlacitka.Size = new System.Drawing.Size(883, 46);
            this.tableTlacitka.TabIndex = 0;
            // 
            // flowTlacitkaSprava
            // 
            this.flowTlacitkaSprava.Controls.Add(this.btnSpravaTymu);
            this.flowTlacitkaSprava.Controls.Add(this.btnSpravaHrist);
            this.flowTlacitkaSprava.Controls.Add(this.btnSpravaSkupin);
            this.flowTlacitkaSprava.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTlacitkaSprava.Location = new System.Drawing.Point(3, 3);
            this.flowTlacitkaSprava.Name = "flowTlacitkaSprava";
            this.flowTlacitkaSprava.Size = new System.Drawing.Size(435, 40);
            this.flowTlacitkaSprava.TabIndex = 0;
            // 
            // flowTlacitkaOstatni
            // 
            this.flowTlacitkaOstatni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowTlacitkaOstatni.Controls.Add(this.btnVytvoritTurnaj);
            this.flowTlacitkaOstatni.Controls.Add(this.btnExcel);
            this.flowTlacitkaOstatni.Controls.Add(this.btnUlozit);
            this.flowTlacitkaOstatni.Location = new System.Drawing.Point(444, 3);
            this.flowTlacitkaOstatni.Name = "flowTlacitkaOstatni";
            this.flowTlacitkaOstatni.Size = new System.Drawing.Size(436, 40);
            this.flowTlacitkaOstatni.TabIndex = 1;
            // 
            // splitPrehled
            // 
            this.splitPrehled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPrehled.Location = new System.Drawing.Point(3, 3);
            this.splitPrehled.Name = "splitPrehled";
            // 
            // splitPrehled.Panel1
            // 
            this.splitPrehled.Panel1.Controls.Add(this.splitZapasy);
            // 
            // splitPrehled.Panel2
            // 
            this.splitPrehled.Panel2.Controls.Add(this.tableTymySkupiny);
            this.splitPrehled.Size = new System.Drawing.Size(883, 601);
            this.splitPrehled.SplitterDistance = 388;
            this.splitPrehled.TabIndex = 1;
            // 
            // splitZapasy
            // 
            this.splitZapasy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitZapasy.Location = new System.Drawing.Point(0, 0);
            this.splitZapasy.Name = "splitZapasy";
            this.splitZapasy.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitZapasy.Panel1
            // 
            this.splitZapasy.Panel1.Controls.Add(this.tableZapasyHriste);
            // 
            // splitZapasy.Panel2
            // 
            this.splitZapasy.Panel2.Controls.Add(this.tableZapasySkupiny);
            this.splitZapasy.Size = new System.Drawing.Size(388, 601);
            this.splitZapasy.SplitterDistance = 239;
            this.splitZapasy.TabIndex = 0;
            // 
            // tableZapasyHriste
            // 
            this.tableZapasyHriste.ColumnCount = 1;
            this.tableZapasyHriste.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableZapasyHriste.Controls.Add(this.lsvZapasyHriste, 0, 1);
            this.tableZapasyHriste.Controls.Add(this.lblKazdy, 0, 0);
            this.tableZapasyHriste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableZapasyHriste.Location = new System.Drawing.Point(0, 0);
            this.tableZapasyHriste.Name = "tableZapasyHriste";
            this.tableZapasyHriste.RowCount = 2;
            this.tableZapasyHriste.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableZapasyHriste.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableZapasyHriste.Size = new System.Drawing.Size(388, 239);
            this.tableZapasyHriste.TabIndex = 0;
            // 
            // tableZapasySkupiny
            // 
            this.tableZapasySkupiny.ColumnCount = 1;
            this.tableZapasySkupiny.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableZapasySkupiny.Controls.Add(this.lsvZapasySkupina, 0, 1);
            this.tableZapasySkupiny.Controls.Add(this.lblZapasySkupiny, 0, 0);
            this.tableZapasySkupiny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableZapasySkupiny.Location = new System.Drawing.Point(0, 0);
            this.tableZapasySkupiny.Name = "tableZapasySkupiny";
            this.tableZapasySkupiny.RowCount = 2;
            this.tableZapasySkupiny.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableZapasySkupiny.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableZapasySkupiny.Size = new System.Drawing.Size(388, 358);
            this.tableZapasySkupiny.TabIndex = 0;
            // 
            // tableTymySkupiny
            // 
            this.tableTymySkupiny.ColumnCount = 1;
            this.tableTymySkupiny.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTymySkupiny.Controls.Add(this.lsvSkupinyTymy, 0, 1);
            this.tableTymySkupiny.Controls.Add(this.lblSkupinyTymy, 0, 0);
            this.tableTymySkupiny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTymySkupiny.Location = new System.Drawing.Point(0, 0);
            this.tableTymySkupiny.Name = "tableTymySkupiny";
            this.tableTymySkupiny.RowCount = 2;
            this.tableTymySkupiny.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableTymySkupiny.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTymySkupiny.Size = new System.Drawing.Size(491, 601);
            this.tableTymySkupiny.TabIndex = 0;
            // 
            // frmHlavni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 659);
            this.Controls.Add(this.tableHlavni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHlavni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rozpis volejbalových zápasů";
            this.Load += new System.EventHandler(this.frmHlavni_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHlavni_KeyDown);
            this.tableHlavni.ResumeLayout(false);
            this.tableTlacitka.ResumeLayout(false);
            this.flowTlacitkaSprava.ResumeLayout(false);
            this.flowTlacitkaOstatni.ResumeLayout(false);
            this.splitPrehled.Panel1.ResumeLayout(false);
            this.splitPrehled.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPrehled)).EndInit();
            this.splitPrehled.ResumeLayout(false);
            this.splitZapasy.Panel1.ResumeLayout(false);
            this.splitZapasy.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitZapasy)).EndInit();
            this.splitZapasy.ResumeLayout(false);
            this.tableZapasyHriste.ResumeLayout(false);
            this.tableZapasyHriste.PerformLayout();
            this.tableZapasySkupiny.ResumeLayout(false);
            this.tableZapasySkupiny.PerformLayout();
            this.tableTymySkupiny.ResumeLayout(false);
            this.tableTymySkupiny.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableHlavni;
        private System.Windows.Forms.TableLayoutPanel tableTlacitka;
        private System.Windows.Forms.FlowLayoutPanel flowTlacitkaSprava;
        private System.Windows.Forms.FlowLayoutPanel flowTlacitkaOstatni;
        private System.Windows.Forms.SplitContainer splitPrehled;
        private System.Windows.Forms.TableLayoutPanel tableTymySkupiny;
        private System.Windows.Forms.SplitContainer splitZapasy;
        private System.Windows.Forms.TableLayoutPanel tableZapasyHriste;
        private System.Windows.Forms.TableLayoutPanel tableZapasySkupiny;
    }
}

