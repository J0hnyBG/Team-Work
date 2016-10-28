namespace CarsFactory.Reports.Reports
{
    using System;
    using System.Linq;

    using Contracts;

    using Data;

    using Documents.Contracts;

    using Models;

    public class TotalRevenueByDealerReport : IReport
    {
        public void Generate(IDocumentAdapter document)
        {
            var dbContext = new CarsFactoryDbContext();

            using (dbContext)
            {
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

                document.AddMetadata()
                        .AddRow($"Top 10 total revenue by dealer for all time. Generated on {DateTime.Now}")
                        .AddTabularData(totalRevenueByDealers)
                        .Save();
            }
        }
    }
}


