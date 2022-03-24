using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozpisZapasu
{
    public partial class frmSprava : Form
    {
        int volba = 0;
        public frmSprava(string titulek,int volba)
        {
            InitializeComponent();
            this.Text = titulek;
            this.volba = volba;
        }

        private void frmSprava_Load(object sender, EventArgs e)
        {
            if (volba == 1)
            {
                //týmy
            }
            else if (volba == 2)
            {
                //hřiště
            }
            else if (volba == 3)
            {
                //skupiny
            }
            else
            {
                //Easter egg
                MessageBox.Show("Blbě sis vybral, končím s tebou", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Ještě jsem s tebou neskončil", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPridat_Click(object sender, EventArgs e)
        {
            string polozka = "";
            //tým
            if (volba == 1)
            {
                InputBox.Show("Přidat tým", "Zadejte název týmu, který chcete přidat.", ref polozka);
            }
            //hřiště
            else if (volba == 2)
            {
                InputBox.Show("Přidat hřiště", "Zadejte název hřiště, které chcete přidat.", ref polozka);
            }
            //skupina
            else if (volba == 3)
            {
                InputBox.Show("Přidat skupinu", "Zadejte název skupiny, kterou chcete přidat.", ref polozka);
            }
            else
            {
                //Easter egg
                MessageBox.Show("Klikej si na mě jak chceš a nic nezískáš :(", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            lstPolozky.Items.Add(polozka);
        }

        private void btnUpravit_Click(object sender, EventArgs e)
        {
            string polozka = lstPolozky.SelectedItem.ToString();

            //tým
            if (volba == 1)
            {
                InputBox.Show("Upravit tým", "Zadejte název týmu, který chcete upravit.", ref polozka);
            }
            //hřiště
            else if (volba == 2)
            {
                InputBox.Show("Upravit hřiště", "Zadejte název hřiště, které chcete upravit.", ref polozka);
            }
            //skupina
            else if (volba == 3)
            {
                InputBox.Show("Upravit skupinu", "Zadejte název skupiny, kterou chcete upravit.", ref polozka);
            }
            else
            {
                //Easter egg
                MessageBox.Show("Klikej si na mě jak chceš a nic tím nezískáš :(", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnOdebrat_Click(object sender, EventArgs e)
        {
            string polozka = lstPolozky.SelectedItem.ToString();

            //tým
            if (volba == 1)
            {
                if(MessageBox.Show("Přejete si odebrat tým " + polozka + "?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (lstPolozky.Items.Contains(polozka))
                    {
                        lstPolozky.Items.Remove(polozka);
                    }
                }  
            }
            //hřiště
            else if (volba == 2)
            {
                if(MessageBox.Show("Přejete si odebrat hřiště " + polozka + "?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (lstPolozky.Items.Contains(polozka))
                    {
                        lstPolozky.Items.Remove(polozka);
                    }
                }
            }
            //skupina
            else if (volba == 3)
            {
                if(MessageBox.Show("Přejete si odebrat skupinu " + polozka + "?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (lstPolozky.Items.Contains(polozka))
                    {
                        lstPolozky.Items.Remove(polozka);
                    }
                }
            }
            else
            {
                //Easter egg
                MessageBox.Show("Klikej si na mě jak chceš a nic tím nezískáš :(", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
