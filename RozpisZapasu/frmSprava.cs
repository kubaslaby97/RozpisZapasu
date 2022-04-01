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

namespace RozpisZapasu
{
    public partial class frmSprava : Form
    {
        int volba = 0;
        List<string> hriste = new List<string>();
        List<string> skupiny = new List<string>();
        List<(string, int, bool)> tymy = new List<(string, int, bool)>();
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
            //tým
            if (volba == 1)
            {
                //styl zobrazení
                lsvPolozky.View = View.Details;
                //přidání sloupců
                lsvPolozky.Columns.Add("Název").Width = 110;
                lsvPolozky.Columns.Add("Hodnocení").Width = 70;
                lsvPolozky.Columns.Add("První zápas?").Width = 80;

                //načtení souboru
                if (File.Exists(Application.StartupPath + "\\tymy.xml"))
                {
                    tymy = ZpracovaniXML.NacteniTymu(Application.StartupPath + "\\tymy.xml");
                    
                    foreach (var polozka in tymy)
                    {
                        ListViewItem lvi;

                        lvi = new ListViewItem(polozka.Item1);
                        lvi.SubItems.Add(polozka.Item2.ToString());
                        lvi.SubItems.Add(polozka.Item3.ToString());

                        lsvPolozky.Items.Add(lvi);
                    }
                }
                else
                {
                    MessageBox.Show("Soubor týmů nenalezen", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //hřiště
            else if (volba == 2)
            {
                //styl zobrazení
                lsvPolozky.View = View.List;

                //načtení souboru
                if (File.Exists(Application.StartupPath + "\\hriste.xml"))
                {
                    hriste = ZpracovaniXML.NacteniHrist(Application.StartupPath + "\\hriste.xml");

                    foreach (var polozka in hriste)
                    {
                        lsvPolozky.Items.Add(polozka);
                    }
                }
                else
                {
                    MessageBox.Show("Soubor hřišť nenalezen", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //skupina
            else if (volba == 3)
            {
                //styl zobrazení
                lsvPolozky.View = View.List;

                //načtení souboru
                if (File.Exists(Application.StartupPath + "\\skupiny.xml"))
                {
                    skupiny = ZpracovaniXML.NacteniSkupin(Application.StartupPath + "\\skupiny.xml");

                    foreach (var polozka in skupiny)
                    {
                        lsvPolozky.Items.Add(polozka);
                    }
                }
                else
                {
                    MessageBox.Show("Soubor skupin nenalezen", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
                bool prvniZapas = false;
                int hodnoceni = 0;

                if (InputBoxTym.Show("Přidat tým", "Zadejte název týmu, který chcete přidat.", ref polozka, "Hodnocení týmu (1-nejhorší až 4-nejlepší)",
                    ref hodnoceni, ref prvniZapas, overeni) == DialogResult.OK)
                {
                    ListViewItem lvi;

                    lvi = new ListViewItem(polozka);
                    lvi.SubItems.Add(hodnoceni.ToString());
                    lvi.SubItems.Add(prvniZapas.ToString());

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
            string polozka = "";

            //pokud byla vybrána položka
            if (lsvPolozky.SelectedIndices.Count > 0)
            {
                polozka = lsvPolozky.SelectedItems[0].SubItems[0].Text;

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
            //pokud nebyla vybrána položka
            else
            {
                MessageBox.Show("Nebyla vybrána žádná položka k upravení", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnOdebrat_Click(object sender, EventArgs e)
        {
            string polozka = "";

            //pokud byla vybrána položka
            if (lsvPolozky.SelectedIndices.Count > 0)
            {
                polozka = lsvPolozky.SelectedItems[0].SubItems[0].Text;

                //tým
                if (volba == 1)
                {
                    if (MessageBox.Show("Přejete si odebrat tým '" + polozka + "'?", "Upozornění",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        lsvPolozky.SelectedItems[0].Remove();
                    }
                }
                //hřiště
                else if (volba == 2)
                {
                    if (MessageBox.Show("Přejete si odebrat hřiště '" + polozka + "'?", "Upozornění",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        lsvPolozky.SelectedItems[0].Remove();
                    }
                }
                //skupina
                else if (volba == 3)
                {
                    if (MessageBox.Show("Přejete si odebrat skupinu '" + polozka + "'?", "Upozornění",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        lsvPolozky.SelectedItems[0].Remove();
                    }
                }
                else
                {
                    //Easter egg
                    MessageBox.Show("Klikej si na mě jak chceš a nic tím nezískáš :(", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //pokud nebyla vybrána položka
            else
            {
                MessageBox.Show("Nebyla vybrána žádná položka k odebrání", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnUlozit_Click(object sender, EventArgs e)
        {
            //tým
            if (volba == 1)
            {
                for (int i = 0; i < lsvPolozky.Items.Count; i++)
                {
                    tymy.Add((lsvPolozky.Items[i].Text, int.Parse(lsvPolozky.Items[i].SubItems[1].Text), bool.Parse(lsvPolozky.Items[i].SubItems[2].Text)));
                }

                ZpracovaniXML.UlozeniTymu(Application.StartupPath + "\\tymy.xml", tymy);
                MessageBox.Show("Soubor týmů byl uložen", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //hřiště
            else if (volba == 2)
            {
                for (int i = 0; i < lsvPolozky.Items.Count; i++)
                {
                    hriste.Add(lsvPolozky.Items[i].Text);
                }

                ZpracovaniXML.UlozeniHrist(Application.StartupPath + "\\hriste.xml", hriste);
                MessageBox.Show("Soubor hřišť byl uložen", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //skupina
            else if (volba == 3)
            {
                for (int i = 0; i < lsvPolozky.Items.Count; i++)
                {
                    skupiny.Add(lsvPolozky.Items[i].Text);
                }

                ZpracovaniXML.UlozeniSkupin(Application.StartupPath + "\\skupiny.xml", skupiny);
                MessageBox.Show("Soubor skupin byl uložen", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Easter egg
                MessageBox.Show("Nic tu není co bych ti uložil. Jedině zlatou cihlu ti mohu uložit. :D", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
