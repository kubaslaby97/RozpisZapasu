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

        public frmTurnaj()
        {
            InitializeComponent();
        }

        private void frmTurnaj_Load(object sender, EventArgs e)
        {
            ZpracovaniPrehledu.vybranaHriste = new List<string>();
            ZpracovaniPrehledu.vybraneTymy = new List<(string, int, bool)>();
            ZpracovaniPrehledu.vybraneSkupiny = new List<string>();
            for (int i = 0; i < ZpracovaniPrehledu.seznamTymu.Count; i++)
            {
                clbTymy.Items.Add(ZpracovaniPrehledu.seznamTymu[i].Item1);
            }

            for (int i = 0; i < ZpracovaniPrehledu.seznamHrist.Count; i++)
            {
                clbHriste.Items.Add(ZpracovaniPrehledu.seznamHrist[i]);
            }

            for (int i = 0; i < ZpracovaniPrehledu.seznamSkupin.Count; i++)
            {
                clbSkupiny.Items.Add(ZpracovaniPrehledu.seznamSkupin[i]);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //naplnění seznamu vybraných hřišť
            for (int i = 0; i < clbHriste.Items.Count; i++)
            {
                if (clbHriste.GetItemChecked(i) == true)
                {
                    ZpracovaniPrehledu.vybranaHriste.Add(clbHriste.Items[i].ToString());
                }
            }

            //naplnění seznamu vybraných skupin
            for (int i = 0; i < clbSkupiny.Items.Count; i++)
            {
                if (clbSkupiny.GetItemChecked(i) == true)
                {
                    ZpracovaniPrehledu.vybraneSkupiny.Add(clbSkupiny.Items[i].ToString());
                }
            }

            //naplnění seznamu vybraných týmů
            for (int i = 0; i < ZpracovaniPrehledu.seznamTymu.Count; i++)
            {
                for (int j = 0; j < clbTymy.Items.Count; j++)
                {
                    if (clbTymy.GetItemChecked(j) == true)
                    {
                        if (clbTymy.Items[j].ToString().Contains(ZpracovaniPrehledu.seznamTymu[i].Item1))
                        {
                            ZpracovaniPrehledu.vybraneTymy.Add((ZpracovaniPrehledu.seznamTymu[i].Item1, ZpracovaniPrehledu.seznamTymu[i].Item2, ZpracovaniPrehledu.seznamTymu[i].Item3));
                        }
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

        private void btnZvolitBarvu_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                ZpracovaniPrehledu.barva = cd.Color;
                picBarvaZapasu.BackColor = ZpracovaniPrehledu.barva;
                lblUkazka.BackColor = ZpracovaniPrehledu.barva;
            }
        }
    }
}
