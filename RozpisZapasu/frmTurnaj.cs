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
            ZpracovaniPrehledu.VybranaHriste = new List<string>();
            ZpracovaniPrehledu.VybraneTymy = new List<(string, int, bool)>();
            ZpracovaniPrehledu.VybraneSkupiny = new List<string>();

            for (int i = 0; i < ZpracovaniPrehledu.SeznamTymu.Count; i++)
            {
                clbTymy.Items.Add(ZpracovaniPrehledu.SeznamTymu[i].Item1);
            }

            for (int i = 0; i < ZpracovaniPrehledu.SeznamHrist.Count; i++)
            {
                clbHriste.Items.Add(ZpracovaniPrehledu.SeznamHrist[i]);
            }

            for (int i = 0; i < ZpracovaniPrehledu.SeznamSkupin.Count; i++)
            {
                clbSkupiny.Items.Add(ZpracovaniPrehledu.SeznamSkupin[i]);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //naplnění seznamu vybraných hřišť
            for (int i = 0; i < clbHriste.Items.Count; i++)
            {
                if (clbHriste.GetItemChecked(i) == true)
                {
                    ZpracovaniPrehledu.VybranaHriste.Add(clbHriste.Items[i].ToString());
                }
            }

            //naplnění seznamu vybraných skupin
            for (int i = 0; i < clbSkupiny.Items.Count; i++)
            {
                if (clbSkupiny.GetItemChecked(i) == true)
                {
                    ZpracovaniPrehledu.VybraneSkupiny.Add(clbSkupiny.Items[i].ToString());
                }
            }

            //naplnění seznamu vybraných týmů
            for (int i = 0; i < ZpracovaniPrehledu.SeznamTymu.Count; i++)
            {
                for (int j = 0; j < clbTymy.Items.Count; j++)
                {
                    if (clbTymy.GetItemChecked(j) == true)
                    {
                        if (clbTymy.Items[j].ToString().Contains(ZpracovaniPrehledu.SeznamTymu[i].Item1))
                        {
                            ZpracovaniPrehledu.VybraneTymy.Add((ZpracovaniPrehledu.SeznamTymu[i].Item1, ZpracovaniPrehledu.SeznamTymu[i].Item2, ZpracovaniPrehledu.SeznamTymu[i].Item3));
                        }
                    }
                }
            }

            //uložení počtu setů
            Export.VitezneSety = Convert.ToInt32(numVitezneSety.Value);

            if (rbAutomaticky.Checked == true)
            {
                ZpracovaniPrehledu.ZpusobNaplneni = "Automaticky";

                //zavření okna
                this.Close();
            }
            else
            {
                ZpracovaniPrehledu.ZpusobNaplneni = "Ručně";

                using (frmNaplneniSkupin form = new frmNaplneniSkupin())
                {
                    if (form.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("Bude použit automatický způsob naplnění skupin", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ZpracovaniPrehledu.ZpusobNaplneni = "Automaticky";
                    }
                }

                //zavření okna
                this.Close();
            }
        }

        private void btnStorno_Click(object sender, EventArgs e)
        {
            //zavření okna
            this.Close();
        }

        private void btnZvolitBarvu_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                ZpracovaniPrehledu.Barva = cd.Color;
                picBarvaZapasu.BackColor = ZpracovaniPrehledu.Barva;
                lblUkazka.BackColor = ZpracovaniPrehledu.Barva;
            }
        }
    }
}
