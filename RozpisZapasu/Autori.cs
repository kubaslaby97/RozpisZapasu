using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozpisZapasu
{
    public static class Autori
    {
        public static DialogResult Show()
        {
            Form form = new Form();

            form.Text = "Autoři";
            form.BackColor = Color.Black;
            form.ClientSize = new Size(300, 300);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ShowInTaskbar = false;
            form.Paint += Form_Paint;
            
            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        private static void Form_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, Form.ActiveForm.ClientSize.Width - 1, Form.ActiveForm.ClientSize.Height - 1);
            e.Graphics.DrawRectangle(Pens.Black, rect);

            using (Font font = new Font("Courier New", 30, GraphicsUnit.Pixel))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    e.Graphics.DrawString(
                        "Odprezentoval:\n" +
                        "Jan Jiřička\n\n" +
                        "Největší dříči:\n" +
                        "Jiří Vašák\n" +
                        "Jakub Slabý",
                        font, Brushes.Green, rect, sf);
                } 
            }
        }
    }
}
