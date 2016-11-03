using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using CarsFactory.Data;
using CarsFactory.Reports.ReportManagers;
using CarsFactory.Reports.ReportManagers.Abstract;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports
{
    public class ReportService
    {
        public void SaveAllReports(string directoryPath, CarsFactoryDbContext dbContext)
        {
            var allReports = this.GetAllReports();
            ReportManager manager = new PdfReportManager();
            manager.Add(allReports);
            manager.GenerateReports(directoryPath, dbContext);
        }

        private IEnumerable<IReport> GetAllReports()
        {
            //TODO: filter different kinds of reports

            var reports = new List<IReport>();
            foreach (var typeInfo in typeInfos)
            {
                var report = Activator.CreateInstance(typeInfo) as IReport;
                reports.Add(report);
            }

            return reports;
        }
    }
}
