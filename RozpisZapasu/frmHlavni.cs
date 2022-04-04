using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozpisZapasu
{
    public partial class frmHlavni : Form
    {
        //deklarace seznamů
        List<(string, int, bool)> tymy = new List<(string, int, bool)>();
        List<string> hriste = new List<string>();
        List<string> skupiny = new List<string>();
        List<(string, string, string)> hristeZapasy = new List<(string, string, string)> ();
        List<(string, string, string)> skupinyZapasy = new List<(string, string, string)> ();

        public frmHlavni()
        {
            InitializeComponent();
        }
        //export do Excelu
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\tymy.xml"))
            {
                if(hristeZapasy.Count==0 && skupinyZapasy.Count == 0)
                {
                    MessageBox.Show("Nebyly nalezeny žádné zápasy", "Chyba exportu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Sešit aplikace MS Excel (verze 2007 a vyšší)|*.xlsx";
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    sfd.Title = "Export do Excelu";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (!SouborPouzivan(sfd.FileName))
                        {
                            Export.UlozitExcel(sfd.FileName, Color.LimeGreen, NazvyTymu(), hristeZapasy, skupinyZapasy);

                            //otevření souboru
                            Process.Start(sfd.FileName);
                        }
                        else
                        {
                            MessageBox.Show("Soubor je používán", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Soubor týmů nebyl nalezen", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Export nebyl úspěšně dokončen", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //správa týmů
        private void btnSpravaTymu_Click(object sender, EventArgs e)
        {
            frmSprava sprava = new frmSprava("Správa týmů", 1);
            sprava.Show();
        }
        //správa hřišť
        private void btnSpravaHrist_Click(object sender, EventArgs e)
        {
            frmSprava sprava = new frmSprava("Správa hřišť", 2);
            sprava.Show();
        }
        //správa skupin
        private void btnSpravaSkupin_Click(object sender, EventArgs e)
        {
            frmSprava sprava = new frmSprava("Správa skupin", 3);
            sprava.Show();
        }
        //tvorba zápasů a jejich zobrazení
        private void btnRozradit_Click(object sender, EventArgs e)
        {
            hristeZapasy = Turnaje.TvorbaZapasu(3,tymy, hriste, skupiny);
            skupinyZapasy = Turnaje.TvorbaZapasu(3, tymy, hriste, skupiny);

            //Zobrazení zápasů v ListView
            if (MessageBox.Show("Přejete si přepsat aktuální rozřazení týmů?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                ZobrazitZapasy(hristeZapasy, lsvZapasyHriste);
                ZobrazitZapasy(skupinyZapasy, lsvZapasySkupina);
            }
        }

        /// <summary>
        /// Rozřazené zápasy vloží do ListView pro případnou kontrolu před exportem do Excelu
        /// </summary>
        /// <param name="list">vstupní seznam zápasů</param>
        /// <param name="listView">zobrazení zápasů</param>
        private void ZobrazitZapasy(List<(string, string, string)> list, ListView listView)
        {
            string polozka = "";
            listView.Items.Clear();

            for(int i = 0; i < list.Count; i++)
            {
                polozka = list[i].Item3;

                ListViewItem lvi;

                lvi = new ListViewItem(polozka.Split('-')); //domácí a hosté

                lvi.SubItems.Add(list[i].Item2); //hřiště nebo skupina
                lvi.SubItems.Add(list[i].Item1); //kolo

                listView.Items.Add(lvi);
            }
        }

        public List<string> NazvyTymu()
        {
            List<string> list = new List<string>();
            tymy = ZpracovaniXML.NacteniTymu(Application.StartupPath + "\\tymy.xml");

            for (int i = 0; i < tymy.Count; i++)
            {
                list.Add(tymy[i].Item1);
            }

            return list;
        }

        private void btnUlozit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Neimplementováno");
        }

        //ověření, zda je soubor používán
        //převzato z: https://social.msdn.microsoft.com/Forums/vstudio/en-US/dead0507-06f5-43e0-9250-a78437956bc8/faq-how-do-i-check-whether-a-file-is-in-use?forum=netfxbcl
        private bool SouborPouzivan(string soubor)
        {
            bool uzamcen = false;
            try
            {
                FileStream fs = File.Open(soubor, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException)
            {
                uzamcen = true;
            }
            return uzamcen;
        }

        private void frmHlavni_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void frmHlavni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.C)
            {
                Autori.Show();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.H)
            {
                MessageBox.Show("Honzo vstávej. Kolik je hodin?", "Dotaz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Dvě kukaččí", "Odpověď", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Enter){
                //zatím nemám vymyšleno
            }
        }
    }
}
