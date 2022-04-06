using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RozpisZapasu
{
    public static class Turnaje
    {
        //Třída třída = new Třída

        /// <summary>
        /// Rozpis zápasů
        /// </summary>
        /// <param name="volba">volba 1 pro hřiště a 2 pro skupiny</param>
        /// <param name="tymy">vstupní seznam týmů</param>
        /// <param name="hriste">vstupní seznam hřišť</param>
        /// <param name="skupiny">vstupní seznam skupin</param>
        /// <returns>vrátí výsledný seznam zápasů</returns>
        public static List<(int,string,string)> VyslednyRozpis(int volba, List<(string, int, bool)> tymy, List<string> hriste, List<string> skupiny)
        {
            List<(int, string, string)> list = new List<(int, string, string)>();
            List<(string, string)> zapasy = new List<(string, string)>();

            //hřiště
            if (volba == 1)
            {
                //vymazání předchozích dat
                zapasy.Clear();

                //přidělení týmů na hřiště
                zapasy = HristeZapasy(tymy, hriste);

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
        private static List<(string, string)> HristeZapasy(List<(string, int, bool)> tymy, List<string> hriste)
        {
            List<(string, string)> list = new List<(string, string)>();
            List<string> rozpis = new List<string> { "prvni-druhy", "treti-ctvrty", "paty-sesty", "sedmy-osmy", "devaty-desaty" }; //výsledek z třídy kolegy Vašáka
            //List<string> rozpis = třída.Metoda(tymy);

            //rozdělení rozpisu do hřišť
            int j = 0;
            for (int i = 0; i < rozpis.Count; i++)
            {
                if (j == hriste.Count)
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

        /*private static List<Tuple<string, bool>> TvorbaSkupin(List<(string, int, bool)> tymy, List<string> skupiny)
        {
            List<Tuple<string,bool>> list = new List<Tuple<string, bool>>();

            //TODO: naplnění skupin týmů

            return list;
        }*/

        /*private static List<Tuple<string, bool>> TymyDoTuple(List<(string, int, bool)> tymy)
        {
            List<Tuple<string, bool>> list = new List<Tuple<string, bool>>();

            //tvorba Tuple složené z Názvu a hodnoty Hrát první
            for (int i = 0; i < tymy.Count; i++)
            {
                list.Add(Tuple.Create(tymy[i].Item1, tymy[i].Item3));
            }

            return list;
        }*/
    }
}
