
namespace RozpisZapasu
{
    partial class frmSprava
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
            this.btnPridat = new System.Windows.Forms.Button();
            this.btnUpravit = new System.Windows.Forms.Button();
            this.btnOdebrat = new System.Windows.Forms.Button();
            this.lsvPolozky = new System.Windows.Forms.ListView();
            this.btnUlozit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPridat
            // 
            this.btnPridat.Location = new System.Drawing.Point(12, 249);
            this.btnPridat.Name = "btnPridat";
            this.btnPridat.Size = new System.Drawing.Size(64, 23);
            this.btnPridat.TabIndex = 0;
            this.btnPridat.Text = "Přidat";
            this.btnPridat.UseVisualStyleBackColor = true;
            this.btnPridat.Click += new System.EventHandler(this.btnPridat_Click);
            // 
            // btnUpravit
            // 
            this.btnUpravit.Location = new System.Drawing.Point(82, 249);
            this.btnUpravit.Name = "btnUpravit";
            this.btnUpravit.Size = new System.Drawing.Size(64, 23);
            this.btnUpravit.TabIndex = 1;
            this.btnUpravit.Text = "Upravit";
            this.btnUpravit.UseVisualStyleBackColor = true;
            this.btnUpravit.Click += new System.EventHandler(this.btnUpravit_Click);
            // 
            // btnOdebrat
            // 
            this.btnOdebrat.Location = new System.Drawing.Point(152, 249);
            this.btnOdebrat.Name = "btnOdebrat";
            this.btnOdebrat.Size = new System.Drawing.Size(64, 23);
            this.btnOdebrat.TabIndex = 2;
            this.btnOdebrat.Text = "Odebrat";
            this.btnOdebrat.UseVisualStyleBackColor = true;
            this.btnOdebrat.Click += new System.EventHandler(this.btnOdebrat_Click);
            // 
            // lsvPolozky
            // 
            this.lsvPolozky.HideSelection = false;
            this.lsvPolozky.Location = new System.Drawing.Point(12, 12);
            this.lsvPolozky.Name = "lsvPolozky";
            this.lsvPolozky.Size = new System.Drawing.Size(279, 231);
            this.lsvPolozky.TabIndex = 4;
            this.lsvPolozky.UseCompatibleStateImageBehavior = false;
            this.lsvPolozky.View = System.Windows.Forms.View.Details;
            // 
            // btnUlozit
            // 
            this.btnUlozit.Location = new System.Drawing.Point(222, 249);
            this.btnUlozit.Name = "btnUlozit";
            this.btnUlozit.Size = new System.Drawing.Size(69, 23);
            this.btnUlozit.TabIndex = 5;
            this.btnUlozit.Text = "Uložit";
            this.btnUlozit.UseVisualStyleBackColor = true;
            this.btnUlozit.Click += new System.EventHandler(this.btnUlozit_Click);
            // 
            // frmSprava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 284);
            this.Controls.Add(this.btnUlozit);
            this.Controls.Add(this.lsvPolozky);
            this.Controls.Add(this.btnOdebrat);
            this.Controls.Add(this.btnUpravit);
            this.Controls.Add(this.btnPridat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSprava";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Správa";
            this.Load += new System.EventHandler(this.frmSprava_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPridat;
        private System.Windows.Forms.Button btnUpravit;
        private System.Windows.Forms.Button btnOdebrat;
        private System.Windows.Forms.ListView lsvPolozky;
        private System.Windows.Forms.Button btnUlozit;
    }
}