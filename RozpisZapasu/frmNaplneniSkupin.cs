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
        
        public frmNaplneniSkupin()
        {
            InitializeComponent();
        }

        private void frmNaplneniSkupin_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ZpracovaniPrehledu.VybraneTymy.Count; i++)
            {
                clbTymy.Items.Add(ZpracovaniPrehledu.VybraneTymy[i].Item1);
            }

            cmbSkupina.DataSource = ZpracovaniPrehledu.VybraneSkupiny;
        }

        private void btnUlozitSkupinu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
