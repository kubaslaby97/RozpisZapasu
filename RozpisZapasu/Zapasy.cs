using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozpisZapasu
{
    public class Zapasy
    {
        public List<(string,string,string)> RozraditDoHrist(List<string> tymy, List<string> hriste)
        {
            //TODO: zde se vytvoří zápasy na hřištích
            return null;
        }
        public List<(string, string, string)> RozraditDoSkupin(List<string> tymy, List<string> skupiny)
        {
            //TODO: zde se vytvoří zápasy ve skupinách
            return null;
        }
        List<Tuple<string,bool>> Skupina(Tuple<string,bool> tymy, List<string> skupiny)
        {
            //TODO: naplnění skupin týmů
            return null;
        }
    }
}
