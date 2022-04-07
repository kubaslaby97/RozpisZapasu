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
        List<(string, int, bool)> tymy = ZpracovaniXML.NacteniTymu(Application.StartupPath + "\\tymy.xml");
        List<(string, int, bool, bool)> vybraneTymy = new List<(string, int, bool, bool)>();
        public frmTurnaj()
        {
            InitializeComponent();
        }

        private void frmTurnaj_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tymy.Count; i++)
            {
                clbTymy.Items.Add(tymy[i].Item1);
            }
        }

        /*private static List<(string, int, bool, bool)> VybraneTymy(List<(string, int, bool)> tymy, List<bool> hraji)
        {
            List<(string, int, bool, bool)> list = new List<(string, int, bool, bool)>();
            for (int i = 0; i < tymy.Count; i++)
            {
                list.Add((tymy[i].Item1, tymy[i].Item2, tymy[i].Item3, hraji[i]));
            }
            return list;
        }*/
    }
}
