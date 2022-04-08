using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozpisZapasu
{
    class Validator
    {
        List<List<string>> moznosti;
        List<List<string>> vysledek = new List<List<string>>();
        int pocetHrist;
        public Validator(List<List<string>> moznosti, int pocetHrist)
        {
            this.moznosti = moznosti;
            this.pocetHrist = pocetHrist;
        }

        public void Setup()
        {
            for (int i = 0; i < moznosti.Count(); i++)
            {
                List<string> a = new List<string>();
                a.AddRange(moznosti[i]);
                vysledek.Add(a);
            }
        }
        public List<List<List<string>>> RozdeleniListu()
        {
            List<List<List<string>>> skupiny = new List<List<List<string>>>();
            foreach (List<string> moznost in moznosti)
            {
                for (int i = 0; i < moznost.Count(); i++)
                {
                    moznost[i] += "-";
                }
                var result = String.Join("", moznost.ToArray());
                moznost.Clear();
                moznost.AddRange(result.Split(new string[] { "-" }, StringSplitOptions.None));
            }
            foreach (List<string> moznost in moznosti)
            {
                List<List<string>> temp = new List<List<string>>();
                for (int i = 0; i < moznost.Count() / 2; i = i + pocetHrist)
                {
                    List<string> jednoKolo = new List<string>();
                    for (int y = i * 2; y < 2 * (pocetHrist + i); y++)
                    {
                        if (y < moznost.Count())
                        {
                            jednoKolo.Add(moznost[y]);
                        }
                    }
                    temp.Add(jednoKolo);
                }
                skupiny.Add(temp);
            }

            return skupiny;
        }
        public int NejlepsiSeznam()
        {
            List<List<List<string>>> test = RozdeleniListu();
            int max = 0;
            int index = 0;
            foreach (List<List<string>> seznam in test)
            {
                int error = 0;
                foreach (List<string> list in seznam)
                {
                    for (int i = 0; i < list.Count(); i++)
                    {
                        if (seznam.IndexOf(list) + 1 < seznam.Count())
                        {
                            if (seznam[seznam.IndexOf(list) + 1].Contains(list[i]))
                            {
                                error++;
                                if (seznam.IndexOf(list) + 2 < seznam.Count())
                                {
                                    if (seznam[seznam.IndexOf(list) + 2].Contains(list[i]))
                                    {
                                        error = error + 3;
                                    }
                                }
                            }
                        }
                    }
                    if (error > max)
                    {
                        max = error;
                        index = test.IndexOf(seznam);
                    }
                }
            }
            return index;
        }
        public List<string> VyslednyRozpis()
        {
            int index = NejlepsiSeznam();
            return vysledek[index];
        }
    }
}
