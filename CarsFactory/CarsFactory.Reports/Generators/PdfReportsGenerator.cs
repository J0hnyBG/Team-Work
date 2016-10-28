namespace CarsFactory.Reports.Generators
{
    using System;
    using System.Linq;

    using Abstract;

    using Data;

    using Documents;
    using Documents.Contracts;

    using Models;
    using Models.Enums;

    public class PdfReportsGenerator : AbstractGenerator
    {
        public PdfReportsGenerator()
            :base()
        {
        }

        public override void GenerateReports(string directoryLocation)
        {
            this.GenerateTotalRevenuesByDealerReport(directoryLocation);
        }

        protected override IDocument GetDocument(string fileLocation)
        {
            return new PdfDocument(fileLocation);
        }

        private void GenerateTotalRevenuesByDealerReport(string directoryLocation)
        {
            var dbContext = new CarsFactoryDbContext();

            using (dbContext)
            {
                dbContext.Database.Log = Console.WriteLine;

                var totalRevenueByDealers = (from dealer in dbContext.Dealers
                                             let totalRevenue = dealer.Cars.Sum(x => x.Price)
                                             let town = dealer.Town.Name
                                             let orderCount = dealer.Cars.Count(car => car.OrderId != null)
                                             select new TotalRevenueByDealer
                                                    {
                                                        Dealer = dealer.Name,
                                                        TotalRevenue = totalRevenue,
                                                        Town = town,
                                                        TotalOrders = orderCount
                                                    })
                    .Take(10)
                    .OrderByDescending(x => x.TotalRevenue)
                    .ToList();

                var currentYear = DateTime.Now.Year;

                var totalRevenueForThePastMonth = (from dealer in dbContext.Dealers
                                                   let totalRevenue =
                                                       //FIXME:
                                                       dealer.Cars.Where(car => car.Order.Date.Year > currentYear && car.Order.OrderStatus == OrderStatus.Closed)
                                                             .Sum(c => c.Price)
                                                   let town = dealer.Town.Name
                                                   //FIXME:
                                                   let orderCount = dealer.Cars.Where(car => car.Order != null && car.Order.Date.Year > currentYear && car.Order.OrderStatus == OrderStatus.Closed)
                                                                          .Count(car => car.OrderId != null)
                                                   select new TotalRevenueByDealer
                                                          {
                                                              Dealer = dealer.Name,
                                                              TotalRevenue = totalRevenue,
                                                              Town = town,
                                                              TotalOrders = orderCount
                                                          })
                    .OrderByDescending(x => x.TotalRevenue)
                    .Take(10)
                    .ToList();

                var document = this.GetDocument(directoryLocation + "TotalRevenuesByDealer_" + DateTime.Now.Day + ".pdf");
                document.AddMetadata()
                        .AddRow($"Top 10 total revenue by dealer for all time. Generated on {DateTime.Now}")
                        .AddTabularData(totalRevenueByDealers)
                        .NewPage()
                        .AddRow($"Total revenue by dealer for the last month.")
                        .AddTabularData(totalRevenueForThePastMonth)
                        .Save();
            }
        }
    }
}
