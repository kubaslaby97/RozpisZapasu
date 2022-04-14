using Microsoft.Win32;
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
        //deklarace názvů souborů
        string souborTymy = Application.StartupPath + "\\tymy.xml";
        string souborHriste = Application.StartupPath + "\\hriste.xml";
        string souborSkupiny = Application.StartupPath + "\\skupiny.xml";

        //deklarace seznamů
        List<(string, int, bool)> tymy = new List<(string, int, bool)>();
        List<string> hriste = new List<string>();
        List<string> skupiny = new List<string>();
        List<(int, string, string)> hristeZapasy = new List<(int, string, string)>();
        List<(int, string, string)> skupinyZapasy = new List<(int, string, string)>();
        List<(string, string)> skupinyTymy = new List<(string, string)>();

        Color barva = new Color();

        public frmHlavni()
        {
            InitializeComponent();
        }
        //export do Excelu
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (File.Exists(souborTymy))
            {
                if (hristeZapasy.Count == 0 || skupinyZapasy.Count == 0)
                {
                    MessageBox.Show("Nebyly nalezeny žádné zápasy skupin nebo na hřištích", "Chyba exportu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Sešit aplikace MS Excel (verze 2007 a vyšší)|*.xlsx";
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    sfd.Title = "Export do Excelu";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //kontrola zda je soubor používán
                        if (!SouborPouzivan(sfd.FileName))
                        {
                            Export.UlozitExcel(sfd.FileName, barva, NazvyTymu(), hristeZapasy, skupinyZapasy);

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
            frmSprava form = new frmSprava("Správa týmů", 1);
            form.Show();
        }
        //správa hřišť
        private void btnSpravaHrist_Click(object sender, EventArgs e)
        {
            frmSprava form = new frmSprava("Správa hřišť", 2);
            form.Show();
        }
        //správa skupin
        private void btnSpravaSkupin_Click(object sender, EventArgs e)
        {
            frmSprava form = new frmSprava("Správa skupin", 3);
            form.Show();
        }
        //tvorba zápasů a jejich zobrazení
        private void btnVytvoritTurnaj_Click(object sender, EventArgs e)
        {
            if (File.Exists(souborTymy) || File.Exists(souborHriste) || File.Exists(souborSkupiny))
            {
                tymy = ZpracovaniXML.NacteniTymu(souborTymy);
                hriste = ZpracovaniXML.NacteniHrist(souborHriste);
                skupiny = ZpracovaniXML.NacteniSkupin(souborSkupiny);

                //Zobrazení zápasů v ListView
                if (MessageBox.Show("Přejete si přepsat aktuální rozřazení týmů?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (frmTurnaj form = new frmTurnaj(tymy, hriste, skupiny))
                    {
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                tymy.Clear();
                                hriste.Clear();
                                skupiny.Clear();

                                tymy = form.VybraneTymy();
                                hriste = form.VybranaHriste();
                                skupiny = form.VybraneSkupiny();
                                barva = form.BarvaPrehledu();

                                hristeZapasy = ZpracovaniTurnaje.VyslednyRozpis(1, tymy, hriste, skupiny);
                                skupinyZapasy = ZpracovaniTurnaje.VyslednyRozpis(2, tymy, hriste, skupiny);

                                ZobrazitZapasy(hristeZapasy, barva, lsvZapasyHriste);
                                ZobrazitZapasy(skupinyZapasy, barva, lsvZapasySkupina);

                                skupinyTymy = ZpracovaniTurnaje.TymyVeSkupine(tymy, skupiny);
                                ZobrazitSkupiny(skupinyTymy, lsvSkupinyTymy);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Některý ze souborů neexistuje", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //uloží změny do seznamu
        private void btnUlozit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Přejete si uložit aktuální rozřazení týmů?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                UlozitZapasy(hristeZapasy, lsvZapasyHriste);
                UlozitZapasy(skupinyZapasy, lsvZapasySkupina);
            }
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
        }

        /// <summary>
        /// Rozřazené zápasy vloží do ListView pro případnou kontrolu před exportem do Excelu
        /// </summary>
        /// <param name="list">vstupní seznam zápasů</param>
        /// <param name="listView">zobrazení zápasů</param>
        private void ZobrazitZapasy(List<(int, string, string)> list, Color barva, ListView listView)
        {
            string polozka = "";
            listView.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                polozka = list[i].Item2;

                ListViewItem lvi;

                lvi = new ListViewItem(polozka.Split('-')); //domácí a hosté

                lvi.SubItems.Add(list[i].Item3); //hřiště nebo skupina
                lvi.SubItems.Add(list[i].Item1.ToString()); //kolo

                listView.Items.Add(lvi);
            }

            //vybarvení položek
            for (int i = 0; i < listView.Items.Count; i += 2)
            {
                listView.Items[i].BackColor = barva;
            }
        }

        /// <summary>
        /// Zobrazí týmy ve skupinách
        /// </summary>
        /// <param name="list">vstupní seznam týmů ve skupinách</param>
        /// <param name="listView">zobrazení skupin a jejich členů</param>
        private void ZobrazitSkupiny(List<(string, string)> list, ListView listView)
        {
            listView.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem lvi;

                lvi = new ListViewItem(list[i].Item1); //tým
                lvi.SubItems.Add(list[i].Item2); //skupina

                listView.Items.Add(lvi);                
            }

            //vybarvení položek
            for (int i = 0; i < listView.Items.Count; i += 2)
            {
                listView.Items[i].BackColor = barva;
            }
        }

        /// <summary>
        /// Upravené pořadí zápasů uloží do seznamu 
        /// </summary>
        /// <param name="list">výstupní seznam zápasů</param>
        /// <param name="listView">zobrazené zápasy</param>
        private void UlozitZapasy(List<(int, string, string)> list, ListView listView)
        {
            list.Clear();

            for (int i = 0; i < listView.Items.Count; i++)
            {
                list.Add((i + 1, listView.Items[i].SubItems[1].Text, listView.Items[i].SubItems[2].Text));
            }
        }

        /// <summary>
        /// Vloží názvy týmů do seznamu
        /// </summary>
        /// <returns>Vrátí seznam názvů týmů</returns>
        public List<string> NazvyTymu()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < tymy.Count; i++)
            {
                list.Add(tymy[i].Item1);
            }

            return list;
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

        /*public string ZjistitVychoziAplikaci(string priponaSouboru)
        {
            RegistryKey objExtReg = Registry.ClassesRoot;
            RegistryKey objAppReg = Registry.ClassesRoot;
            string strExtValue;

            try
            {
                if(priponaSouboru.Substring(0, 1) != ".")
                {
                    priponaSouboru = "." + priponaSouboru;
                }

                objExtReg = objExtReg.OpenSubKey(priponaSouboru.Trim());
                strExtValue = objExtReg.GetValue("").ToString();
                objAppReg = objAppReg.OpenSubKey(strExtValue + "\\shell\\open\\command");

                string[] splitArray;
                //splitArray = Split(objAppReg.GetValue(Nothing), """");

                if (splitArray[0].Trim().Length > 0)
                {
                    return splitArray[0].Replace("%1", "");
                }
                else
                {
                    return splitArray[1].Replace("%1", "");
                }
            }
            catch
            {
                return "";
            }
        }*/
    }
}
