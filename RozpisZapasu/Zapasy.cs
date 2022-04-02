using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RozpisZapasu
{
    public static class Zapasy
    {
        public static List<(string,string,string)> TvorbaZapasuHrist(List<string> tymy, List<string> hriste)
        {
            //TODO: zde se vytvoří zápasy na hřištích
            return null;
        }
        public static List<(string, string, string)> TvorbaZapasuSkupin(List<string> tymy, List<string> skupiny)
        {
            //TODO: zde se vytvoří zápasy ve skupinách
            return null;
        }
        public static List<Tuple<string,bool>> TvorbaSkupin(List<string> skupiny)
        {
            //TODO: naplnění skupin týmů
            return null;
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
