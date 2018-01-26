using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
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
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();

            //create a new PDF string format
            PdfStringFormat drawFormat = new PdfStringFormat();
            drawFormat.WordWrap = PdfWordWrapType.Word;
            drawFormat.Alignment = PdfTextAlignment.Justify;
            drawFormat.LineAlignment = PdfVerticalAlignment.Top;

            //Set the font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 40f);

            //Create a brush.
            PdfBrush brush = PdfBrushes.Red;

            //bounds
            RectangleF bounds = new RectangleF(new PointF(10, 10),
                new SizeF(page.Graphics.ClientSize.Width - 30,
                page.Graphics.ClientSize.Height - 20));

            //Create a new text elememt
            PdfTextElement element = new PdfTextElement(a.Name, font, brush);

            //Set the string format
            element.StringFormat = drawFormat;

            //Draw the text element
            PdfLayoutResult result = element.Draw(page, bounds);

            FileStream s = new FileStream(filename, FileMode.OpenOrCreate);
            doc.Save(s);
            s.Flush();
            s.Close();
            s.Dispose();

            return File.ReadAllBytes(filename);
        }
    }
}