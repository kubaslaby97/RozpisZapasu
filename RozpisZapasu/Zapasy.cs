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
        public static List<(string,string,string)> TvorbaZapasuHrist(List<(string, int, bool)> tymy, List<string> hriste)
        {
            List<(string, string, string)> list = new List<(string, string, string)>();

            //TODO: zde se vytvoří zápasy na hřištích

            return list;
        }
        public static List<(string, string, string)> TvorbaZapasuSkupin(List<(string,int,bool)> tymy, List<string> skupiny)
        {
            List<(string, string, string)> list = new List<(string, string, string)>();

            //TODO: zde se vytvoří zápasy ve skupinách

            return list;
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
