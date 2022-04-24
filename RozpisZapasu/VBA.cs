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
                string kodVBA = "Private Sub Workbook_Open()\nMsgBox \"Ahoj\"\nEnd Sub";  //base 64 encoded data from reflection code

                VbaProjectPart vbaPart = doc.WorkbookPart.AddNewPart<VbaProjectPart>("rId1");
                Stream data = GetBinaryDataStream(Base64Encode(kodVBA));
                vbaPart.FeedData(data);
                data.Close();

                WorkbookProperties wbProps = new WorkbookProperties();
                wbProps.CodeName = "ThisWorkbook";
            }
        }

        private static Stream GetBinaryDataStream(string base64String)
        {
            return new MemoryStream(Convert.FromBase64String(base64String));
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
