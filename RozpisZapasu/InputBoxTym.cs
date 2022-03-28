using System;
using System.Drawing;
using System.Windows.Forms;

public class InputBoxTym
{
    public static DialogResult Show(string titulek, string textZpravy, ref string hodnota1, string textZpravy2, ref int hodnota2, ref bool hodnota3)
    {
        return Show(titulek, textZpravy, ref hodnota1, textZpravy2, ref hodnota2, ref hodnota3, null);
    }

    public static DialogResult Show(string titulek, string textZpravy, ref string hodnota1, string textZpravy2, ref int hodnota2, ref bool hodnota3,
                                    InputBoxValidation overeni)
    {
        Form form = new Form();
        Label label = new Label();
        Label label2 = new Label();
        TextBox textBox = new TextBox();
        NumericUpDown numericUp = new NumericUpDown();
        CheckBox checkBox = new CheckBox();
        Button buttonOk = new Button();
        Button buttonStorno = new Button();

        form.Text = titulek;
        label.Text = textZpravy;
        textBox.Text = hodnota1;
        label2.Text = textZpravy2;
        numericUp.Value = hodnota2;
        checkBox.Text = "První zápas?";
        checkBox.Checked = hodnota3;

        buttonOk.Text = "OK";
        buttonStorno.Text = "Storno";
        buttonOk.DialogResult = DialogResult.OK;
        buttonStorno.DialogResult = DialogResult.Cancel;

        label.SetBounds(9, 20, 372, 13);
        textBox.SetBounds(12, 36, 372, 20);
        label2.SetBounds(9, 64, 372, 13);
        
        numericUp.SetBounds(12, 80, 100, 20);
        checkBox.SetBounds(12, 116, 100, 20);
        buttonOk.SetBounds(228, 116, 75, 23);
        buttonStorno.SetBounds(309, 116, 75, 23);

        label.AutoSize = true;
        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonStorno.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        form.ClientSize = new Size(396, 151);
        form.Controls.AddRange(new Control[] { label, textBox, label2, numericUp, checkBox, buttonOk, buttonStorno });
        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimizeBox = false;
        form.MaximizeBox = false;
        form.AcceptButton = buttonOk;
        form.CancelButton = buttonStorno;
        if (overeni != null)
        {
            form.FormClosing += delegate (object sender, FormClosingEventArgs e) {
                if (form.DialogResult == DialogResult.OK)
                {
                    string chybovyText = overeni(textBox.Text);
                    if (e.Cancel = (chybovyText != ""))
                    {
                        MessageBox.Show(form, chybovyText, "Chyba ověření",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox.Focus();
                    }
                }
            };
        }
        DialogResult dialogResult = form.ShowDialog();
        hodnota1 = textBox.Text;
        return dialogResult;
    }
}
public delegate string InputBoxTymValidation(string chybovaZprava);