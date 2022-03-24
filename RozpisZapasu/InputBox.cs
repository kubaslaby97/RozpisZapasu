using System;
using System.Drawing;
using System.Windows.Forms;

public class InputBox
{
    public static DialogResult Show(string titulek, string textZpravy, ref string hodnota)
    {
        return Show(titulek, textZpravy, ref hodnota, null);
    }

    public static DialogResult Show(string titulek, string textZpravy, ref string hodnota,
                                    InputBoxValidation overeni)
    {
        Form form = new Form();
        Label label = new Label();
        TextBox textBox = new TextBox();
        Button buttonOk = new Button();
        Button buttonStorno = new Button();

        form.Text = titulek;
        label.Text = textZpravy;
        textBox.Text = hodnota;

        buttonOk.Text = "OK";
        buttonStorno.Text = "Storno";
        buttonOk.DialogResult = DialogResult.OK;
        buttonStorno.DialogResult = DialogResult.Cancel;

        label.SetBounds(9, 20, 372, 13);
        textBox.SetBounds(12, 36, 372, 20);
        buttonOk.SetBounds(228, 72, 75, 23);
        buttonStorno.SetBounds(309, 72, 75, 23);

        label.AutoSize = true;
        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonStorno.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        form.ClientSize = new Size(396, 107);
        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonStorno });
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
        hodnota = textBox.Text;
        return dialogResult;
    }
}
public delegate string InputBoxValidation(string chybovaZprava);