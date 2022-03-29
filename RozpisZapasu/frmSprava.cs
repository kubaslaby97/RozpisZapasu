using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        InputBoxValidation overeni = delegate (string val) {
            if (val == "")
                return "Hodnota nemůže být prázdná";
            return "";
        };

        private void frmSprava_Load(object sender, EventArgs e)
        {
            try
            {
                XDocument dokument = XDocument.Load(Application.StartupPath + "\\sprava.xml");
                //tým
                if (volba == 1)
                {
                    //styl zobrazení
                    lsvPolozky.View = View.Details;
                    //přidání sloupců
                    lsvPolozky.Columns.Add("Název").Width = 110;
                    lsvPolozky.Columns.Add("Hodnocení").Width = 70;
                    lsvPolozky.Columns.Add("První zápas?").Width = 80;

                    //naplnění seznamu týmů
                    foreach (var polozka in dokument.Descendants("Tym"))
                    {
                        ListViewItem lvi;

                        lvi = new ListViewItem(polozka.Element("Nazev").Value);
                        lvi.SubItems.Add(polozka.Element("Hodnoceni").Value);
                        lvi.SubItems.Add(polozka.Element("HratPrvni").Value);

                        lsvPolozky.Items.Add(lvi);
                    }

                }
                //hřiště
                else if (volba == 2)
                {
                    //styl zobrazení
                    lsvPolozky.View = View.List;

                    //naplnění seznamu hřišť
                    foreach (var polozka in dokument.Descendants("Hriste"))
                    {
                        lsvPolozky.Items.Add(polozka.Element("Nazev").Value);
                    }
                }
                //skupina
                else if (volba == 3)
                {
                    //styl zobrazení
                    lsvPolozky.View = View.List;

                    //naplnění seznamu skupin
                    foreach (var polozka in dokument.Descendants("Hriste"))
                    {
                        lsvPolozky.Items.Add(polozka.Element("Nazev").Value);
                    }
                }
                else
                {
                    //Easter egg
                    MessageBox.Show("Blbě sis vybral, končím s tebou", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Ještě jsem s tebou neskončil", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Soubor neexistuje", "Neexistující soubor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Soubor není platný", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPridat_Click(object sender, EventArgs e)
        {
            string polozka = "";

            //tým
            if (volba == 1)
            {
                bool prvniZapas = false;
                int hodnoceni = 0;

                if (InputBoxTym.Show("Přidat tým", "Zadejte název týmu, který chcete přidat.", ref polozka, "Hodnocení týmu (1-nejhorší až 4-nejlepší)",
                    ref hodnoceni, ref prvniZapas, overeni) == DialogResult.OK)
                {
                    string[] row = { polozka, hodnoceni.ToString(), prvniZapas.ToString() };
                    var lvi = new ListViewItem(row);
                    lsvPolozky.Items.Add(lvi);
                }                
            }
            //hřiště
            else if (volba == 2)
            {
                if(InputBox.Show("Přidat hřiště", "Zadejte název hřiště, které chcete přidat.", ref polozka, overeni) == DialogResult.OK)
                {
                    lsvPolozky.Items.Add(polozka);
                }
            }
            //skupina
            else if (volba == 3)
            {
                if (InputBox.Show("Přidat skupinu", "Zadejte název skupiny, kterou chcete přidat.", ref polozka, overeni) == DialogResult.OK)
                {
                    lsvPolozky.Items.Add(polozka);
                }
            }
            else
            {
                //Easter egg
                MessageBox.Show("Klikej si na mě jak chceš a nic nezískáš :(", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnUpravit_Click(object sender, EventArgs e)
        {
            string polozka = lsvPolozky.SelectedItems[0].SubItems[0].Text;

            //tým
            if (volba == 1)
            {
                int hodnoceni = int.Parse(lsvPolozky.SelectedItems[0].SubItems[1].Text);
                bool prvniZapas = bool.Parse(lsvPolozky.SelectedItems[0].SubItems[2].Text);
                if (InputBoxTym.Show("Upravit tým", "Zadejte název týmu, který chcete upravit.", ref polozka, "Hodnocení týmu", 
                    ref hodnoceni, ref prvniZapas, overeni) == DialogResult.OK)
                {
                    lsvPolozky.SelectedItems[0].SubItems[0].Text = polozka;
                    lsvPolozky.SelectedItems[0].SubItems[1].Text = hodnoceni.ToString();
                    lsvPolozky.SelectedItems[0].SubItems[2].Text = prvniZapas.ToString();
                }
            }
            //hřiště
            else if (volba == 2)
            {
                if (InputBox.Show("Upravit hřiště", "Zadejte název hřiště, které chcete upravit.", ref polozka, overeni) == DialogResult.OK)
                {
                    lsvPolozky.SelectedItems[0].SubItems[0].Text = polozka;
                }
            }
            //skupina
            else if (volba == 3)
            {
                if (InputBox.Show("Upravit skupinu", "Zadejte název skupiny, kterou chcete upravit.", ref polozka, overeni) == DialogResult.OK)
                {
                    lsvPolozky.SelectedItems[0].SubItems[0].Text = polozka;
                }
            }
            else
            {
                //Easter egg
                MessageBox.Show("Klikej si na mě jak chceš a nic tím nezískáš :(", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnOdebrat_Click(object sender, EventArgs e)
        {
            string polozka = lsvPolozky.SelectedItems[0].SubItems[0].Text;

            //tým
            if (volba == 1)
            {
                if(MessageBox.Show("Přejete si odebrat tým '" + polozka + "'?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    
                }  
            }
            //hřiště
            else if (volba == 2)
            {
                if(MessageBox.Show("Přejete si odebrat hřiště '" + polozka + "'?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    
                }
            }
            //skupina
            else if (volba == 3)
            {
                if(MessageBox.Show("Přejete si odebrat skupinu '" + polozka + "'?", "Upozornění", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    //lsvPolozky.Items.RemoveAt();
                }
            }
            else
            {
                //Easter egg
                MessageBox.Show("Klikej si na mě jak chceš a nic tím nezískáš :(", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnUlozit_Click(object sender, EventArgs e)
        {
            //tým
            if (volba == 1)
            {
                
            }
            //hřiště
            else if (volba == 2)
            {

            }
            //skupina
            else if (volba == 3)
            {

            }
            else
            {
                //Easter egg
                MessageBox.Show("Nic tu není co bych ti uložil. Jedině zlatou cihlu ti mohu uložit. :D", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
