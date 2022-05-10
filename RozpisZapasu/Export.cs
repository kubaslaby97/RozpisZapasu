using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace RozpisZapasu
{
    public static class Export
    {
        public static string VybranyExport { get; set; }
        public static string VybranaSkupina { get; set; }
        /// <summary>
        /// Export dokumentu ve formátu MS Excel
        /// </summary>
        /// <param name="nazev">nazev dokumentu</param>
        /// <param name="makra">podpora maker (*.xlsm)</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        /// <param name="hristeZapasy">zápasy na hřištích</param>
        /// <param name="skupinyZapasy">zápasy ve skupinách</param>
        public static void UlozitExcel(string nazev, bool makra, List<(string, string)> skupinyTymy, List<(int, string, string)> hristeZapasy, List<(int, string, string)> skupinyZapasy)
        {
            byte[] byteArray;

            if (makra == true)
            {
                byteArray = File.ReadAllBytes("sablonyExcel\\sablona.xltm");
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(byteArray, 0, (int)byteArray.Length);
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, true))
                    {
                        //změna typu dokumentu
                        doc.ChangeDocumentType(SpreadsheetDocumentType.MacroEnabledWorkbook);
                        VytvoritObsah(doc, skupinyTymy, hristeZapasy, skupinyZapasy);
                    }
                    File.WriteAllBytes(nazev, stream.ToArray());
                }
            }
            else
            {
                byteArray = File.ReadAllBytes("sablonyExcel\\sablona.xltx");
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(byteArray, 0, (int)byteArray.Length);
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, true))
                    {
                        //změna typu dokumentu
                        doc.ChangeDocumentType(SpreadsheetDocumentType.Workbook);
                        VytvoritObsah(doc, skupinyTymy, hristeZapasy, skupinyZapasy);
                    }
                    File.WriteAllBytes(nazev, stream.ToArray());
                }
            }
        }

        private static void VytvoritObsah(SpreadsheetDocument doc, List<(string, string)> skupinyTymy, List<(int, string, string)> hristeZapasy, List<(int, string, string)> skupinyZapasy)
        {
            WorkbookPart wbPart = doc.WorkbookPart;

            //obsah listů
            WorksheetPart wsPart1 = (WorksheetPart)wbPart.GetPartById(doc.WorkbookPart.Workbook.Descendants<Sheet>().First(s => s.Name.Equals("Křížová tabulka")).Id);
            KrizovaTabulka(wsPart1, ListTymu(skupinyTymy));

            WorksheetPart wsPart2 = (WorksheetPart)wbPart.GetPartById(doc.WorkbookPart.Workbook.Descendants<Sheet>().First(s => s.Name.Equals("Klasická tabulka")).Id);
            KlasickaTabulka(wsPart2, ListTymu(skupinyTymy));

            WorksheetPart wsPart3 = (WorksheetPart)wbPart.GetPartById(doc.WorkbookPart.Workbook.Descendants<Sheet>().First(s => s.Name.Equals("Každý s každým")).Id);
            ZapasyHriste(wsPart3, hristeZapasy);

            WorksheetPart wsPart4 = (WorksheetPart)wbPart.GetPartById(doc.WorkbookPart.Workbook.Descendants<Sheet>().First(s => s.Name.Equals("Skupinový turnaj")).Id);
            ZapasySkupina(wsPart4, skupinyZapasy);

            //Přidání stylu
            WorkbookStylesPart stylePart = doc.WorkbookPart.WorkbookStylesPart;
            stylePart.Stylesheet = GenerateStylesheet();
            stylePart.Stylesheet.Save();
        }
       
        /// <summary>
        /// Provede zápis do listu Křížová tabulka
        /// </summary>
        /// <param name="wsPart">část list</param>
        /// <param name="tymy">vstupní seznam týmů</param>
        private static void KrizovaTabulka(WorksheetPart wsPart, List<string> tymy)
        {
            string[] hlavicka = new string[] { "Body", "Skóre", "Pořadí" };
            Worksheet ws = wsPart.Worksheet;
            SheetData sd = ws.GetFirstChild<SheetData>();

            Columns cols = ws.InsertBefore(new Columns(), sd);
            Column col = new Column() { Min = (UInt32Value)1U, Max = (UInt32Value)1U, Width = tymy.Max(tym => tym.Length), CustomWidth = true };
            cols.Append(col);

            for (int radek = 0; radek < tymy.Count + 1; radek++)
            {
                for (int sloupec = 0; sloupec < tymy.Count + hlavicka.Length + 1; sloupec++)
                {
                    Row row = new Row { RowIndex = (UInt32)(radek + 1) };
                    Cell cell;

                    //vybarvení
                    if (radek == sloupec)
                    {
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                        cell.StyleIndex = 2;
                        row.Append(cell);
                    }
                    else
                    {
                        //vyplnění týmů
                        if (sloupec < tymy.Count + 1)
                        {
                            //týmy v řádku
                            if (radek == 0 && sloupec > 0)
                            {
                                cell = new Cell();
                                cell.CellValue = new CellValue(tymy[sloupec - 1]);
                                cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                                cell.DataType = CellValues.String;
                                cell.StyleIndex = 4;
                                row.Append(cell);
                            }
                            //týmy ve sloupci
                            else if (radek > 0 && sloupec == 0)
                            {
                                cell = new Cell();
                                cell.CellValue = new CellValue(tymy[radek - 1]);
                                cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                                cell.DataType = CellValues.String;
                                cell.StyleIndex = 2;
                                row.Append(cell);
                            }
                            //ohraničení zbytku v tabulce
                            else if (radek > 0 & sloupec > 0)
                            {
                                cell = new Cell();
                                cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                                cell.StyleIndex = 1;
                                row.Append(cell);
                            }
                        }
                    }
                    //vyplnění hlavičky vedle týmů
                    if (sloupec >= tymy.Count + 1)
                    {
                        if (radek == 0)
                        {
                            cell = new Cell();
                            cell.CellValue = new CellValue(hlavicka[sloupec - (tymy.Count + 1)]);
                            cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                            cell.DataType = CellValues.String;
                            cell.StyleIndex = 5;
                            row.Append(cell);
                        }
                        //ohraničení zbytku pod hlavičkou
                        else if (radek > 0)
                        {
                            cell = new Cell();
                            cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                            cell.StyleIndex = 1;
                            row.Append(cell);
                        }
                    }
                    sd.Append(row);
                }
            }
        }
        /// <summary>
        /// Provede zápis do listu Klasická tabulka
        /// </summary>
        /// <param name="wsPart">část list</param>
        /// <param name="tymy">vstupní seznam týmů</param>
        private static void KlasickaTabulka(WorksheetPart wsPart, List<string> tymy)
        {
            string[] hlavicka = new string[] { "Pořadí", "Tým", "Zápasy", "Výhry", "Remízy", "Prohry", "Skóre", "Body" };
            Worksheet ws = wsPart.Worksheet;
            SheetData sd = ws.GetFirstChild<SheetData>();

            Columns cols = ws.InsertBefore(new Columns(), sd);
            Column col = new Column() { Min = (UInt32Value)2U, Max = (UInt32Value)2U, Width = tymy.Max(tym => tym.Length), CustomWidth = true };
            cols.Append(col);

            for (int radek = 0; radek < tymy.Count + 1; radek++)
            {
                for (int sloupec = 0; sloupec < hlavicka.Length; sloupec++)
                {
                    Row row = new Row { RowIndex = (UInt32)(radek + 1) };
                    Cell cell;

                    //vyplnění hlavičky
                    if (radek == 0)
                    {
                        cell = new Cell();
                        cell.CellValue = new CellValue(hlavicka[sloupec]);
                        cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                        row.Append(cell);
                    }
                    else if (radek > 0)
                    {
                        //vyplnění pořadí
                        if (sloupec == 0)
                        {
                            cell = new Cell();
                            cell.CellValue = new CellValue(radek);
                            cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                            cell.DataType = CellValues.Number;
                            cell.StyleIndex = 1;
                            row.Append(cell);
                        }
                        //vyplnění týmů
                        else if (sloupec == 1)
                        {
                            cell = new Cell();
                            cell.CellValue = new CellValue(tymy[radek - 1]);
                            cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                            cell.DataType = CellValues.String;
                            cell.StyleIndex = 1;
                            row.Append(cell);
                        }
                        //ohraničení zbytku
                        else if (sloupec > 1)
                        {
                            cell = new Cell();
                            cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                            cell.StyleIndex = 1;
                            row.Append(cell);
                        }
                    }
                    sd.Append(row);
                }
            }
        }
        /// <summary>
        /// Provede zápis do listu Skupinový turnaj
        /// </summary>
        /// <param name="wsPart">část list</param>
        /// <param name="skupinyZapasy">zápasy ve skupinách</param>
        private static void ZapasySkupina(WorksheetPart wsPart, List<(int, string, string)> skupinyZapasy)
        {
            string[] hlavicka = new string[] { "Kolo", "Zápas", "Skupina", "Skóre" };
            Worksheet ws = wsPart.Worksheet;
            SheetData sd = ws.GetFirstChild<SheetData>();

            Columns cols = ws.InsertBefore(new Columns(), sd);
            Column col = new Column() { Min = (UInt32Value)2U, Max = (UInt32Value)2U, Width = NejdelsiRetezec(skupinyZapasy, 2), CustomWidth = true };
            Column col1 = new Column() { Min = (UInt32Value)3U, Max = (UInt32Value)3U, Width = NejdelsiRetezec(skupinyZapasy, 3), CustomWidth = true };
            cols.Append(col);
            cols.Append(col1);

            MergeCells mergeCells = new MergeCells();
            MergeCell mergeCell = new MergeCell();

            for (int radek = 0; radek < skupinyZapasy.Count + 2; radek++)
            {
                for (int sloupec = 0; sloupec < hlavicka.Length; sloupec++)
                {
                    Row row = new Row { RowIndex = (UInt32)(radek + 1) };
                    Cell cell;

                    //perioda
                    if (radek == 0 && sloupec == 0)
                    {
                        cell = new Cell();
                        cell.CellValue = new CellValue("1.perioda");
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                        //sloučení buňek
                        mergeCell.Reference = new StringValue(SloupecNaZnak(1) + (radek + 1) + ":" + SloupecNaZnak(hlavicka.Length) + (radek + 1));
                        row.Append(cell);
                    }
                    //vyplnění hlavičky
                    else if (radek == 1)
                    {
                        cell = new Cell();
                        cell.CellValue = new CellValue(hlavicka[sloupec]);
                        cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                        row.Append(cell);
                    }
                    //vyplnění zbytku
                    else if (radek > 1)
                    {
                        cell = new Cell();
                        cell.CellValue = new CellValue(skupinyZapasy[radek - 2].Item1);
                        cell.CellReference = SloupecNaZnak(1) + (radek + 1).ToString();
                        cell.DataType = CellValues.Number;
                        cell.StyleIndex = 1;
                        row.Append(cell);

                        cell = new Cell();
                        cell.CellValue = new CellValue(skupinyZapasy[radek - 2].Item2);
                        cell.CellReference = SloupecNaZnak(2) + (radek + 1).ToString();
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 1;
                        row.Append(cell);

                        cell = new Cell();
                        cell.CellValue = new CellValue(skupinyZapasy[radek - 2].Item3);
                        cell.CellReference = SloupecNaZnak(3) + (radek + 1).ToString();
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 1;
                        row.Append(cell);

                        cell = new Cell();
                        cell.CellReference = SloupecNaZnak(4) + (radek + 1).ToString();
                        cell.StyleIndex = 1;
                        row.Append(cell);
                    }
                    sd.Append(row);
                }
            }

            ws.InsertAfter(mergeCells, ws.Elements<SheetData>().First());
            mergeCells.Append(mergeCell);
            ws.Save();
        }
        /// <summary>
        /// Provede zápis do listu Turnaje na hřištích
        /// </summary>
        /// <param name="wsPart">část list</param>
        /// <param name="hristeZapasy">zápasy na hřištích</param>
        private static void ZapasyHriste(WorksheetPart wsPart, List<(int, string, string)> hristeZapasy)
        {
            string[] hlavicka = new string[] { "Kolo", "Zápas", "Hřiště", "Skóre" };
            Worksheet ws = wsPart.Worksheet;
            SheetData sd = ws.GetFirstChild<SheetData>();

            Columns cols = ws.InsertBefore(new Columns(), sd);
            Column col = new Column() { Min = (UInt32Value)2U, Max = (UInt32Value)2U, Width = NejdelsiRetezec(hristeZapasy, 2), CustomWidth = true };
            Column col1 = new Column() { Min = (UInt32Value)3U, Max = (UInt32Value)3U, Width = NejdelsiRetezec(hristeZapasy, 3), CustomWidth = true };
            cols.Append(col);
            cols.Append(col1);

            MergeCells mergeCells = new MergeCells();
            MergeCell mergeCell = new MergeCell();

            for (int radek = 0; radek < hristeZapasy.Count + 2; radek++)
            {
                for (int sloupec = 0; sloupec < hlavicka.Length; sloupec++)
                {
                    Row row = new Row { RowIndex = (UInt32)(radek + 1) };
                    Cell cell;

                    //perioda
                    if (radek == 0 && sloupec == 0)
                    {
                        cell = new Cell();
                        cell.CellValue = new CellValue("1.perioda");
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                        //sloučení buňek
                        mergeCell.Reference = new StringValue(SloupecNaZnak(1) + (radek + 1) + ":" + SloupecNaZnak(hlavicka.Length) + (radek + 1));
                        row.Append(cell);
                    }
                    //vyplnění hlavičky
                    else if (radek == 1)
                    {
                        cell = new Cell();
                        cell.CellValue = new CellValue(hlavicka[sloupec]);
                        cell.CellReference = SloupecNaZnak(sloupec + 1) + (radek + 1).ToString();
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                        row.Append(cell);
                    }
                    //vyplnění zbytku
                    else if (radek > 1)
                    {
                        cell = new Cell();
                        cell.CellValue = new CellValue(hristeZapasy[radek - 2].Item1);
                        cell.CellReference = SloupecNaZnak(1) + (radek + 1).ToString();
                        cell.DataType = CellValues.Number;
                        cell.StyleIndex = 1;
                        row.Append(cell);

                        cell = new Cell();
                        cell.CellValue = new CellValue(hristeZapasy[radek - 2].Item2);
                        cell.CellReference = SloupecNaZnak(2) + (radek + 1).ToString();
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 1;
                        row.Append(cell);

                        cell = new Cell();
                        cell.CellValue = new CellValue(hristeZapasy[radek - 2].Item3);
                        cell.CellReference = SloupecNaZnak(3) + (radek + 1).ToString();
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 1;
                        row.Append(cell);

                        cell = new Cell();
                        cell.CellReference = SloupecNaZnak(4) + (radek + 1).ToString();
                        cell.StyleIndex = 1;
                        row.Append(cell);
                    }
                    sd.Append(row);
                }
            }

            ws.InsertAfter(mergeCells, ws.Elements<SheetData>().First());
            mergeCells.Append(mergeCell);
            ws.Save();
        }
        /// <summary>
        /// vytvoří styly, které lze aplikovat do listů
        /// </summary>
        /// <returns>Vrátí styly</returns>
        private static Stylesheet GenerateStylesheet()
        {
            Stylesheet styleSheet = null;

            Fonts fonts = new Fonts(
                new Font( // Index 0 - výchozí
                    new FontSize() { Val = 10 }

                ),
                new Font( // Index 1 - tučné
                    new FontSize() { Val = 10 },
                    new Bold()));

            Fills fills = new Fills(
                new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - výchozí
                new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }), // Index 1 - výchozí
                new Fill(new PatternFill(new ForegroundColor
                {
                    Rgb = new HexBinaryValue()
                    {
                        Value = ZpracovaniPrehledu.Barva.R.ToString("X2") + ZpracovaniPrehledu.Barva.G.ToString("X2") + ZpracovaniPrehledu.Barva.B.ToString("X2")
                    }
                })
                { PatternType = PatternValues.Solid })); // Index 2 - výplň

            Borders borders = new Borders(
                    new Border(), // Index 0 - výchozí
                    new Border( // Index 1 - černé tenké ohraničení
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder()),
                    new Border( // Index 2 - černé tlusté ohraničení
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thick },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thick },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thick },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thick },
                        new DiagonalBorder()));

            CellFormats cellFormats = new CellFormats(
                new CellFormat(), // Index 0 - výchozí
                new CellFormat
                {
                    FontId = 0,
                    FillId = 0,
                    BorderId = 1,
                    ApplyBorder = true
                }, // Index 1 - normální písmo a tenké ohraničení
                new CellFormat
                {
                    FontId = 1,
                    FillId = 2,
                    BorderId = 1,
                    ApplyFill = true,
                }, // Index 2 - tučné písmo, tenké ohraničení a výplň
                new CellFormat
                {
                    FontId = 0,
                    FillId = 0,
                    BorderId = 2,
                    ApplyFill = true
                }, // Index 3 - normální písmo a tlusté ohraničení
                new CellFormat
                {
                    FontId = 1,
                    FillId = 2,
                    BorderId = 1,
                    ApplyFill = true,
                    Alignment = new Alignment { TextRotation = (UInt32Value)90U }
                }, // Index 4 - tučné písmo, tenké ohraničení, orientace textu 90 stupňů a výplň
                new CellFormat
                {
                    FontId = 0,
                    FillId = 0,
                    BorderId = 1,
                    ApplyBorder = true,
                    Alignment = new Alignment { TextRotation = (UInt32Value)90U }
                } // Index 5 - normální písmo, orientace textu 90 stupňů a tenké ohraničení
                );

            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);

            return styleSheet;
        }
        /// <summary>
        /// Převede sloupec na znak
        /// </summary>
        /// <param name="sloupec">číslo sloupce</param>
        /// <returns>Vrátí znak sloupce (např. pro 1 vrátí A)</returns>
        private static string SloupecNaZnak(int sloupec)
        {
            int div = sloupec;
            string znakSloupce = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                znakSloupce = (char)(65 + mod) + znakSloupce;
                div = (int)((div - mod) / 26);
            }
            return znakSloupce;
        }
        /// <summary>
        /// Nalezne nejdelší řetězec v poli na základě vybraného pořadí v kolekci
        /// </summary>
        /// <param name="kolekce">vstupní kolekce</param>
        /// <param name="volbaPoradi">volba pořadí položky v kolekci</param>
        /// <returns>vrací písmeno odpovídající číslu sloupce</returns>
        private static int NejdelsiRetezec(List<(int, string, string)> kolekce, int volbaPoradi)
        {
            List<string> pole = new List<string>();
            for (int i = 0; i < kolekce.Count; i++)
            {
                if (volbaPoradi == 1)
                    pole.Add(kolekce[i].Item1.ToString());
                else if (volbaPoradi == 2)
                    pole.Add(kolekce[i].Item2);
                else if (volbaPoradi == 3)
                    pole.Add(kolekce[i].Item3);
            }
            return pole.Max(polozka => polozka.Length);
        }

        private static List<string> ListTymu(List<(string, string)> skupinyTymy)
        {
            List<string> listTymu = new List<string>();
            for (int i = 0; i < skupinyTymy.Count; i++)
            {
                //if (skupinyTymy[i].Item2.Contains(VybranaSkupina))
                //{
                    listTymu.Add(skupinyTymy[i].Item1);
                //}

            }
            return listTymu;
        }

        private static List<(int, string, string)> ListZapasuSkupin(List<(int, string, string)> skupinyZapasy)
        {
            List<(int, string, string)> listZapasuSkupin = new List<(int, string, string)>();

            //zápasy vybrané skupiny
            for (int i = 0; i < skupinyZapasy.Count; i++)
            {
                if (skupinyZapasy[i].Item3.Contains(VybranaSkupina))
                {
                    listZapasuSkupin.Add((i + 1, skupinyZapasy[i].Item2, skupinyZapasy[i].Item3));
                }

            }

            return listZapasuSkupin;
        }
    }
}
