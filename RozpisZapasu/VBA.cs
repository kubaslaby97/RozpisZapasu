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
            /*using (SpreadsheetDocument doc = SpreadsheetDocument.Open(soubor, true))
            {
                //kód VBA
                string kodVBA = "Private Sub Workbook_Open()\nMsgBox \"Ahoj\"\nEnd Sub";

                //vytvoření části VBA v souboru XLSM
                VbaProjectPart vbaPart = doc.WorkbookPart.AddNewPart<VbaProjectPart>("rId1");

                //naplnění daty
                Stream data = GetBinaryDataStream(Base64Encode(kodVBA));
                vbaPart.FeedData(data);
                data.Close();
            }*/
            using (SpreadsheetDocument ssDoc = SpreadsheetDocument.Open("makra.xlsm", false))
            {
                WorkbookPart wbPart = ssDoc.WorkbookPart;
                MemoryStream ms = new MemoryStream();
                CopyStream(ssDoc.WorkbookPart.VbaProjectPart.GetStream(), ms);

                using (SpreadsheetDocument ssDoc2 = SpreadsheetDocument.Open(soubor, true))
                {
                    VbaProjectPart vbaPart = ssDoc2.WorkbookPart.AddNewPart<VbaProjectPart>("rId1");
                    Stream stream = vbaPart.GetStream();
                    ms.WriteTo(stream);
                }
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[short.MaxValue + 1];
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    return;
                output.Write(buffer, 0, read);
            }
        }

        /*private static Stream GetBinaryDataStream(string base64String)
        {
            return new MemoryStream(Convert.FromBase64String(base64String));
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }*/
    }
}
