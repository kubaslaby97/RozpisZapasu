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
            //týmy
            if (volba == 1)
            {
                //styl zobrazení
                lsvPolozky.View = View.Details;
                //přidání sloupců
                lsvPolozky.Columns.Add("Název").Width=120;
                lsvPolozky.Columns.Add("Hodnocení").Width = 60;
                lsvPolozky.Columns.Add("První zápas?").Width = 80;
                
            }
            //hřiště
            else if (volba == 2)
            {
                //styl zobrazení
                lsvPolozky.View = View.List;
            }
            //skupiny
            else if (volba == 3)
            {
                //styl zobrazení
                lsvPolozky.View = View.List;
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
            string[] polozky = new string[3];

            //tým
            if (volba == 1)
            {
                bool prvniZapas = false;
                int hodnoceni = 0;
                if(InputBoxTym.Show("Přidat tým", "Zadejte název týmu, který chcete přidat.", ref polozka, "Hodnocení týmu (1-nejhorší až 4-nejlepší)",ref hodnoceni, ref prvniZapas) == DialogResult.OK)
                {
                    if (hodnoceni > 4 && hodnoceni == 0)
                    {
                        MessageBox.Show("Hodnocení nebylo zadáno správně", "Neplatná hodnota", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                
            }
            //hřiště
            else if (volba == 2)
            {
                InputBox.Show("Přidat hřiště", "Zadejte název hřiště, které chcete přidat.", ref polozka);
                //lsvPolozky.Items.Add(polozka);
                //ListViewItem new_item = lsvPolozky.Items.Add(polozka);

                // Make the sub-items.
                /*for (int i = 1; i < items.Length; i++)
                    new_item.SubItems.Add(items[i]);*/
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
            
            lsvPolozky.Items.Add(polozka);
        }

        private void btnUpravit_Click(object sender, EventArgs e)
        {
            string polozka = lsvPolozky.Text;
            int polozka2 = 0;

            //tým
            if (volba == 1)
            {
                bool prvniZapas = true;
                InputBoxTym.Show("Upravit tým", "Zadejte název týmu, který chcete upravit.", ref polozka, "Hodnocení týmu", ref polozka2, ref prvniZapas);
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
            string polozka = lsvPolozky.Text;

            //tým
            if (volba == 1)
            {
                if(MessageBox.Show("Přejete si odebrat tým " + polozka + "?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    
                }  
            }
            //hřiště
            else if (volba == 2)
            {
                if(MessageBox.Show("Přejete si odebrat hřiště " + polozka + "?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    
                }
            }
            //skupina
            else if (volba == 3)
            {
                if(MessageBox.Show("Přejete si odebrat skupinu " + polozka + "?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    //lsvPolozky.Items.RemoveAt();
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
