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
        public static List<(string,string,string)> TvorbaZapasu(int volba, List<(string, int, bool)> tymy, List<string> hriste, List<string> skupiny)
        {
            List<(string, string, string)> list = new List<(string, string, string)>();
            //tvorba zápasů na hřištích
            if (volba == 1)
            {
                //TODO: zde se vytvoří zápasy na hřištích
                return list;
            }
            //tvorba zápasů ve skupinách
            else if (volba == 2)
            {
                //TODO: zde se vytvoří zápasy ve skupinách

                return list;
            }
            //easter egg
            else
            {
                list = new List<(string, string, string)> { ("2021/2022", "KI/PROJ", "PřF-UJEP"), ("2021/2022", "Jan Jiřička", "Jakub Slabý-Jiří Vašák") };
                return list;
            }
        }

        private static List<Tuple<string,bool>> TvorbaSkupin(List<string> skupiny)
        {
            List<Tuple<string,bool>> list = new List<Tuple<string, bool>>();

            //TODO: naplnění skupin týmů

            return list;
        }

        private static List<Tuple<string, bool>> TymyDoTuple(List<(string, int, bool)> tymy)
        {
            List<Tuple<string, bool>> list = new List<Tuple<string, bool>>();

            //tvorba Tuple složené z Názvu a hodnoty Hrát první
            for (int i = 0; i < tymy.Count; i++)
            {
                list.Add(Tuple.Create(tymy[i].Item1, tymy[i].Item3));
            }

            return list;
        }
    }
}
