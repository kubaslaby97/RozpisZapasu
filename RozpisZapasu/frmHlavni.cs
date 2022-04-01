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
        Export export = new Export();
        Zapasy zapasy = new Zapasy();
        ZpracovaniXML zpracovani = new ZpracovaniXML();

        List<(string, string, string)> hristeZapasy = new List<(string, string, string)> { ("1.","č.1","Domažlice - Brno"), ("1.", "č.2", "Karlovy Vary - Děčín"),
            ("2.", "č.1", "Ústí nad Labem - Teplice") };
        List<(string, string, string)> skupinyZapasy = new List<(string, string, string)> { ("1.","A","Domažlice - Brno"), ("1.", "B", "Karlovy Vary - Děčín"),
            ("2.", "A", "Ústí nad Labem - Teplice") };

        public frmHlavni()
        {
            InitializeComponent();
        }
        //export do Excelu
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\tymy.xml"))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Sešit aplikace MS Excel (verze 2007 a vyšší)|*.xlsx";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sfd.Title = "Export do Excelu";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    export.UlozitExcel(sfd.FileName, Color.LimeGreen, NazvyTymu(), hristeZapasy, skupinyZapasy);

                    //otevření souboru
                    Process.Start(sfd.FileName);
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
            //TODO: Rozřazení týmů do zápasů
            //Zapasy.Rozradit(tymy,skupiny,hriste)
            //týmy z XML vrátit Tuple<string,bool>
            //skupina z XML vrátit List<Tuple<string,bool>>
            //hriste z XML vrátit string

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
            List<(string, int, bool)> tymy = zpracovani.NacteniTymu(Application.StartupPath + "\\tymy.xml");

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
    }
}
