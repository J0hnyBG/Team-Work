using CarsFactory.Data.Contracts;

namespace CarsFactory.Reports
{
    public interface IReportService
    {
        void SaveAllReports(string directoryPath, ICarsFactoryDbContext dbContext);
    }
}
