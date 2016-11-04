using System.Collections.Generic;

using CarsFactory.Data.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports.ReportManagers.Contracts
{
    public interface IReportManager
    {
        void GenerateReports(string directoryLocation, ICarsFactoryDbContext dbContext);

        void Add(IReport report);

        void Add(IEnumerable<IReport> reports);
    }
}
