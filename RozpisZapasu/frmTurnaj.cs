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
    public partial class frmTurnaj : Form
    {
        int pocetHrist = 0, pocetSkupin = 0;
        List<(string, int, bool)> seznamTymu = new List<(string, int, bool)>();
        List<(string, int, bool)> tymy = new List<(string, int, bool)>();
        List<string> vybraneTymy = new List<string>();

        public frmTurnaj(int pocetHrist,int pocetSkupin, List<(string, int, bool)> seznamTymu)
        {
            InitializeComponent();
            this.pocetHrist = pocetHrist;
            this.pocetSkupin = pocetSkupin;
            this.seznamTymu = seznamTymu;
        }

        private void frmTurnaj_Load(object sender, EventArgs e)
        {
            numHriste.Maximum = pocetHrist;
            numHriste.Minimum = 1;
            numHriste.Value = pocetHrist;
            numSkupiny.Maximum = pocetSkupin;
            numSkupiny.Minimum = 1;
            numSkupiny.Value = pocetSkupin;

            for (int i = 0; i < seznamTymu.Count; i++)
            {
                clbTymy.Items.Add(seznamTymu[i].Item1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //naplnění seznamu vybraných týmů
            for (int i = 0; i < clbTymy.Items.Count; i++)
            {
                if (clbTymy.GetItemChecked(i) == true)
                {
                    vybraneTymy.Add(clbTymy.Items[i].ToString());
                }
            }
            
            //zpracování vybraných týmů
            for (int i = 0; i < seznamTymu.Count; i++)
            {
                for (int j = 0; j < vybraneTymy.Count; j++)
                {
                    if (vybraneTymy[j].Contains(seznamTymu[i].Item1))
                    {
                        tymy.Add((seznamTymu[i].Item1, seznamTymu[i].Item2, seznamTymu[i].Item3));
                    }
                }
            }

            //zavření okna
            this.Close();
        }

        private void btnStorno_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //vrátí vybrané týmy
        public List<(string, int, bool)> VybraneTymy()
        {
            return tymy;
        }
        //vrátí počet hřišť
        public int PocetHrist()
        {
            return pocetHrist;
        }
        //vrátí počet skupin
        public int PocetSkupin()
        {
            return pocetSkupin;
        }
    }
}
