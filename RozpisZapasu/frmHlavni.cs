using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozpisZapasu
{
    public partial class frmHlavni : Form
    {
        Export export = new Export();
        List<string> tymy = new List<string> { "Ústí nad Labem", "Praha", "Karlovy Vary", "Teplice", "Děčín", "Hradec Králové", "Liberec", "Olomouc", "Plzeň",
            "České Budějovice","Domažlice","Vyškov","Ivanovice na Hané", "Brno"};
        //List<string> pole = new List<string> { "Ústí nad Labem", "Praha", "Karlovy Vary", "Teplice", "Děčín","Ivanovice na Hané" };

        List<(string, string, string)> hristeZapasy = new List<(string, string, string)> { ("1.","č.1","Domažlice - Brno"), ("1.", "č.2", "Karlovy Vary - Děčín"),
            ("2.", "č.1", "Ústí nad Labem - Teplice") };
        List<(string, string, string)> skupinyZapasy = new List<(string, string, string)> { ("1.","A","Domažlice - Brno"), ("1.", "B", "Karlovy Vary - Děčín"),
            ("2.", "A", "Ústí nad Labem - Teplice") };

        public frmHlavni()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Sešit aplikace MS Excel (verze 2007 a vyšší)|*.xlsx";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfd.Title = "Export do Excelu";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                export.UlozitExcel(sfd.FileName, Color.LimeGreen, tymy, hristeZapasy, skupinyZapasy);

                //otevření souboru
                Process.Start(sfd.FileName);
            }
        }

        private void btnSpravaTymu_Click(object sender, EventArgs e)
        {
            frmSprava sprava = new frmSprava("Správa týmů", 1);
            sprava.Show();
        }

        private void btnSpravaHrist_Click(object sender, EventArgs e)
        {
            frmSprava sprava = new frmSprava("Správa hřišť", 2);
            sprava.Show();
        }

        private void btnSpravaSkupin_Click(object sender, EventArgs e)
        {
            frmSprava sprava = new frmSprava("Správa skupin", 3);
            sprava.Show();
        }

        private void btnRozradit_Click(object sender, EventArgs e)
        {
            //tvorba zápasů
            if (optHriste.Checked == true)
            {
                ZobrazitZapasy(hristeZapasy);
            }
            else
            {
                ZobrazitZapasy(skupinyZapasy);
            }
        }

        private void ZobrazitZapasy(List<(string, string, string)> list)
        {
            string polozka = "";
            lsvZapasy.Items.Clear();

            for(int i = 0; i < list.Count; i++)
            {
                polozka = list[i].Item3;

                ListViewItem lvi;

                lvi = new ListViewItem(polozka.Split('-')); //domácí a hosté

                lvi.SubItems.Add(DateTime.Now.ToString("g")); //čas zápasu
                lvi.SubItems.Add(list[i].Item2); //hřiště nebo skupina
                lvi.SubItems.Add(list[i].Item1); //kolo

                lsvZapasy.Items.Add(lvi);
            }
        }
    }
}
