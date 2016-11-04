using CarsFactory.Data.Contracts;
using CarsFactory.Reports.Documents.Contracts;

namespace CarsFactory.Reports.Reports.Contracts
{
    public interface IReport
    {
        void Generate(IDocumentAdapter document, ICarsFactoryDbContext dbContext);
    }
}
