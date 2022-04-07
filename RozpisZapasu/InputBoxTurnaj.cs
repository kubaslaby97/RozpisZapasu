using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozpisZapasu
{
    public static class InputBoxTurnaj
    {
        public static DialogResult Show(ref int pocetHrist, ref int pocetSkupin)
        {
            Form form = new Form();
            Label label = new Label();
            Label label2 = new Label();
            NumericUpDown numericUp1 = new NumericUpDown();
            NumericUpDown numericUp2 = new NumericUpDown();
            Button buttonOk = new Button();
            Button buttonStorno = new Button();

            form.Text = "Parametry turnaje";
            label.Text = "Počet hřišť";
            numericUp1.Value = pocetHrist;
            label2.Text = "Počet skupin";
            numericUp2.Value = pocetSkupin;
            numericUp2.Minimum = 1;
            numericUp2.Maximum = 4;

            buttonOk.Text = "OK";
            buttonStorno.Text = "Storno";
            buttonOk.DialogResult = DialogResult.OK;
            buttonStorno.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            numericUp1.SetBounds(12, 36, 372, 20);
            label2.SetBounds(9, 64, 372, 13);
            numericUp2.SetBounds(12, 80, 100, 20);

            buttonOk.SetBounds(228, 116, 75, 23);
            buttonStorno.SetBounds(309, 116, 75, 23);

            label.AutoSize = true;
            numericUp1.Anchor = numericUp1.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonStorno.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 151);
            form.Controls.AddRange(new Control[] { label, numericUp1, label2, numericUp2, buttonOk, buttonStorno });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonStorno;

            DialogResult dialogResult = form.ShowDialog();
            pocetHrist = (int)numericUp1.Value;
            pocetSkupin = (int)numericUp2.Value;
            return dialogResult;
        }
    }
}
