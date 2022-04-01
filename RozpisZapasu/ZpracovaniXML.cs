﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RozpisZapasu
{
    public class ZpracovaniXML
    {
        /// <summary>
        /// Načítá týmy z XML
        /// </summary>
        /// <param name="souborXML">vstupní XML soubor</param>
        /// <returns>Vrátí seznam týmů</returns>
        public List<(string, int, bool)> NacteniTymu(string souborXML)
        {
            List<(string, int, bool)> list = new List<(string, int, bool)>();
            XDocument xml = XDocument.Load(souborXML);

            //naplnění seznamu týmů
            foreach (var polozka in xml.Descendants("Tym"))
            {
                list.Add((polozka.Element("Nazev").Value, int.Parse(polozka.Element("Hodnoceni").Value), bool.Parse(polozka.Element("HratPrvni").Value)));
            }

            return list;
        }

        /// <summary>
        /// Načítá skupiny z XML
        /// </summary>
        /// <param name="souborXML">vstupní XML soubor</param>
        /// <returns>Vrátí seznam skupin</returns>
        public List<string> NacteniSkupin(string souborXML)
        {
            List<string> list = new List<string>();
            XDocument xml = XDocument.Load(souborXML);

            //naplnění seznamu týmů
            foreach (var polozka in xml.Descendants("Skupina"))
            {
                list.Add(polozka.Element("Nazev").Value);
            }

            return list;
        }

        /// <summary>
        /// Načítá hřiště z XML
        /// </summary>
        /// <param name="souborXML">vstupní XML soubor</param>
        /// <returns>Vrátí seznam hřišť</returns>
        public List<string> NacteniHrist(string souborXML)
        {
            List<string> list = new List<string>();
            XDocument xml = XDocument.Load(souborXML);

            //naplnění seznamu týmů
            foreach (var polozka in xml.Descendants("Hriste"))
            {
                list.Add(polozka.Element("Nazev").Value);
            }

            return list;
        }

        /// <summary>
        /// Uložení seznamu týmů do souboru
        /// </summary>
        /// <param name="souborXML">výstupní XML soubor</param>
        /// <param name="list">vstupní seznam týmů</param>
        public void UlozeniTymu(string souborXML, List<(string,int,bool)> list)
        {
            XDocument xml = new XDocument();
            XElement koren = new XElement("Sprava");
            for (int i = 0; i < list.Count; i++)
            {
                XElement potomek = new XElement("Tym");
                potomek.Add(new XElement("Nazev", list[i].Item1));
                potomek.Add(new XElement("Hodnoceni", list[i].Item2));
                potomek.Add(new XElement("HratPrvni", list[i].Item3));
                koren.Add(potomek);
            }
            xml.Add(koren);
            xml.Save(souborXML);
        }

        /// <summary>
        /// Uložení seznamu hřišť do souboru
        /// </summary>
        /// <param name="souborXML">výstupní XML soubor</param>
        /// <param name="list">vstupní seznam hřišť</param>
        public void UlozeniHrist(string souborXML, List<string> list)
        {
            XDocument xml = new XDocument();
            XElement koren = new XElement("Sprava");
            for (int i = 0; i < list.Count; i++)
            {
                XElement potomek = new XElement("Hriste");
                potomek.Add(new XElement("Nazev", list[i]));
                koren.Add(potomek);
            }

            xml.Add(koren);
            xml.Save(souborXML);
        }

        /// <summary>
        /// Uložení seznamu skupin do souboru
        /// </summary>
        /// <param name="souborXML">výstupní XML soubor</param>
        /// <param name="list">vstupní seznam skupin</param>
        public void UlozeniSkupin(string souborXML, List<string> list)
        {
            XDocument xml = new XDocument();
            XElement koren = new XElement("Sprava");
            for (int i = 0; i < list.Count; i++)
            {
                XElement potomek = new XElement("Skupina");
                potomek.Add(new XElement("Nazev", list[i]));
                koren.Add(potomek);
            }

            xml.Add(koren);
            xml.Save(souborXML);
        }
    }
}
