namespace CarsFactory.Reports.Generators.Documents
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Abstract;

    using Contracts;

    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.draw;

    public class PdfDocument : AbstractDocument
    {
        private readonly Document document;

        public PdfDocument(string fileLocation)
            : base(fileLocation)
        {
            var fs = new FileStream(fileLocation, FileMode.Create, FileAccess.Write, FileShare.None);
            this.document = new Document();

            var wr = PdfWriter.GetInstance(this.document, fs);
        }

        public override void Save()
        {
            this.document.Close();
        }

        public override IDocument AddRow(string text)
        {
            this.document.Add(new Paragraph(text));
            this.document.Add(Chunk.NEWLINE);
            this.document.Add(new LineSeparator());
            this.document.Add(Chunk.NEWLINE);

            return this;
        }

        public override IDocument AddTabularData<TModel>(ICollection<TModel> tableData)
        {
            var modelProperties = typeof(TModel).GetProperties();
            var table = new PdfPTable(modelProperties.Length);

            foreach (var property in modelProperties)
            {
                var propertyName = property.Name;
                var cell = new PdfPCell(new Phrase(propertyName))
                {
                    Colspan = 1,
                    HorizontalAlignment = 1, //0=Left, 1=Centre, 2=Right
                    GrayFill = 0.9f
                };
                table.AddCell(cell);
            }

            foreach (var data in tableData)
            {
                foreach (var property in modelProperties)
                {
                    var value = property.GetValue(data);
                    var cellValue = (value ?? "N/A").ToString();
                    table.AddCell(cellValue);
                }
            }
           
            this.document.Add(table);

            return this;
        }

        public override IDocument NewPage()
        {
            this.document.NewPage();
            return this;
        }

        public override IDocument AddMetadata()
        {
            this.document.AddTitle("Reports");
            this.document.AddSubject($"A sales report for {DateTime.Now}");
            this.document.AddKeywords("Report, Sales");
            this.document.AddCreator(AppDomain.CurrentDomain.FriendlyName);
            this.document.AddAuthor(AppDomain.CurrentDomain.FriendlyName);
            this.document.Open();
            return this;
        }
    }
}
