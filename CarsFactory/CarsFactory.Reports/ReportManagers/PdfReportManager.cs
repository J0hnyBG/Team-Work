namespace CarsFactory.Reports.ReportManagers
{
    using Abstract;

    using Documents;
    using Documents.Contracts;

    public class PdfReportManager : ReportManager
    {
        protected override IDocumentAdapter CreateDocument(string fileLocation)
        {
            return new PdfDocumentAdapter(fileLocation);
        }
    }
}
