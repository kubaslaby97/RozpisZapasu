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
    public partial class frmSprava : Form
    {
        int volba = 0;
        public frmSprava(string titulek,int volba)
        {
            InitializeComponent();
            this.Text = titulek;
            this.volba = volba;
        }

        private void frmSprava_Load(object sender, EventArgs e)
        {
            if (volba == 1)
            {
                //týmy
            }
            else if (volba == 2)
            {
                //hřiště
            }
            else if (volba == 3)
            {
                //skupiny
            }
            else
            {
                MessageBox.Show("Špatná volba", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
