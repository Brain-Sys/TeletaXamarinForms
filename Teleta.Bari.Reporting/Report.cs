using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using Teleta.Bari.XF.Repository;

namespace Teleta.Bari.Reporting
{
    public static class Report
    {
        public static string Folder { get; set; }

        public static byte[] Print(Article a, string filename)
        {
            filename = Folder + filename;
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc,
                new FileStream(filename, FileMode.OpenOrCreate));

            doc.Open();
            Paragraph p = new Paragraph(a.Name);
            p.Font.Size = 40;
            p.Font.SetColor(255, 0, 0);
            doc.Add(p);

            doc.Close();
            doc.Dispose();

            return File.ReadAllBytes(filename);
        }
    }
}