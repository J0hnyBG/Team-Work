using System.IO;

using CarsFactory.Reports.Documents;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Files.Contracts;
using CarsFactory.Reports.ReportManagers.Abstract;

namespace CarsFactory.Reports.ReportManagers
{
    public class PdfReportManager : ReportManager
    {
        private const string FileExtension = ".pdf";

        public PdfReportManager(IFileDirectoryProvider fileDirectoryProvider, IDocumentAdapterFactory documentAdapterFactory) 
            : base(fileDirectoryProvider, documentAdapterFactory)
        {
        }

        protected override IDocumentAdapter CreateDocument(string fileName, Stream stream)
        {
            return this.DocumentAdapterAdapterFactory.GetPdfDocumentAdapter(fileName, stream);
        }

        protected override string AppendFileExtension(string fileName)
        {
            if (fileName.EndsWith(FileExtension))
            {
                return fileName;
            }

            return fileName + FileExtension;
        }
    }
}
