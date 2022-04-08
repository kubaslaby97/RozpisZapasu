using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozpisZapasu
{
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
}
