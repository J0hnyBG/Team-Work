using System;
using System.Linq;
using CarsFactory.Data;
using CarsFactory.MongoDb.Data;
using System.Threading.Tasks;
using CarsFactory.Reports;
using System.IO.Compression;
using CarsFactory.Utilities;
using System.Collections.Generic;
using CarsFactory.Models;
using CarsFactory.Reports.Reports;

namespace CarsFactory.Client
{
    public class Startup
    {
        public static void Main()
        {
            using (var dbContext = new CarsFactoryDbContext())
            {
                dbContext.Database.CreateIfNotExists();

                var reportService = new ReportService();
                reportService.SaveAllReports(@"..\..\..\Output\");
            }

            //Problem 4 - JSON Reports
            //After db is populated this will create the JSON reports
            //GenerateJSONReport.GenerateJSON();

            //Problem 1 - Write data in SQL Database from Zip files.
            var zipFiles = new GenerateDataFromZipFiles();
            zipFiles.GetDataFromZip();
            // Write data in MSSQL Database from MongoDb
            Task.Run(async () =>
            {
                await GenerateDataFromMongoDb.GetMongoData();
            }).Wait();

            //// Task 3         
            //GenerateXmlReport.CreateReport();
        }
    }
}
