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
            for (int i = 0; i < ZpracovaniPrehledu.SeznamTymu.Count; i++)
            {
                clbTymy.Items.Add(ZpracovaniPrehledu.SeznamTymu[i].Item1);
            }

            cmbSkupina.DataSource = ZpracovaniPrehledu.SeznamSkupin;
        }

        private void btnUlozitSkupinu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
