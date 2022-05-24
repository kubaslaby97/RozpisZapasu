
namespace RozpisZapasu
{
    partial class frmNaplneniSkupin
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
            this.cmbSkupina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clbTymy = new System.Windows.Forms.CheckedListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnStorno = new System.Windows.Forms.Button();
            this.btnUlozitSkupinu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbSkupina
            // 
            this.cmbSkupina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkupina.FormattingEnabled = true;
            this.cmbSkupina.Location = new System.Drawing.Point(12, 25);
            this.cmbSkupina.Name = "cmbSkupina";
            this.cmbSkupina.Size = new System.Drawing.Size(292, 21);
            this.cmbSkupina.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vybrat skupinu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vybrat týmy:";
            // 
            // clbTymy
            // 
            this.clbTymy.FormattingEnabled = true;
            this.clbTymy.Location = new System.Drawing.Point(12, 79);
            this.clbTymy.Name = "clbTymy";
            this.clbTymy.Size = new System.Drawing.Size(292, 259);
            this.clbTymy.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(148, 344);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnStorno
            // 
            this.btnStorno.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStorno.Location = new System.Drawing.Point(229, 344);
            this.btnStorno.Name = "btnStorno";
            this.btnStorno.Size = new System.Drawing.Size(75, 25);
            this.btnStorno.TabIndex = 5;
            this.btnStorno.Text = "Storno";
            this.btnStorno.UseVisualStyleBackColor = true;
            // 
            // btnUlozitSkupinu
            // 
            this.btnUlozitSkupinu.Location = new System.Drawing.Point(12, 344);
            this.btnUlozitSkupinu.Name = "btnUlozitSkupinu";
            this.btnUlozitSkupinu.Size = new System.Drawing.Size(88, 25);
            this.btnUlozitSkupinu.TabIndex = 6;
            this.btnUlozitSkupinu.Text = "Uložit skupinu";
            this.btnUlozitSkupinu.UseVisualStyleBackColor = true;
            this.btnUlozitSkupinu.Click += new System.EventHandler(this.btnUlozitSkupinu_Click);
            // 
            // frmNaplneniSkupin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 381);
            this.ControlBox = false;
            this.Controls.Add(this.btnUlozitSkupinu);
            this.Controls.Add(this.btnStorno);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.clbTymy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSkupina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNaplneniSkupin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Naplnění skupin";
            this.Load += new System.EventHandler(this.frmNaplneniSkupin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSkupina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbTymy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnStorno;
        private System.Windows.Forms.Button btnUlozitSkupinu;
    }
}