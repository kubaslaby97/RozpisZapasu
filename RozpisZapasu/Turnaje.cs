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

        //Tvorba zápasů na hřištích
        private static List<(string, string)> HristeZapasy(List<(string, int, bool)> tymy, List<string> hriste)
        {
            List<(string, string)> list = new List<(string, string)>();
            List<string> rozpis = new List<string> { "prvni-druhy", "treti-ctvrty", "paty-sesty", "sedmy-osmy", "devaty-desaty" }; //výsledek z třídy kolegy Vašáka
            //int pocetTymu = tymy.Count / hriste.Count;

            //rozdělení rozpisu do hřišť
            for (int i = 0; i < rozpis.Count; i++)
            {
                for(int j = 0; j < hriste.Count; j++)
                {
                    list.Add((hriste[j], rozpis[i]));
                }
            }

            return list;
        }

        //Tvorba zápasů skupin
        private static List<(string, string)> SkupinyZapasy(List<(string, int, bool)> tymy, List<string> skupiny)
        {
            List<(string, string)> list = new List<(string, string)>();
            List<string> rozpis = new List<string> { "prvni-druhy", "treti-ctvrty", "paty-sesty", "sedmy-osmy", "devaty-desaty" }; //výsledek z třídy kolegy Vašáka
            //int pocetTymu = tymy.Count / skupiny.Count;

            //rozdělení rozpisu do skupin
            for (int i = 0; i < rozpis.Count; i++)
            {
                for (int j = 0; j < skupiny.Count; j++)
                {
                    //Rozpis List<string> rozdělit do skupin podle int hodnota
                }
            }

            return list;
        }

        /*private static List<Tuple<string,bool>> TvorbaSkupin(List<string> skupiny)
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
