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

            //List<(string,int,bool,bool)> výstup a zpracuje ho kolega Vašák

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
    class Turnaj
    {
        int pocetHrist;
        List<Skupina> skupiny = new List<Skupina>();
        List<string> casRozpis = new List<string>();
        List<List<string>> moznosti = new List<List<string>>();

        public Turnaj(int pocetHrist, List<Skupina> skupiny)
        {
            this.pocetHrist = pocetHrist;
            this.skupiny = skupiny;
        }
        public int PocetHer()
        {
            int x = 0;
            foreach (Skupina y in skupiny)
            {
                x = x + y.SoucetHer();
            }
            return x;
        }
        /// <summary>
        /// Vybírá skupiny s největším počtem neodehraných her a u těch se snaží najít dvojici, která má
        /// true - true. Pokud se taková nenajde, zkusí se vzít další skupina...
        /// </summary>
        public void Rozhodovac()
        {
            bool helper = true;
            int maximalniHodnota = 0;
            int index = -1;
            foreach (Skupina skupina in skupiny)
            {
                int docasnaHodnota = skupina.PocetHer();
                if (docasnaHodnota > maximalniHodnota)
                {
                    if (skupina.JeMozneHrat(1) == true)
                    {
                        maximalniHodnota = docasnaHodnota;
                        index = skupiny.IndexOf(skupina);
                    }
                }
            }
            if (index == -1)
            {
                int max = 0;
                foreach (Skupina skupina in skupiny)
                {
                    int docasnaHodnota = skupina.PocetHer();
                    if (docasnaHodnota > max)
                    {
                        if (skupina.JeMozneHrat(2) == true)
                        {
                            max = docasnaHodnota;
                            index = skupiny.IndexOf(skupina);
                        }
                    }
                }
                if (index != -1)
                {
                    casRozpis.Add(skupiny[index].OdehratHru(2));
                }
                if (index == -1)
                {
                    int mx = 0;
                    foreach (Skupina skupina in skupiny)
                    {
                        int docasnaHodnota = skupina.PocetHer();
                        if (docasnaHodnota > max)
                        {
                            if (skupina.JeMozneHrat(3) == true)
                            {
                                mx = docasnaHodnota;
                                index = skupiny.IndexOf(skupina);
                            }
                        }
                    }
                    if (index != -1)
                    {
                        casRozpis.Add(skupiny[index].OdehratHru(3));
                    }
                    else
                        helper = false;
                }
                if (helper == false)
                {
                    Turnaj t = new Turnaj(pocetHrist, skupiny);
                    casRozpis.Clear();
                    t.RozpisTurnaje();
                }
            }
            else
            {
                casRozpis.Add(skupiny[index].OdehratHru(1));
            }
        }
        /// <summary>
        /// Metoda, která vrací vysledný časový rozpis
        /// </summary>
        /// <returns>vrátí List stringů, který vypadá "týmA-týmB"</returns>
        public List<string> KonecTurnaje()
        {
            /*foreach(string a in casRozpis)
            {
                Console.WriteLine(a);
            }*/
            //moznosti.Add(casRozpis);
            return casRozpis;
        }


        /// <summary>
        /// Podle počtu hřišt se bude volat metoda Rozhodovac dokud se nazaplní všechny hřiště v jednom kole
        /// </summary>
        /// <param name="hriste">Počet volných hřišť</param>
        public void JednoKolo(int hriste)
        {
            for (int i = 0; i < hriste; i++)
            {
                Rozhodovac();
            }
            KonecKola();
            if (casRozpis.Count == PocetHer())
            {
                List<string> test = new List<string>(casRozpis);
                moznosti.Add(test);
                casRozpis.Clear();
            }
            //Console.WriteLine("KONEC KOLA");
        }

        /// <summary>
        /// Pro všechny skupiny se zavolá jejich metoda KonecKola, která prohodí jejích true - false
        /// </summary>
        public void KonecKola()
        {
            foreach (Skupina skupina in skupiny)
            {
                skupina.KonecKola();
            }
        }
        /// <summary>
        /// Metoda, která získá list všech týmu ze skupin
        /// </summary>
        public void VypisTymu()
        {
            foreach (Skupina skupina in skupiny)
            {
                skupina.tymyVeSkupine();
            }
        }
        /// <summary>
        /// Metoda se skládá z jednotlivých metod a utvoří celý rozpis turnaje
        /// </summary>
        public void RozpisTurnaje()
        {
            int max = 0;
            foreach (Skupina s in skupiny)
            {
                s.StartTurnaje();
            }
            foreach (Skupina s in skupiny)
            {
                max = max + s.PocetHer();
            }
            double x = max / pocetHrist;
            int fullHriste = Convert.ToInt32(Math.Floor(x));
            int zbytekHrist = max - (fullHriste * pocetHrist);
            for (int i = 0; i < fullHriste; i++)
            {
                for (int y = 0; y < pocetHrist; y = y + pocetHrist)
                {
                    JednoKolo(pocetHrist);
                }
            }
            for (int t = 0; t < zbytekHrist; t++)
            {
                JednoKolo(zbytekHrist);
            }
            VypisTymu();
            KonecTurnaje();
        }
        public List<List<string>> rozpisy()
        {
            while (moznosti.Count() < 2)
            {
                RozpisTurnaje();
            }
            return moznosti;
        }
    }
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
