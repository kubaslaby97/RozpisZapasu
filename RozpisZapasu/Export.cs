using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Export dokumentu ve formátu MS Excel
        /// </summary>
        /// <param name="nazev">nazev dokumentu</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        /// <param name="hristeZapasy">zápasy na hřištích</param>
        /// <param name="skupinyZapasy">zápasy ve skupinách</param>
        public static void UlozitExcel(string nazev, List<(string, string)> skupinyTymy, List<(int, string, string)> hristeZapasy, List<(int, string, string)> skupinyZapasy)
        {
            if (VybranyExport == "Křížová tabulka")
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Create(nazev, SpreadsheetDocumentType.Workbook))
                {
                    VytvoritObsahKrizova(doc, skupinyTymy);
                }
            }
            else if (VybranyExport == "Klasická tabulka")
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Create(nazev, SpreadsheetDocumentType.Workbook))
                {
                    VytvoritObsahKlasicka(doc, skupinyTymy);
                }
            }
            else if (VybranyExport == "Skupinový turnaj")
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Create(nazev, SpreadsheetDocumentType.Workbook))
                {
                    VytvoritObsahSkupiny(doc, skupinyTymy, skupinyZapasy);
                }
            }
            else if (VybranyExport == "Každý s každým")
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Create(nazev, SpreadsheetDocumentType.Workbook))
                {
                    VytvoritObsahHriste(doc, hristeZapasy);
                }
            }
        }
        /// <summary>
        /// Tvorba obsahu dokumentu Křížová tabulka
        /// </summary>
        /// <param name="doc">dokument</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        private static void VytvoritObsahKrizova(SpreadsheetDocument doc, List<(string, string)> skupinyTymy)
        {
            //vytvoření listů
            WorkbookPart wbPart = doc.AddWorkbookPart();
            Workbook wb = new Workbook();
            Sheets sheets = new Sheets();

            for (int i = 0; i < Nazvy(2, skupinyTymy).Count; i++)
            {
                Sheet sheet = new Sheet() { Name = "Tabulka skupiny " + Nazvy(2, skupinyTymy)[i], SheetId = (UInt32Value)(Convert.ToUInt32(i) + 1U), Id = "rId1" + i };
                sheets.Append(sheet);
            }

            wb.Append(sheets);
            wbPart.Workbook = wb;

            //obsah listů
            for (int i = 0; i < Nazvy(2, skupinyTymy).Count; i++)
            {
                WorksheetPart wsPart = wbPart.AddNewPart<WorksheetPart>("rId1" + i);
                KrizovaTabulka(wsPart, TymyVeSkupine(Nazvy(2, skupinyTymy)[i], skupinyTymy));
            }

            //Přidání stylu
            WorkbookStylesPart stylePart = wbPart.AddNewPart<WorkbookStylesPart>("rId1");
            stylePart.Stylesheet = GenerateStylesheet();
            stylePart.Stylesheet.Save();
        }
        /// <summary>
        /// Provede zápis do listu Křížová tabulka
        /// </summary>
        /// <param name="wsPart">část list</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        private static void KrizovaTabulka(WorksheetPart wsPart, List<string> tymy)
        {
            string[] hlavicka = new string[] { "Body", "Skóre", "Pořadí" };
            Worksheet ws = new Worksheet();
            Columns cols = new Columns();
            Column col = new Column() { Min = (UInt32Value)1U, Max = (UInt32Value)1U, Width = tymy.Max(tym => tym.Length), CustomWidth = true };
            cols.Append(col);
            ws.Append(cols);

            SheetData sd = new SheetData();

            for (int radek = 0; radek < tymy.Count + 1; radek++)
            {
                Row row = new Row();
                for (int sloupec = 0; sloupec < tymy.Count + hlavicka.Length + 1; sloupec++)
                {
                    //ohraničení tabulky
                    Cell cell = new Cell()
                    {
                        DataType = CellValues.String,
                        StyleIndex = 1,
                    };
                    row.Append(cell);
                    //vybarvení
                    if (radek == sloupec)
                    {
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                    }
                    //vyplnění týmů
                    else if (sloupec < tymy.Count + 1)
                    {
                        //týmy v řádku
                        if (radek == 0 && sloupec > 0)
                        {
                            cell.CellValue = new CellValue(tymy[sloupec - 1]);
                            cell.DataType = CellValues.String;
                            cell.StyleIndex = 4;
                        }
                        //týmy ve sloupci
                        else if (radek > 0 && sloupec == 0)
                        {
                            cell.CellValue = new CellValue(tymy[radek - 1]);
                            cell.DataType = CellValues.String;
                            cell.StyleIndex = 2;
                        }
                    }
                    //vyplnění hlavičky vedle týmů
                    else if (sloupec >= tymy.Count + 1)
                    {
                        if (radek == 0)
                        {
                            cell.CellValue = new CellValue(hlavicka[sloupec - (tymy.Count + 1)]);
                            cell.DataType = CellValues.String;
                            cell.StyleIndex = 5;
                        }
                    }
                }
                sd.Append(row);
            }
            ws.Append(sd);
            wsPart.Worksheet = ws;
        }
        /// <summary>
        /// Tvorba obsahu dokumentu Klasická tabulka
        /// </summary>
        /// <param name="doc">dokument</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        private static void VytvoritObsahKlasicka(SpreadsheetDocument doc, List<(string, string)> skupinyTymy)
        {
            //vytvoření listů
            WorkbookPart wbPart = doc.AddWorkbookPart();
            Workbook wb = new Workbook();
            Sheets sheets = new Sheets();

            for (int i = 0; i < Nazvy(2, skupinyTymy).Count; i++)
            {
                Sheet sheet = new Sheet() { Name = "Tabulka skupiny " + Nazvy(2, skupinyTymy)[i], SheetId = (UInt32Value)(Convert.ToUInt32(i) + 1U), Id = "rId1" + i };
                sheets.Append(sheet);
            }

            wb.Append(sheets);
            wbPart.Workbook = wb;

            //obsah listů
            for (int i = 0; i < Nazvy(2, skupinyTymy).Count; i++)
            {
                WorksheetPart wsPart = wbPart.AddNewPart<WorksheetPart>("rId1" + i);
                KlasickaTabulka(wsPart, TymyVeSkupine(Nazvy(2, skupinyTymy)[i], skupinyTymy));
            }

            //Přidání stylu
            WorkbookStylesPart stylePart = wbPart.AddNewPart<WorkbookStylesPart>("rId1");
            stylePart.Stylesheet = GenerateStylesheet();
            stylePart.Stylesheet.Save();
        }
        /// <summary>
        /// Provede zápis do listu Klasická tabulka
        /// </summary>
        /// <param name="wsPart">část list</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        private static void KlasickaTabulka(WorksheetPart wsPart, List<string> tymy)
        {
            string[] hlavicka = new string[] { "Pořadí", "Tým", "Zápasy", "Výhry", "Remízy", "Prohry", "Skóre", "Body" };
            Worksheet ws = new Worksheet();
            Columns cols = new Columns();
            Column col = new Column() { Min = (UInt32Value)2U, Max = (UInt32Value)2U, Width = tymy.Max(tym => tym.Length), CustomWidth = true };
            cols.Append(col);
            ws.Append(cols);

            SheetData sd = new SheetData();

            for (int radek = 0; radek < tymy.Count + 1; radek++)
            {
                Row row = new Row();
                for (int sloupec = 0; sloupec < hlavicka.Length; sloupec++)
                {
                    //ohraničení
                    Cell cell = new Cell()
                    {
                        DataType = CellValues.String,
                        StyleIndex = 1,
                    };
                    row.Append(cell);
                    //vyplnění hlavičky
                    if (radek == 0)
                    {
                        cell.CellValue = new CellValue(hlavicka[sloupec]);
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                    }

                    else if (radek > 0)
                    {
                        //vyplnění pořadí
                        if (sloupec == 0)
                        {
                            cell.CellValue = new CellValue(radek);
                            cell.DataType = CellValues.Number;
                        }
                        //vyplnění týmů
                        else if (sloupec == 1)
                        {
                            cell.CellValue = new CellValue(tymy[radek - 1]);
                            cell.DataType = CellValues.String;
                        }
                    }

                }
                sd.Append(row);
            }
            ws.Append(sd);
            wsPart.Worksheet = ws;
        }
        /// <summary>
        /// Tvorba obsahu dokumentu Skupinový turnaj
        /// </summary>
        /// <param name="doc">dokument</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        /// <param name="skupinyZapasy">zápasy ve skupinách</param>
        private static void VytvoritObsahSkupiny(SpreadsheetDocument doc, List<(string, string)> skupinyTymy, List<(int, string, string)> skupinyZapasy)
        {
            //vytvoření listů
            WorkbookPart wbPart = doc.AddWorkbookPart();
            Workbook wb = new Workbook();
            Sheets sheets = new Sheets();

            for (int i = 0; i < Nazvy(2, skupinyTymy).Count; i++)
            {
                Sheet sheet = new Sheet() { Name = "Turnaj " + Nazvy(2, skupinyTymy)[i], SheetId = (UInt32Value)(Convert.ToUInt32(i) + 1U), Id = "rId1" + i };
                sheets.Append(sheet);
            }

            wb.Append(sheets);
            wbPart.Workbook = wb;

            //obsah listů
            for (int i = 0; i < Nazvy(2, skupinyTymy).Count; i++)
            {
                WorksheetPart wsPart = wbPart.AddNewPart<WorksheetPart>("rId1" + i);
                ZapasySkupina(wsPart, ZapasyVeSkupine(Nazvy(2, skupinyTymy)[i], skupinyZapasy));
            }

            //Přidání stylu
            WorkbookStylesPart stylePart = wbPart.AddNewPart<WorkbookStylesPart>("rId1");
            stylePart.Stylesheet = GenerateStylesheet();
            stylePart.Stylesheet.Save();
        }
        /// <summary>
        /// Provede zápis do listu Skupinový turnaj
        /// </summary>
        /// <param name="wsPart">část list</param>
        /// <param name="skupinyZapasy">zápasy ve skupinách</param>
        private static void ZapasySkupina(WorksheetPart wsPart, List<(int, string, string)> skupinyZapasy)
        {
            string[] hlavicka = new string[] { "Kolo", "Zápas", "Skupina", "Skóre" };
            Worksheet ws = new Worksheet();

            if (skupinyZapasy != null)
            {
                Columns cols = new Columns();
                Column col = new Column() { Min = (UInt32Value)2U, Max = (UInt32Value)2U, Width = NejdelsiRetezec(skupinyZapasy, 2), CustomWidth = true };
                Column col1 = new Column() { Min = (UInt32Value)3U, Max = (UInt32Value)3U, Width = NejdelsiRetezec(skupinyZapasy, 3), CustomWidth = true };
                cols.Append(col);
                cols.Append(col1);
                ws.Append(cols);
            }

            SheetData sd = new SheetData();
            MergeCells mergeCells = new MergeCells();
            MergeCell mergeCell = new MergeCell();

            for (int radek = 0; radek < skupinyZapasy.Count + 2; radek++)
            {
                Row row = new Row();
                for (int sloupec = 0; sloupec < hlavicka.Length; sloupec++)
                {
                    //ohraničení tabulky
                    Cell cell = new Cell()
                    {
                        DataType = CellValues.String,
                        StyleIndex = 1,
                    };
                    row.Append(cell);
                    //perioda
                    if (radek == 0 && sloupec == 0)
                    {
                        cell.CellValue = new CellValue("1.perioda");
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                        //sloučení buňek
                        mergeCell.Reference = new StringValue(SloupecNaZnak(1) + (radek + 1) + ":" + SloupecNaZnak(hlavicka.Length) + (radek + 1));
                    }
                    //vyplnění hlavičky
                    else if (radek == 1)
                    {
                        cell.CellValue = new CellValue(hlavicka[sloupec]);
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                    }
                    //vyplnění zbytku
                    else if (radek > 1)
                    {
                        if (sloupec == 0)
                        {
                            cell.CellValue = new CellValue(skupinyZapasy[radek - 2].Item1);
                            cell.DataType = CellValues.Number;
                        }
                        else if (sloupec == 1)
                        {
                            cell.CellValue = new CellValue(skupinyZapasy[radek - 2].Item2);
                            cell.DataType = CellValues.String;
                        }
                        else if (sloupec == 2)
                        {
                            cell.CellValue = new CellValue(skupinyZapasy[radek - 2].Item3);
                            cell.DataType = CellValues.String;
                        }
                    }
                }
                sd.Append(row);
            }
            ws.Append(sd);
            wsPart.Worksheet = ws;

            ws.InsertAfter(mergeCells, ws.Elements<SheetData>().First());
            mergeCells.Append(mergeCell);
            ws.Save();
        }
        /// <summary>
        /// Tvorba obsahu dokumentu Každý s každým
        /// </summary>
        /// <param name="doc">dokument</param>
        /// <param name="hristeZapasy">zápasy na hřištích</param>
        private static void VytvoritObsahHriste(SpreadsheetDocument doc, List<(int, string, string)> hristeZapasy)
        {
            //vytvoření listu
            WorkbookPart wbPart = doc.AddWorkbookPart();
            Workbook wb = new Workbook();

            Sheets sheets = new Sheets();
            Sheet sheet = new Sheet() { Name = "Turnaje na hřištích", SheetId = (UInt32Value)1U, Id = "rId1" };

            sheets.Append(sheet);

            wb.Append(sheets);
            wbPart.Workbook = wb;

            //obsah listu
            WorksheetPart wsPart = wbPart.AddNewPart<WorksheetPart>("rId1");
            ZapasyHriste(wsPart, hristeZapasy);

            //Přidání stylu
            WorkbookStylesPart stylePart = wbPart.AddNewPart<WorkbookStylesPart>("rId2");
            stylePart.Stylesheet = GenerateStylesheet();
            stylePart.Stylesheet.Save();
        }
        /// <summary>
        /// Provede zápis do listu Turnaje na hřištích
        /// </summary>
        /// <param name="wsPart">část list</param>
        /// <param name="hristeZapasy">zápasy na hřištích</param>
        private static void ZapasyHriste(WorksheetPart wsPart, List<(int, string, string)> hristeZapasy)
        {
            string[] hlavicka = new string[] { "Kolo", "Zápas", "Hřiště", "Skóre" };
            Worksheet ws = new Worksheet();
            Columns cols = new Columns();
            Column col = new Column() { Min = (UInt32Value)2U, Max = (UInt32Value)2U, Width = NejdelsiRetezec(hristeZapasy, 2), CustomWidth = true };
            Column col1 = new Column() { Min = (UInt32Value)3U, Max = (UInt32Value)3U, Width = NejdelsiRetezec(hristeZapasy, 3), CustomWidth = true };
            cols.Append(col);
            cols.Append(col1);
            ws.Append(cols);

            SheetData sd = new SheetData();
            MergeCells mergeCells = new MergeCells();
            MergeCell mergeCell = new MergeCell();

            for (int radek = 0; radek < hristeZapasy.Count + 2; radek++)
            {
                Row row = new Row();
                for (int sloupec = 0; sloupec < hlavicka.Length; sloupec++)
                {
                    //ohraničení tabulky
                    Cell cell = new Cell()
                    {
                        DataType = CellValues.String,
                        StyleIndex = 1,
                    };
                    row.Append(cell);

                    //perioda
                    if (radek == 0 && sloupec == 0)
                    {
                        cell.CellValue = new CellValue("1.perioda");
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;
                        //sloučení buňek
                        mergeCell.Reference = new StringValue(SloupecNaZnak(1) + (radek + 1) + ":" + SloupecNaZnak(hlavicka.Length) + (radek + 1));
                    }
                    //vyplnění hlavičky
                    else if (radek == 1)
                    {
                        cell.CellValue = new CellValue(hlavicka[sloupec]);
                        cell.DataType = CellValues.String;
                        cell.StyleIndex = 2;

                    }
                    //vyplnění zbytku
                    else if (radek > 1)
                    {
                        if (sloupec == 0)
                        {
                            cell.CellValue = new CellValue(hristeZapasy[radek - 2].Item1);
                            cell.DataType = CellValues.Number;
                        }
                        else if (sloupec == 1)
                        {
                            cell.CellValue = new CellValue(hristeZapasy[radek - 2].Item2);
                            cell.DataType = CellValues.String;
                        }
                        else if (sloupec == 2)
                        {
                            cell.CellValue = new CellValue(hristeZapasy[radek - 2].Item3);
                            cell.DataType = CellValues.String;
                        }
                    }
                }
                sd.Append(row);
            }
            ws.Append(sd);
            wsPart.Worksheet = ws;

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
        /// <returns></returns>
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

        /// <summary>
        /// Vloží názvy do seznamu
        /// </summary>
        /// <param name="volba">možnost volby 1 pro názvy týmů nebo volby 2 pro názvy skupin</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        /// <returns>Vrátí seznam názvů týmů nebo skupin</returns>
        public static List<string> Nazvy(int volba, List<(string, string)> skupinyTymy)
        {
            List<string> list = new List<string>();
            //názvy týmů
            if (volba == 1)
            {
                for (int i = 0; i < skupinyTymy.Count; i++)
                {
                    list.Add(skupinyTymy[i].Item1);
                }
            }
            //názvy skupin
            else if (volba == 2)
            {
                for (int i = 0; i < skupinyTymy.Count; i++)
                {
                    list.Add(skupinyTymy[i].Item2);
                }
                list = list.Distinct().ToList();
            }
            return list;
        }

        /// <summary>
        /// Vloží týmy do seznamu, které jsou v dané skupině
        /// </summary>
        /// <param name="skupina">vstupní skupina</param>
        /// <param name="skupinyTymy">vstupní seznam skupin a týmů v nich obsažených</param>
        /// <returns></returns>
        public static List<string> TymyVeSkupine(string skupina, List<(string,string)> skupinyTymy)
        {
            List<string> list = new List<string>();
            //názvy týmů
            for (int i = 0; i < skupinyTymy.Count; i++)
            {
                if (skupinyTymy[i].Item2.Contains(skupina))
                {
                    list.Add(skupinyTymy[i].Item1);
                }

            }
            return list;
        }

        public static List<(int,string,string)> ZapasyVeSkupine(string skupina, List<(int, string, string)> skupinyZapasy)
        {
            List<(int, string, string)> list = new List<(int, string, string)>();
            //názvy týmů
            for (int i = 0; i < skupinyZapasy.Count; i++)
            {
                if (skupinyZapasy[i].Item3.Contains(skupina))
                {
                    list.Add((i + 1, skupinyZapasy[i].Item2, skupinyZapasy[i].Item3));
                }

            }
            return list;
        }
    }
}
