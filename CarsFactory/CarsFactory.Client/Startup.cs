using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

using CarsFactory.Data.Contracts;
using CarsFactory.Reports;
using CarsFactory.Reports.ReportManagers.Contracts;

using Ninject;
using CarsFactory.Reports.Reports;

namespace CarsFactory.Client
{
    public class Startup
    {
        public static void Main()
        {
            //var kernel = new StandardKernel();
            //kernel.Load(Assembly.GetExecutingAssembly());

            //var dbContext = kernel.Get<ICarsFactoryDbContext>();
            //// Problem 2
            //var reportService = kernel.Get<IReportService>();
            //reportService.SaveAllReports(@"..\..\..\Output\", dbContext);

            // Problem 4 - JSON Reports
            // After db is populated this will create the JSON reports
            // and save them all to the file system, named as per requirement
            // as well as to a MySQL database as JSON objects
            GenerateJSONReport.GenerateJSON();
            

            // Problem 1 - Write data in SQL Database from Zip files.
            var zipFiles = new GenerateDataFromZipFiles();
            zipFiles.GetDataFromZip();
            //// Write data in MSSQL Database from MongoDb
            //Task.Run(async () =>
            //{
            //    await GenerateDataFromMongoDb.GetMongoData();
            //}).Wait();

            //// Task 3         
            //GenerateXmlReport.CreateReport();
        }
    }
}
