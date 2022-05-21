using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozpisZapasu
{
    public static class ZpracovaniPrehledu
    {
        public static Color Barva { get; set; }
        public static List<(string, int, bool)> SeznamTymu { get; set; }
        public static List<(string, int, bool)> VybraneTymy { get; set; }
        public static List<string> SeznamHrist { get; set; }
        public static List<string> VybranaHriste { get; set; }
        public static List<string> SeznamSkupin { get; set; }
        public static List<string> VybraneSkupiny { get; set; }
        public static List<(string,string)> SkupinyTymy { get; set; }

        /// <summary>
        /// Rozřazené zápasy vloží do ListView pro případnou kontrolu před exportem do Excelu
        /// </summary>
        /// <param name="list">vstupní seznam zápasů</param>
        /// <param name="listView">zobrazení zápasů</param>
        public static void ZobrazitZapasy(List<(string, string)> list, ListView listView)
        {
            string polozka = "";
            listView.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                polozka = list[i].Item1;

                ListViewItem lvi;

                lvi = new ListViewItem(polozka.Split('-')); //domácí a hosté

                lvi.SubItems.Add(list[i].Item2); //hřiště nebo skupina

                listView.Items.Add(lvi);
            }

            //vybarvení položek
            for (int i = 0; i < listView.Items.Count; i += 2)
            {
                listView.Items[i].BackColor = Barva;
            }
        }

        /// <summary>
        /// Zobrazí týmy ve skupinách
        /// </summary>
        /// <param name="list">vstupní seznam týmů ve skupinách</param>
        /// <param name="listView">zobrazení skupin a jejich členů</param>
        public static void ZobrazitSkupiny(ListView listView)
        {
            listView.Items.Clear();

            for (int i = 0; i < SkupinyTymy.Count; i++)
            {
                ListViewItem lvi;

                lvi = new ListViewItem(SkupinyTymy[i].Item1); //tým
                lvi.SubItems.Add(SkupinyTymy[i].Item2); //skupina

                listView.Items.Add(lvi);
            }

            //vybarvení položek
            for (int i = 0; i < listView.Items.Count; i += 2)
            {
                listView.Items[i].BackColor = Barva;
            }
        }

        /// <summary>
        /// Upravené pořadí zápasů uloží do seznamu 
        /// </summary>
        /// <param name="list">výstupní seznam zápasů</param>
        /// <param name="listView">zobrazené zápasy</param>
        public static void UlozitZapasy(List<(string, string)> list, ListView listView)
        {
            list.Clear();

            for (int i = 0; i < listView.Items.Count; i++)
            {
                list.Add((String.Join("-", new string[] { listView.Items[i].SubItems[0].Text, listView.Items[i].SubItems[1].Text }), listView.Items[i].SubItems[2].Text));
            }
        }

        /// <summary>
        /// Vloží názvy týmů do seznamu
        /// </summary>
        /// <returns>Vrátí seznam názvů týmů</returns>
        public static List<string> NazvyTymu()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < VybraneTymy.Count; i++)
            {
                list.Add(VybraneTymy[i].Item1);
            }

            return list;
        }
    }
}
