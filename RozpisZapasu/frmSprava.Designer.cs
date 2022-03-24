
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
            this.lstPolozky = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnPridat
            // 
            this.btnPridat.Location = new System.Drawing.Point(116, 306);
            this.btnPridat.Margin = new System.Windows.Forms.Padding(4);
            this.btnPridat.Name = "btnPridat";
            this.btnPridat.Size = new System.Drawing.Size(85, 28);
            this.btnPridat.TabIndex = 0;
            this.btnPridat.Text = "Přidat";
            this.btnPridat.UseVisualStyleBackColor = true;
            this.btnPridat.Click += new System.EventHandler(this.btnPridat_Click);
            // 
            // btnUpravit
            // 
            this.btnUpravit.Location = new System.Drawing.Point(209, 306);
            this.btnUpravit.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpravit.Name = "btnUpravit";
            this.btnUpravit.Size = new System.Drawing.Size(85, 28);
            this.btnUpravit.TabIndex = 1;
            this.btnUpravit.Text = "Upravit";
            this.btnUpravit.UseVisualStyleBackColor = true;
            this.btnUpravit.Click += new System.EventHandler(this.btnUpravit_Click);
            // 
            // btnOdebrat
            // 
            this.btnOdebrat.Location = new System.Drawing.Point(303, 306);
            this.btnOdebrat.Margin = new System.Windows.Forms.Padding(4);
            this.btnOdebrat.Name = "btnOdebrat";
            this.btnOdebrat.Size = new System.Drawing.Size(85, 28);
            this.btnOdebrat.TabIndex = 2;
            this.btnOdebrat.Text = "Odebrat";
            this.btnOdebrat.UseVisualStyleBackColor = true;
            this.btnOdebrat.Click += new System.EventHandler(this.btnOdebrat_Click);
            // 
            // lstPolozky
            // 
            this.lstPolozky.FormattingEnabled = true;
            this.lstPolozky.ItemHeight = 16;
            this.lstPolozky.Items.AddRange(new object[] {
            "Položka 1",
            "Doložka 2"});
            this.lstPolozky.Location = new System.Drawing.Point(16, 15);
            this.lstPolozky.Margin = new System.Windows.Forms.Padding(4);
            this.lstPolozky.Name = "lstPolozky";
            this.lstPolozky.Size = new System.Drawing.Size(371, 276);
            this.lstPolozky.TabIndex = 3;
            // 
            // frmSprava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 350);
            this.Controls.Add(this.lstPolozky);
            this.Controls.Add(this.btnOdebrat);
            this.Controls.Add(this.btnUpravit);
            this.Controls.Add(this.btnPridat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ListBox lstPolozky;
    }
}