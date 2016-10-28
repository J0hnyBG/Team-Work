namespace CarsFactory.Reports.Reports.Contracts
{
    using Documents.Contracts;

    public interface IReport
    {
        void Generate(IDocumentAdapter document);
    }
}
