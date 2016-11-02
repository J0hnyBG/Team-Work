using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using CarsFactory.Reports.Documents.Abstract;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Utilities.Extensions;

namespace CarsFactory.Reports.Documents
{
    public class PdfDocumentAdapter : AbstractDocumentAdapter
    {
        private const float DefaultCellPadding = 10f;
        private const float DefaultGrayFill= 0.9f;
        private const int DefaultColspan = 1;
        private const int CentralAlignment = 1;

        private readonly Document document;

        public PdfDocumentAdapter(string fileLocation)
            : base(fileLocation)
        {
            //TODO: Abstract dependencies
            var fileStream = new FileStream(fileLocation + ".pdf", FileMode.Create, FileAccess.Write, FileShare.Read);
            this.document = new Document();

            PdfWriter.GetInstance(this.document, fileStream);
        }

        public override void Save()
        {
            this.document.Close();
        }

        public override IDocumentAdapter AddRow(string text)
        {
            this.document.Add(new Paragraph(text));
            this.document.Add(Chunk.NEWLINE);
            this.document.Add(new LineSeparator());
            this.document.Add(Chunk.NEWLINE);

            return this;
        }

        public override IDocumentAdapter AddTabularData<TModel>(ICollection<TModel> tableData)
        {
            if (tableData == null)
            {
                throw new ArgumentNullException(nameof(tableData));
            }

            var modelProperties = typeof(TModel).GetProperties();
            var table = new PdfPTable(modelProperties.Length);

            foreach (var property in modelProperties)
            {
                var propertyName = property.Name.DivideWordsByCapitalLetters();
                var cell = new PdfPCell(new Phrase(propertyName))
                {
                    Colspan = DefaultColspan,
                    HorizontalAlignment = CentralAlignment,
                    GrayFill = DefaultGrayFill
                };
                table.AddCell(cell);
            }

            foreach (var data in tableData)
            {
                foreach (var property in modelProperties)
                {
                    var value = property.GetValue(data);
                    var cellValue = (value ?? "N/A").ToString();

                    var cell = new PdfPCell(new Phrase(cellValue))
                               {
                                   Padding = DefaultCellPadding,
                                   HorizontalAlignment = CentralAlignment
                               };
                    table.AddCell(cell);
                }
            }
           
            this.document.Add(table);

            return this;
        }

        public override IDocumentAdapter NewPage()
        {
            this.document.NewPage();
            return this;
        }

        public override IDocumentAdapter AddMetadata()
        {
            this.document.AddTitle("Reports");
            this.document.AddSubject($"Report for {DateTime.Now}");
            this.document.AddKeywords("Report, Sales");
            this.document.AddCreator(AppDomain.CurrentDomain.FriendlyName);
            this.document.AddAuthor(AppDomain.CurrentDomain.FriendlyName);
            this.document.Open();
            return this;
        }
    }
}
