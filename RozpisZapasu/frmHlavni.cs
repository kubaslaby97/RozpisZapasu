using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozpisZapasu
{
    public partial class frmHlavni : Form
    {
        //deklarace názvů souborů
        string souborTymy = Application.StartupPath + "\\tymy.xml";
        string souborHriste = Application.StartupPath + "\\hriste.xml";
        string souborSkupiny = Application.StartupPath + "\\skupiny.xml";

        //deklarace seznamů
        List<(int, string, string)> hristeZapasy = new List<(int, string, string)>();
        List<(int, string, string)> skupinyZapasy = new List<(int, string, string)>();
        List<(string, string)> skupinyTymy = new List<(string, string)>();

        public frmHlavni()
        {
            InitializeComponent();
        }

        //export
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (File.Exists(souborTymy))
            {
                if (hristeZapasy.Count == 0 || skupinyZapasy.Count == 0)
                {
                    MessageBox.Show("Nebyly nalezeny žádné zápasy skupin nebo na hřištích", "Chyba exportu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (frmExport form = new frmExport())
                    {
                        form.ShowDialog();

                        if (Export.VybranyExport == null || Export.VybranyExport == "")
                        {
                            MessageBox.Show("Není vybrána položka k exportu", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Filter = "Sešit aplikace MS Excel (verze 2007 a vyšší)|*.xlsx|Sešit aplikace MS Excel (verze 2007 a vyšší) s podporou maker|*.xlsm";
                            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                            //titulek dialogu v závislosti na vybraném typu exportu
                            if (Export.VybranyExport == "Tabulky pro danou skupinu")
                            {
                                sfd.Title = "Export tabulek skupiny " + Export.VybranaSkupina;
                            }
                            else
                            {
                                sfd.Title = "Export přehledu " + Export.VybranyExport;
                            }  

                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                //kontrola zda je soubor používán
                                if (!SouborPouzivan(sfd.FileName))
                                {
                                    //zvolení typu souboru
                                    if (sfd.FilterIndex == 1)
                                    {
                                        Export.UlozitExcel(sfd.FileName, skupinyTymy, hristeZapasy, skupinyZapasy);
                                    }  
                                    else if (sfd.FilterIndex == 2)
                                    {
                                        Export.UlozitExcelMakra(sfd.FileName, skupinyTymy, hristeZapasy, skupinyZapasy);
                                        //vložení VBA části
                                        //VBA.PropisDatTymuSkupiny(sfd.FileName);
                                    }

                                    //ověření, zda existuje výchozí aplikace pro otevření souboru
                                    if (VychoziAplikace(sfd.FileName.Split('.').Last()) == "")
                                    {
                                        MessageBox.Show("Soubor nelze otevřít, protože není k němu přidružena žádná aplikace", "Chyba při otevírání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        //otevření souboru
                                        Process.Start(sfd.FileName);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Soubor je používán", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Soubor týmů nebyl nalezen", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Export nebyl úspěšně dokončen", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //správa týmů
        private void btnSpravaTymu_Click(object sender, EventArgs e)
        {
            frmSprava form = new frmSprava("Správa týmů", 1);
            form.Show();
        }
        //správa hřišť
        private void btnSpravaHrist_Click(object sender, EventArgs e)
        {
            frmSprava form = new frmSprava("Správa hřišť", 2);
            form.Show();
        }
        //správa skupin
        private void btnSpravaSkupin_Click(object sender, EventArgs e)
        {
            frmSprava form = new frmSprava("Správa skupin", 3);
            form.Show();
        }
        //tvorba zápasů a jejich zobrazení
        private void btnVytvoritTurnaj_Click(object sender, EventArgs e)
        {
            if (File.Exists(souborTymy) || File.Exists(souborHriste) || File.Exists(souborSkupiny))
            {
                ZpracovaniPrehledu.SeznamTymu = ZpracovaniXML.NacteniTymu(souborTymy);
                ZpracovaniPrehledu.SeznamHrist = ZpracovaniXML.NacteniHrist(souborHriste);
                ZpracovaniPrehledu.SeznamSkupin = ZpracovaniXML.NacteniSkupin(souborSkupiny);

                //Zobrazení zápasů v ListView
                if (MessageBox.Show("Přejete si přepsat aktuální rozřazení týmů?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (frmTurnaj form = new frmTurnaj())
                    {
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                hristeZapasy = ZpracovaniTurnaje.VyslednyRozpis(1, ZpracovaniPrehledu.VybraneTymy, ZpracovaniPrehledu.VybranaHriste, ZpracovaniPrehledu.VybraneSkupiny);
                                skupinyZapasy = ZpracovaniTurnaje.VyslednyRozpis(2, ZpracovaniPrehledu.VybraneTymy, ZpracovaniPrehledu.VybranaHriste, ZpracovaniPrehledu.VybraneSkupiny);

                                ZpracovaniPrehledu.ZobrazitZapasy(hristeZapasy, lsvZapasyHriste);
                                ZpracovaniPrehledu.ZobrazitZapasy(skupinyZapasy,  lsvZapasySkupina);

                                skupinyTymy = ZpracovaniTurnaje.TymyVeSkupine(ZpracovaniPrehledu.VybraneTymy, ZpracovaniPrehledu.VybraneSkupiny);
                                ZpracovaniPrehledu.ZobrazitSkupiny(skupinyTymy, lsvSkupinyTymy);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Některý ze souborů neexistuje", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //uloží změny do seznamu
        private void btnUlozit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Přejete si uložit aktuální rozřazení týmů?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                ZpracovaniPrehledu.UlozitZapasy(hristeZapasy, lsvZapasyHriste);
                ZpracovaniPrehledu.UlozitZapasy(skupinyZapasy, lsvZapasySkupina);

                ZpracovaniPrehledu.ZobrazitZapasy(hristeZapasy, lsvZapasyHriste);
                ZpracovaniPrehledu.ZobrazitZapasy(skupinyZapasy, lsvZapasySkupina);
            }
        }
        private void frmHlavni_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }
        private void frmHlavni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.C)
            {
                Autori.Show();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.H)
            {
                MessageBox.Show("Honzo vstávej. Kolik je hodin?", "Dotaz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Dvě kukaččí", "Odpověď", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lsvZapasyHriste_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lsvZapasyHriste.DoDragDrop(lsvZapasyHriste.SelectedItems, DragDropEffects.Move);
        }

        private void lsvZapasyHriste_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lsvZapasyHriste_DragDrop(object sender, DragEventArgs e)
        {
            if (lsvZapasyHriste.SelectedItems.Count == 0) { return; }

            Point pt = lsvZapasyHriste.PointToClient(new Point(e.X, e.Y));
            ListViewItem itemDrag = lsvZapasyHriste.GetItemAt(pt.X, pt.Y);

            if (itemDrag == null) { return; }

            int itemDragIndex = itemDrag.Index;
            ListViewItem[] select = new ListViewItem[lsvZapasyHriste.SelectedItems.Count];

            for(int i = 0; i < lsvZapasyHriste.SelectedItems.Count; i++)
            {
                select[i] = lsvZapasyHriste.SelectedItems[i];
            }

            for(int i = 0; i < select.GetLength(0); i++)
            {
                ListViewItem item = select[i];
                int itemIndex = itemDragIndex;

                if (itemIndex == item.Index) { return; }

                if (item.Index < itemIndex) { itemIndex++; }
                else { itemIndex = itemDragIndex + 1; }

                ListViewItem insertItem = (ListViewItem)item.Clone();
                lsvZapasyHriste.Items.Insert(itemIndex,insertItem);
                lsvZapasyHriste.Items.Remove(item);
            }
        }

        private void lsvZapasySkupina_DragDrop(object sender, DragEventArgs e)
        {
            if (lsvZapasySkupina.SelectedItems.Count == 0) { return; }

            Point pt = lsvZapasySkupina.PointToClient(new Point(e.X, e.Y));
            ListViewItem itemDrag = lsvZapasySkupina.GetItemAt(pt.X, pt.Y);

            if (itemDrag == null) { return; }

            int itemDragIndex = itemDrag.Index;
            ListViewItem[] select = new ListViewItem[lsvZapasySkupina.SelectedItems.Count];

            for (int i = 0; i < lsvZapasySkupina.SelectedItems.Count; i++)
            {
                select[i] = lsvZapasySkupina.SelectedItems[i];
            }

            for (int i = 0; i < select.GetLength(0); i++)
            {
                ListViewItem item = select[i];
                int itemIndex = itemDragIndex;

                if (itemIndex == item.Index) { return; }

                if (item.Index < itemIndex) { itemIndex++; }
                else { itemIndex = itemDragIndex + 1; }

                ListViewItem insertItem = (ListViewItem)item.Clone();
                lsvZapasySkupina.Items.Insert(itemIndex, insertItem);
                lsvZapasySkupina.Items.Remove(item);
            }
        }

        private void lsvZapasySkupina_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lsvZapasySkupina_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lsvZapasySkupina.DoDragDrop(lsvZapasySkupina.SelectedItems, DragDropEffects.Move);
        }

        //ověření, zda je soubor používán
        //převzato z: https://social.msdn.microsoft.com/Forums/vstudio/en-US/dead0507-06f5-43e0-9250-a78437956bc8/faq-how-do-i-check-whether-a-file-is-in-use?forum=netfxbcl
        private bool SouborPouzivan(string soubor)
        {
            bool uzamcen = false;
            try
            {
                FileStream fs = File.Open(soubor, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException)
            {
                uzamcen = true;
            }
            return uzamcen;
        }

        //zjištění výchozí aplikace pro danou příponu
        //převzato z: https://social.msdn.microsoft.com/Forums/vstudio/en-US/92775e57-3acd-4ea1-bf65-a25682346cfa/get-default-application-from-file-extension?forum=vbgeneral
        //přepsáno z VB.NET do C#
        private string VychoziAplikace(string priponaSouboru)
        {
            RegistryKey objExtReg = Registry.ClassesRoot;
            RegistryKey objAppReg = Registry.ClassesRoot;
            string strExtValue;

            try
            {
                if (priponaSouboru.Substring(0, 1) != ".")
                {
                    priponaSouboru = "." + priponaSouboru;
                }

                objExtReg = objExtReg.OpenSubKey(priponaSouboru.Trim());
                strExtValue = objExtReg.GetValue(null).ToString();
                objAppReg = objAppReg.OpenSubKey(strExtValue + @"\shell\open\command");

                string[] splitArray;
                splitArray = objAppReg.GetValue(null).ToString().Split('\"');

                if (splitArray[0].Trim().Length > 0)
                {
                    return splitArray[0].Replace("%1", "");
                }
                else
                {
                    return splitArray[1].Replace("%1", "");
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
