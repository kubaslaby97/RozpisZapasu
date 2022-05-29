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
    public partial class frmNaplneniSkupin : Form
    {
        //vybrané skupiny a týmy
        List<(string, int, bool)> tymy = ZpracovaniPrehledu.VybraneTymy;
        List<string> skupiny = ZpracovaniPrehledu.VybraneSkupiny;

        public frmNaplneniSkupin()
        {
            InitializeComponent();
        }

        private void frmNaplneniSkupin_Load(object sender, EventArgs e)
        {
            //inicializace seznamu
            ZpracovaniPrehledu.SkupinyTymy = new List<(string, string)>();

            //naplnění týmů
            for (int i = 0; i < tymy.Count; i++)
            {
                clbTymy.Items.Add(tymy[i].Item1);
            }

            //naplnění skupin
            for (int i = 0; i < skupiny.Count; i++)
            {
                cmbSkupina.Items.Add(skupiny[i]);
            }

            //nastavení textu
            cmbSkupina.Text = skupiny[0];
        }

        private void btnUlozitSkupinu_Click(object sender, EventArgs e)
        {
            if (cmbSkupina.Text == "" || cmbSkupina.Text == null)
            {
                MessageBox.Show("Nebyla vybrána skupina k uložení", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                for (int i = 0; i < clbTymy.Items.Count; i++)
                {
                    if (clbTymy.GetItemChecked(i) == true)
                    {
                        //přidání skupiny včetně týmů
                        ZpracovaniPrehledu.SkupinyTymy.Add((clbTymy.Items[i].ToString(), cmbSkupina.Text));
                    }
                }

                MessageBox.Show("Skupina '" + cmbSkupina.Text + "' byla uložena", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSkupina.Items.Remove(cmbSkupina.Text);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //upozornění pokud nebyly zařazeny všechny týmy do skupin
            if (clbTymy.Items.Count != 0 & cmbSkupina.Items.Count != 0)
            {
                MessageBox.Show("Nebyly zařazeny všechny týmy do skupin", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
