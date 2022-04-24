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
    public static class VBA
    {
        public static void PropisDatTymuSkupiny(string soubor)
        {
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(soubor, true))
            {
                string kodVBA = "...";  //base 64 encoded data from reflection code
                VbaProjectPart vbaPart = doc.WorkbookPart.AddNewPart<VbaProjectPart>("rId1");
                //Stream data = GetBinaryDataStream(kodVBA);
                //vbaPart.FeedData(data);
                //data.Close();
            }
        }
    }
}
