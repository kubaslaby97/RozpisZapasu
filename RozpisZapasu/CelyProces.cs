using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozpisZapasu
{
    class CelyProces
    {
        public List<string> Start(List<Skupina> s, int pocetHrist)
        {
            Turnaj t = new Turnaj(pocetHrist, s);
            Validator v = new Validator(t.rozpisy(), pocetHrist);
            v.Setup();
            return v.VyslednyRozpis();
        }
    }
}
