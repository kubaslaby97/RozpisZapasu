using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RozpisZapasu
{
    public static class ZpracovaniTurnaje
    {
        /// <summary>
        /// Rozpis zápasů
        /// </summary>
        /// <param name="volba">volba 1 pro hřiště a 2 pro skupiny</param>
        /// <param name="tymy">vstupní seznam týmů</param>
        /// <param name="hriste">vstupní seznam hřišť</param>
        /// <param name="skupiny">vstupní seznam skupin</param>
        /// <returns>vrátí výsledný seznam zápasů</returns>
        public static List<(int, string, string)> VyslednyRozpis(int volba, List<(string, int, bool)> tymy, List<string> hriste, List<string> skupiny, int pocetSkupin, int pocetHrist)
        {
            List<(int, string, string)> list = new List<(int, string, string)>();
            List<(string, string)> zapasy = new List<(string, string)>();

            //hřiště
            if (volba == 1)
            {
                //vymazání předchozích dat
                zapasy.Clear();

                //přidělení týmů na hřiště
                zapasy = HristeZapasy(tymy, hriste, pocetSkupin, pocetHrist);

                //naplnění výsledného rozpisu
                for (int i = 0; i < zapasy.Count; i++)
                {
                    list.Add((i + 1, zapasy[i].Item1, zapasy[i].Item2));
                }

                return list;
            }
            //skupiny
            else if (volba == 2)
            {
                //vymazání předchozích dat
                zapasy.Clear();

                //přidělení týmů do skupin
                zapasy = SkupinyZapasy(tymy, skupiny);

                //naplnění výsledného rozpisu
                for (int i = 0; i < zapasy.Count; i++)
                {
                    list.Add((i + 1, zapasy[i].Item1, zapasy[i].Item2));
                }

                return list;
            }
            //easter egg
            else
            {
                list = new List<(int, string, string)> { (2021, "KI/PROJ", "PřF UJEP-SK Volejbal"), (2022, "Jan Jiřička", "Jakub Slabý-Jiří Vašák") };
                return list;
            }
        }

        /// <summary>
        /// Rozdělení zápasů na hřiště
        /// </summary>
        /// <param name="tymy">vstupní seznam týmů</param>
        /// <param name="hriste">vstupní seznam hřišť</param>
        /// <returns>Vrátí seznam zápasů na hřištích</returns>
        private static List<(string, string)> HristeZapasy(List<(string, int, bool)> tymy, List<string> hriste, int pocetSkupin, int pocetHrist)
        {
            List<(string, string)> list = new List<(string, string)>();
            List<string> rozpis = VytvoreniRozpisu(VytvoreniSkupin(tymy,pocetSkupin), pocetHrist);

            //rozdělení rozpisu do hřišť
            int j = 0;
            for (int i = 0; i < rozpis.Count; i++)
            {
                if (j == pocetHrist)
                {
                    j = 0;
                }
                list.Add((hriste[j], rozpis[i]));
                j++;  
            }
            return list;
        }

        //Tvorba zápasů skupin
        private static List<(string, string)> SkupinyZapasy(List<(string, int, bool)> tymy, List<string> skupiny)
        {
            List<(string, string)> list = new List<(string, string)>();
            List<string> rozpis = new List<string> { "prvni-druhy", "treti-ctvrty", "paty-sesty", "sedmy-osmy", "devaty-desaty" }; //výsledek z třídy kolegy Vašáka
            //List<string> rozpis = třída.Metoda(tymy);

            //rozdělení rozpisu do skupin
            int j = 0;
            for (int i = 0; i < rozpis.Count; i++)
            {
                if (j == skupiny.Count)
                {
                    j = 0;
                }
                list.Add((skupiny[j], rozpis[i]));
                j++;
            }
            return list;
        }

        /// <summary>
        /// Metoda vytvoří Listy pro jednotlivé skupiny.
        /// </summary>
        /// <param name="tymy">vstupní seznam týmů</param>
        /// <param name="pocetSkupin">počet skupin, který se ziská z gui</param>
        /// <returns>Vrací Listy tymů v jednotlivých skupinách</returns>
        private static List<List<Tuple<string, bool>>> VytvoreniSkupin(List<(string, int, bool)> tymy, int pocetSkupin)
        {
            tymy = tymy.OrderByDescending(t => t.Item2).ToList();

            List<List<Tuple<string, bool>>> list = new List<List<Tuple<string, bool>>>();
            for (int i = 0; i < pocetSkupin; i++)
            {
                List<Tuple<string, bool>> skupina = new List<Tuple<string, bool>>();
                list.Add(skupina);
            }

            int x = 0;
            for (int i = 0; i < tymy.Count(); i++)
            {
                list[x].Add(Tuple.Create(tymy[i].Item1, tymy[i].Item3));
                x++;
                if (x == pocetSkupin)
                    x = 0;
            }

            return list;
        }

        /// <summary>
        /// Výsledná metoda pro vytvoření časového rozpisu
        /// </summary>
        /// <param name="list">Vstupuje do ní List skupin a počet hřišť</param>
        /// <param name="pocetHrist"></param>
        /// <returns>Vrací nám List stringů ve tvaru "TýmA-TýmB" </returns>
        private static List<string> VytvoreniRozpisu(List<List<Tuple<string, bool>>> list, int pocetHrist)
        {
            List<Skupina> s = new List<Skupina>();
            foreach (List<Tuple<string, bool>> skupina in list)
            {
                Skupina s1 = new Skupina(skupina);
                s.Add(s1);
            }
            CelyProces c = new CelyProces();
            List<string> vystup = c.Start(s, pocetHrist);

            return vystup;
        }
    }
}
