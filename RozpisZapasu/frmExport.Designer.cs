
namespace RozpisZapasu
{
    partial class frmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbExport = new System.Windows.Forms.ComboBox();
            this.lblCoExportovat = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSkupiny = new System.Windows.Forms.Label();
            this.cmbSkupiny = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(127, 112);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbExport
            // 
            this.cmbExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExport.FormattingEnabled = true;
            this.cmbExport.Items.AddRange(new object[] {
            "Tabulky pro danou skupinu",
            "Každý s každým"});
            this.cmbExport.Location = new System.Drawing.Point(12, 25);
            this.cmbExport.Name = "cmbExport";
            this.cmbExport.Size = new System.Drawing.Size(271, 21);
            this.cmbExport.TabIndex = 1;
            // 
            // lblCoExportovat
            // 
            this.lblCoExportovat.AutoSize = true;
            this.lblCoExportovat.Location = new System.Drawing.Point(12, 9);
            this.lblCoExportovat.Name = "lblCoExportovat";
            this.lblCoExportovat.Size = new System.Drawing.Size(150, 13);
            this.lblCoExportovat.TabIndex = 2;
            this.lblCoExportovat.Text = "Vyberte co chcete exportovat:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(208, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Storno";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblSkupiny
            // 
            this.lblSkupiny.AutoSize = true;
            this.lblSkupiny.Location = new System.Drawing.Point(12, 60);
            this.lblSkupiny.Name = "lblSkupiny";
            this.lblSkupiny.Size = new System.Drawing.Size(265, 13);
            this.lblSkupiny.TabIndex = 7;
            this.lblSkupiny.Text = "Vyberte skupinu (netýká se přehledu Každý s každým):";
            // 
            // cmbSkupiny
            // 
            this.cmbSkupiny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkupiny.FormattingEnabled = true;
            this.cmbSkupiny.Items.AddRange(new object[] {
            "Tabulky pro danou skupinu",
            "Každý s každým"});
            this.cmbSkupiny.Location = new System.Drawing.Point(12, 76);
            this.cmbSkupiny.Name = "cmbSkupiny";
            this.cmbSkupiny.Size = new System.Drawing.Size(271, 21);
            this.cmbSkupiny.TabIndex = 6;
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 147);
            this.Controls.Add(this.lblSkupiny);
            this.Controls.Add(this.cmbSkupiny);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCoExportovat);
            this.Controls.Add(this.cmbExport);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametry exportu";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbExport;
        private System.Windows.Forms.Label lblCoExportovat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSkupiny;
        private System.Windows.Forms.ComboBox cmbSkupiny;
    }
}