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

            GetDataFromZip();
            Task.Run(async () =>
            {
                await GetMongoData();
            }).Wait();

            // Task 3         
            GenerateXmlReport.CreateReport();
        }

        // TODO: Refactor method
        private static async Task GetMongoData()
        {
            var repo = new MongoDbRepository();

            var towns = (await repo.GetTownsData()).ToList();
            var platforms = (await repo.GetPlatformsData()).ToList();
            //var orders = (await repo.GetOrdersData()).ToList();
            //var models = (await repo.GetModelsData()).ToList();
            //var manufacturers = (await repo.GetManufacturersData()).ToList();
            var engines = (await repo.GetEnginesData()).ToList();
            //var dealers = (await repo.GetDealersData()).ToList();
            //var cars = (await repo.GetCarsData()).ToList();

            var ctx = new CarsFactoryDbContext();


            //Console.WriteLine(cars.Count);
            //Console.WriteLine(models.Count);
            //Console.WriteLine(manufacturers.Count);
            //Console.WriteLine(orders.Count);
            //Console.WriteLine(platforms.Count);
            //Console.WriteLine(engines.Count);
            //Console.WriteLine(dealers.Count);
            Console.WriteLine(towns.Count);

            using (ctx)
            {
                foreach (var town in towns)
                {
                    if (!ctx.Towns.Any(c => c.Id == town.Id))
                    {
                        ctx.Towns.Add(town);
                    }
                }

                foreach (var platform in platforms)
                {
                    if (!ctx.Platforms.Any(c => c.Id == platform.Id))
                    {
                        ctx.Platforms.Add(platform);
                    }
                }

                //foreach (var order in orders)
                //{
                //    if (!ctx.Orders.Any(c => c.Id == order.Id))
                //    {
                //        ctx.Orders.Add(order);
                //    }
                //}

                //foreach (var manufacturer in manufacturers)
                //{
                //    if (!ctx.Manufacturers.Any(c => c.Id == manufacturer.Id))
                //    {
                //        ctx.Manufacturers.Add(manufacturer);
                //    }
                //}

                foreach (var engine in engines)
                {
                    if (!ctx.Engines.Any(c => c.Id == engine.Id))
                    {
                        ctx.Engines.Add(engine);
                    }
                }

                //foreach (var model in models)
                //{
                //    if (!ctx.Models.Any(c => c.Id == model.Id))
                //    {
                //        ctx.Models.Add(model);
                //    }
                //}

                //foreach (var dealer in dealers)
                //{
                //    if (!ctx.Dealers.Any(d => d.Id == dealer.Id))
                //    {
                //        ctx.Dealers.Add(dealer);
                //    }
                //}

                //foreach (var car in cars)
                //{
                //    if (!ctx.Cars.Any(c => c.Id == car.Id))
                //    {
                //        ctx.Cars.Add(car);
                //    }
                //}

                ctx.SaveChanges();
            }
        }

        private static void GetDataFromZip()
        {
            var repo = new MSSqlRepository();
            var filePath = @"..\..\..\..\SampleData.zip";
            var zip = ZipFile.Open(filePath, ZipArchiveMode.Read);
            using (zip)
            {
                var entries = ExcelFromZip.GetFileEntries(zip);
                var currentTownEntries = ExcelFromZip.GetCurrentEntries(entries, "Towns.xls");
                var currentPlatformEntries = ExcelFromZip.GetCurrentEntries(entries, "Platforms.xls");
                var currentEngineEntries = ExcelFromZip.GetCurrentEntries(entries, "Engines.xls");
                var towns = ExcelFromZip.GetAllTowns(new List<Town>(), currentTownEntries);
                var platforms = ExcelFromZip.GetAllPlatforms(new List<Platform>(), currentPlatformEntries);
                var engines = ExcelFromZip.GetAllEngines(new List<Engine>(), currentEngineEntries);
                repo.ExtractTownsFromZip(towns);
                repo.ExtractPlatformsFromZip(platforms);
                repo.ExtractEnginesFromZip(engines);
            }
        }
    }
}
