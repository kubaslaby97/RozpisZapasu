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
        List<(string, int, bool)> seznamTymu = new List<(string, int, bool)>();
        List<string> seznamHrist = new List<string>();
        List<string> seznamSkupin = new List<string>();
        List<(string, int, bool)> vybraneTymy = new List<(string, int, bool)>();
        List<string> oznaceneTymy = new List<string>();
        List<string> vybranaHriste = new List<string>();
        List<string> vybraneSkupiny = new List<string>();

        public frmTurnaj(List<(string, int, bool)> seznamTymu,List<string> seznamHrist, List<string> seznamSkupin)
        {
            InitializeComponent();
            this.seznamHrist = seznamHrist;
            this.seznamSkupin = seznamSkupin;
            this.seznamTymu = seznamTymu;
        }

        private void frmTurnaj_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < seznamTymu.Count; i++)
            {
                clbTymy.Items.Add(seznamTymu[i].Item1);
            }

            for (int i = 0; i < seznamHrist.Count; i++)
            {
                clbHriste.Items.Add(seznamHrist[i]);
            }

            for (int i = 0; i < seznamSkupin.Count; i++)
            {
                clbSkupiny.Items.Add(seznamSkupin[i]);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //naplnění seznamu vybraných hřišť
            for (int i = 0; i < clbHriste.Items.Count; i++)
            {
                if (clbHriste.GetItemChecked(i) == true)
                {
                    vybranaHriste.Add(clbHriste.Items[i].ToString());
                }
            }

            //naplnění seznamu vybraných skupin
            for (int i = 0; i < clbSkupiny.Items.Count; i++)
            {
                if (clbSkupiny.GetItemChecked(i) == true)
                {
                    vybraneSkupiny.Add(clbSkupiny.Items[i].ToString());
                }
            }

            //naplnění seznamu vybraných týmů
            for (int i = 0; i < clbTymy.Items.Count; i++)
            {
                if (clbTymy.GetItemChecked(i) == true)
                {
                    oznaceneTymy.Add(clbTymy.Items[i].ToString());
                }
            }

            //zpracování vybraných týmů
            for (int i = 0; i < seznamTymu.Count; i++)
            {
                for (int j = 0; j < oznaceneTymy.Count; j++)
                {
                    if (oznaceneTymy[j].Contains(seznamTymu[i].Item1))
                    {
                        vybraneTymy.Add((seznamTymu[i].Item1, seznamTymu[i].Item2, seznamTymu[i].Item3));
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
            return vybraneTymy;
        }

        //vrátí vybraná hřiště
        public List<string> VybranaHriste()
        {
            return vybranaHriste;
        }

        //vrátí vybrané skupiny
        public List<string> VybraneSkupiny()
        {
            return vybraneSkupiny;
        }
    }
}
