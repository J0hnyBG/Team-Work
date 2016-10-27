namespace CarsFactory.Client
{
    using System;
    using System.Data;
    using System.Linq;

    using CarsFactory.Data;
    using CarsFactory.Models;
    using CarsFactory.MongoDb.Data;

    using Reports.Generators;

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
                var pdfGenerator = new PdfGenerator();
                pdfGenerator.GenerateReport();
            }

            //Startup.GetMongoData();
        }

        //Commented so i can start the program.
        private async static void GetMongoData()
        {
            try
            {
                var repo = new MongoDbRepository();

                var cars = (await repo.GetCarsData()).ToList();

                var ctx = new CarsFactoryDbContext();
                using (ctx)
                {
                    foreach (Car car in cars)
                    {
                        if (!ctx.Cars.Any(pl => pl.Id == car.Id))
                        {
                            ctx.Cars.Add(car);
                        }
                    }

                    ctx.SaveChanges();
                }
            }
            catch (DataException)
            {
                throw new ArgumentException("MongoDb is not set up correctly.");
            }
        }
    }
}
