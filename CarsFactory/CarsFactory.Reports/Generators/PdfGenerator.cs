namespace CarsFactory.Reports.Generators
{
    using System.Collections.Generic;
    using System.IO;

    using Abstract;

    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.draw;

    public class PdfGenerator : AbstractGenerator
    {
        public override void GenerateReport()
        {
            var fs = new FileStream("..\\..\\..\\sales-reports.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var doc = new Document();
            var writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.AddTitle("Reports");
            doc.AddSubject("A sales report for {date}");
            doc.AddKeywords("Report, Sales");
            doc.AddCreator("CarsFactory");
            doc.AddAuthor("CarsFactory");
            doc.AddHeader("Nothing", "No Header");
            doc.Add(new Paragraph("Hello World"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new LineSeparator());
            doc.Add(new Paragraph("Hello World"));
            var tb = new PdfPTable(3);
            tb.AddCell("asd");
            tb.AddCell("asd");
            tb.AddCell("asd");
            tb.AddCell("asd");
            doc.Add(tb);

            doc.Close();
        }
    }
}
