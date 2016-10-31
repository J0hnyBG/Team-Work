using CarsFactory.Reports.Documents;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.ReportManagers.Abstract;

namespace CarsFactory.Reports.ReportManagers
{
    public class PdfReportManager : ReportManager
    {
        protected override IDocumentAdapter CreateDocument(string fileLocation)
        {
            return new PdfDocumentAdapter(fileLocation);
        }
    }
}
