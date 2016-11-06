using System;
using System.Linq;
using System.Threading.Tasks;

using CarsFactory.Data;
using System.Collections.Generic;
using CarsFactory.Data.Contracts;
using CarsFactory.MongoDb.Data.Contracts;
using CarsFactory.Reports.Contracts;
using CarsFactory.Models;

namespace CarsFactory.Reports
{
    public class GenerateDataFromMongoDb : IGenerateDataFromMongoDb
    {
        public async Task GetMongoData(IMongoDbRepository repo, IMSSqlRepository mssqlRepo, ICarsFactoryDbContext ctx)
        {
            var towns = (await repo.GetTownsData()).ToList();
            var platforms = (await repo.GetPlatformsData()).ToList();
            //var orders = (await repo.GetOrdersData()).ToList();
            var models = (await repo.GetModelsData()).ToList();
            //var manufacturers = (await repo.GetManufacturersData()).ToList();
            var engines = (await repo.GetEnginesData()).ToList();

            
            using (ctx = new CarsFactoryDbContext())
            {
                this.SaveTownsInMSSqlDb(ctx, towns);
                this.SavePlatformsInMSSqlDb(ctx, platforms);
                this.SaveEnginesInMSSqlDb(ctx, engines);
                this.SaveModelsInMSSqlDb(ctx, models);

                await ctx.SaveChangesAsync();
            }

            //var dealers = (await repo.GetDealersData()).ToList();
            //var cars = (await repo.GetCarsData()).ToList();

            //var ctx = new CarsFactoryDbContext();

            //Console.WriteLine(cars.Count);
            Console.WriteLine(models.Count);
            //Console.WriteLine(manufacturers.Count);
            //Console.WriteLine(orders.Count);
            Console.WriteLine(platforms.Count);
            Console.WriteLine(engines.Count);
            //Console.WriteLine(dealers.Count);
            Console.WriteLine(towns.Count);
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
        }

        private void SaveTownsInMSSqlDb(ICarsFactoryDbContext ctx, IList<Town> towns)
        {
            using (ctx = new CarsFactoryDbContext())
            {
                foreach (var town in towns)
                {
                    if (!ctx.Towns.Any(c => c.Id == town.Id))
                    {
                        ctx.Towns.Add(town);
                    }
                }
                ctx.SaveChanges();
            }
        }

        private void SavePlatformsInMSSqlDb(ICarsFactoryDbContext ctx, IList<Platform> platforms)
        {
            using (ctx = new CarsFactoryDbContext())
            {

                foreach (var platform in platforms)
                {
                    if (!ctx.Platforms.Any(c => c.Id == platform.Id))
                    {
                        ctx.Platforms.Add(platform);
                    }
                }
                ctx.SaveChanges();
            }
        }

        private void SaveEnginesInMSSqlDb(ICarsFactoryDbContext ctx, IList<Engine> engines)
        {
            using (ctx = new CarsFactoryDbContext())
            {
                foreach (var engine in engines)
                {
                    if (!ctx.Engines.Any(c => c.Id == engine.Id))
                    {
                        ctx.Engines.Add(engine);
                    }
                }
                ctx.SaveChanges();
                ctx.Dispose();
            }
        }

        private void SaveModelsInMSSqlDb(ICarsFactoryDbContext ctx, IList<Model> models)
        {
            using (ctx = new CarsFactoryDbContext())
            {
                foreach (var model in models)
                {
                    if (!ctx.Models.Any(c => c.Id == model.Id))
                    {
                        ctx.Models.Add(model);
                    }
                }
                ctx.SaveChanges();
            }
        }
    }
}
