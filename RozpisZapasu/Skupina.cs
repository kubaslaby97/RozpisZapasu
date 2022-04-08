using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozpisZapasu
{
    //PS: asi by to mělo být všechno private jen jsem blbej
    class Skupina
    {
        List<Tuple<string, bool>> group = new List<Tuple<string, bool>>();
        List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> vsechnyHry = new List<Tuple<Tuple<string, bool>, Tuple<string, bool>>>();
        List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> odehraneZapasy = new List<Tuple<Tuple<string, bool>, Tuple<string, bool>>>();
        List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> casovyRozpis = new List<Tuple<Tuple<string, bool>, Tuple<string, bool>>>();


        public Skupina(List<Tuple<string, bool>> group)
        {
            this.group = group;
        }

        /// <summary>
        /// Metoda provede rozpis všech možných dvojic každý s každým, které se zapíší do listu spolechaHra
        /// </summary>
        public void StartTurnaje()
        {
            vsechnyHry.Clear();
            casovyRozpis.Clear();
            odehraneZapasy.Clear();
            foreach (Tuple<string, bool> tym in group)
            {
                int counter = group.IndexOf(tym) + 1;
                while (counter < group.Count())
                {
                    Tuple<Tuple<string, bool>, Tuple<string, bool>> spolecnaHra = new Tuple<Tuple<string, bool>, Tuple<string, bool>>(tym, group[counter]);
                    vsechnyHry.Add(spolecnaHra);
                    counter++;
                }
            }
        }

        public List<string> tymyVeSkupine()
        {
            List<string> tymySkupina = new List<string>();
            foreach (Tuple<string, bool> tym in group)
            {
                tymySkupina.Add(tym.Item1);
            }
            return tymySkupina;
        }
        //Jenom pomocná metoda pro přehled (zbytečná)
        public int SoucetHer()
        {
            int x = (group.Count() * (group.Count() - 1)) / 2;
            return x;
        }
        /// <summary>
        /// Metoda nachází všechny možné dvojice podle parametru. Podle parametru hledá TRUE = TRUE; TRUE = FALSE; FALSE = FALSE;
        /// </summary>
        /// <param name="moznost">Určuje jaká podmínka se splní</param>
        /// <returns>Vrací list všech možných dvojic z dané podmínky</returns>
        public List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> MozneZapasy(int moznost)
        {
            List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> mozneZapasy = new List<Tuple<Tuple<string, bool>, Tuple<string, bool>>>();
            Random rnd = new Random();

            if (moznost == 1)
            {
                foreach (Tuple<Tuple<string, bool>, Tuple<string, bool>> dvojice in vsechnyHry)
                {
                    if (dvojice.Item1.Item2 == true && dvojice.Item2.Item2 == true)
                    {
                        if (Validator(dvojice) == true)
                        {
                            mozneZapasy.Add(dvojice);
                        }
                    }
                }
            }
            if (moznost == 2)
            {
                foreach (Tuple<Tuple<string, bool>, Tuple<string, bool>> dvojice in vsechnyHry)
                {
                    if (dvojice.Item1.Item2 == false && dvojice.Item2.Item2 == true || dvojice.Item1.Item2 == true && dvojice.Item2.Item2 == false)
                    {
                        if (Validator(dvojice) == true)
                        {
                            mozneZapasy.Add(dvojice);
                        }
                    }
                }
            }
            if (moznost == 3)
            {
                foreach (Tuple<Tuple<string, bool>, Tuple<string, bool>> dvojice in vsechnyHry)
                {
                    if (dvojice.Item1.Item2 == false && dvojice.Item2.Item2 == false)
                    {
                        if (Validator(dvojice) == true)
                        {
                            mozneZapasy.Add(dvojice);
                        }
                    }
                }
            }

            return mozneZapasy;
        }
        /// <summary>
        /// Z listu mozneZapasy se vybere náhodná dvojice, která odehraje zápas.
        /// </summary>
        /// <param name="moznost">Určuje podle jakého kritéria se budou volit týmy v metotě mozneZapasy</param>
        public string OdehratHru(int moznost)
        {
            Random rnd = new Random();
            string zapas = "X";
            List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> mozneZapasy = MozneZapasy(moznost);
            if (mozneZapasy.Count() > 0)
            {
                int x = rnd.Next(0, mozneZapasy.Count());
                odehraneZapasy.Add(mozneZapasy[x]);
                casovyRozpis.Add(mozneZapasy[x]);
                //Console.WriteLine($"Hraje {mozneZapasy[x].Item1.Item1} proti {mozneZapasy[x].Item2.Item1}");
                zapas = mozneZapasy[x].Item1.Item1 + "-" + mozneZapasy[x].Item2.Item1;
            }
            return zapas;
        }
        /// <summary>
        /// Metoda zajištuje aby žádný tým nemohl hrát paralelně.
        /// </summary>
        /// <param name="dvojice">Dvojice týmů, které chceme zkontrolovat</param>
        /// <returns>Metoda vrací true/false podle toho zda je tým pro kolo volný, nebo ne.</returns>
        public bool Validator(Tuple<Tuple<string, bool>, Tuple<string, bool>> dvojice)
        {
            bool x = true;
            foreach (Tuple<Tuple<string, bool>, Tuple<string, bool>> zapas in odehraneZapasy)
            {
                if (zapas.Item1.Item1 == dvojice.Item1.Item1 || zapas.Item1.Item1 == dvojice.Item2.Item1)
                {
                    x = false;
                }
                if (zapas.Item2.Item1 == dvojice.Item1.Item1 || zapas.Item2.Item1 == dvojice.Item2.Item1)
                {
                    x = false;
                    return x;
                }
            }
            return x;
        }

        /// <summary>
        /// Metoda nastaví všem týmům, které nehráli poslední kolo hodnotu TRUE. A týmům s odehraným zápasem dá FALSE.
        /// </summary>
        public void KonecKola()
        {
            foreach (Tuple<Tuple<string, bool>, Tuple<string, bool>> odehranaHra in odehraneZapasy)
            {
                if (vsechnyHry.Contains(odehranaHra))
                {
                    vsechnyHry.Remove(odehranaHra);
                }
            }
            for (int i = 0; i < vsechnyHry.Count(); i++)
            {
                vsechnyHry[i] = Tuple.Create(Tuple.Create(vsechnyHry[i].Item1.Item1, true), Tuple.Create(vsechnyHry[i].Item2.Item1, true));
            }
            foreach (Tuple<Tuple<string, bool>, Tuple<string, bool>> odehranaHra in odehraneZapasy)
            {
                for (int i = 0; i < vsechnyHry.Count(); i++)
                {
                    if (odehranaHra.Item1.Item1 == vsechnyHry[i].Item1.Item1)
                    {
                        vsechnyHry[i] = Tuple.Create(Tuple.Create(vsechnyHry[i].Item1.Item1, false), Tuple.Create(vsechnyHry[i].Item2.Item1, vsechnyHry[i].Item2.Item2));
                    }
                    if (odehranaHra.Item1.Item1 == vsechnyHry[i].Item2.Item1)
                    {
                        vsechnyHry[i] = Tuple.Create(Tuple.Create(vsechnyHry[i].Item1.Item1, vsechnyHry[i].Item1.Item2), Tuple.Create(vsechnyHry[i].Item2.Item1, false));
                    }
                    if (odehranaHra.Item2.Item1 == vsechnyHry[i].Item1.Item1)
                    {
                        vsechnyHry[i] = Tuple.Create(Tuple.Create(vsechnyHry[i].Item1.Item1, false), Tuple.Create(vsechnyHry[i].Item2.Item1, vsechnyHry[i].Item2.Item2));
                    }
                    if (odehranaHra.Item2.Item1 == vsechnyHry[i].Item2.Item1)
                    {
                        vsechnyHry[i] = Tuple.Create(Tuple.Create(vsechnyHry[i].Item1.Item1, vsechnyHry[i].Item1.Item2), Tuple.Create(vsechnyHry[i].Item2.Item1, false));
                    }
                }
            }
            odehraneZapasy.Clear();
        }

        /// <summary>
        /// Metoda vrací počet neodehraných her.
        /// </summary>
        /// <returns>int celkového počtu neodehranných her</returns>
        public int PocetHer()
        {
            int x = vsechnyHry.Count() - odehraneZapasy.Count();
            return x;
        }

        /// <summary>
        /// Metoda JeMozneHrat volá metodu MozneZapasy. A snaží se najít co nejlepší dvojici. 
        /// </summary>
        /// <param name="swap">Parametr, který určuje vstup pro metodu MozneZapasy</param>
        /// <returns>Vrací nám true pokud se najde dvojice. Jinak false</returns>
        /// <remarks>Nejdřív se metoda mozneZapasy zavolá jen pro TRUE,TRUE.
        /// Pokud se žádná dvojice nenajde, bude se hledat TRUE,FALSE.
        /// Pokud ani taková dvojice se nenajde. Musí se vzít nějaká dvojice, která má FALSE,FALSE.
        /// </remarks>
        public bool JeMozneHrat(int swap)
        {
            if (swap == 1)
            {
                List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> mozneZapasy = MozneZapasy(1);
                if (mozneZapasy.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            if (swap == 2)
            {
                List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> mozneZapasy = MozneZapasy(2);
                if (mozneZapasy.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                List<Tuple<Tuple<string, bool>, Tuple<string, bool>>> mozneZapasy = MozneZapasy(3);
                if (mozneZapasy.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }

        }
    }
}
