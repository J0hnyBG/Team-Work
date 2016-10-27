namespace CarsFactory.Client
{
    using System;
    using System.Data;
    using System.Linq;

    using CarsFactory.Data;
    using CarsFactory.Models;
    using CarsFactory.MongoDb.Data;

    using Reports.Generators;
    using System.Threading.Tasks;
    public class Startup
    {
        public static void Main()
        {
            using (var dbContext = new CarsFactoryDbContext())
            {
                dbContext.Database.CreateIfNotExists();
                //var orders = dbContext.Orders.ToList();
                //foreach (var order in orders)
                //{
                //    Console.WriteLine($"Order Id: {order.Id}");
                //    Console.WriteLine($"{order.Date}, Status: {order.OrderStatus}");
                //    if (order.Cars.Count > 0)
                //    {
                //        var cars = order.Cars.ToList();
                //        var total = order.TotalPrice;
                //        Console.WriteLine("Total sum: " + total.ToString());
                //        foreach (var car in cars)
                //        {
                //            Console.WriteLine(car.Model.Name);
                //        }
                //    }
                //    Console.WriteLine("=======================================");
                //}
                var pdfGenerator = new PdfReportsGenerator();
                pdfGenerator.GenerateReports("..\\..\\..\\sales-reports.pdf");
            }

            Task.Run(async () =>
            {
                await GetMongoData();
            }).Wait();
        }

        private static async Task GetMongoData()
        {
            var repo = new MongoDbRepository();

            var cars = (await repo.GetCarsData()).ToList();

            var ctx = new CarsFactoryDbContext();
            Console.WriteLine(cars.Count);
            using (ctx)
            {
                foreach (Car car in cars)
                {
                    if (!ctx.Cars.Any(c => c.Id == car.Id))
                    {
                        ctx.Cars.Add(car);
                    }
                }

                // TO FIX: Method returns error for foreign key.
                ctx.SaveChanges();
            }
        }
    }
}
