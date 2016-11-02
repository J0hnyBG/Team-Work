using System;
using System.Linq;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Reports.Contracts;
using CarsFactory.Data;
using CarsFactory.Models.Enums;
using CarsFactory.Models;

namespace CarsFactory.Reports.Reports
{
    public class TotalRevenueInLastYearByDealerReport : IReport
    {
        public void Generate(IDocumentAdapter document)
        {
            var dbContext = new CarsFactoryDbContext();

            using (dbContext)
            {
                var lastYear = DateTime.Now.Year - 1;

                var totalRevenueForThePastMonth = (from dealer in dbContext.Dealers
                                                   let totalRevenue =
                                                       //FIXME:
                                                       dealer.Cars.Where(
                                                                         car =>
                                                                             car.Order != null &&
                                                                             car.Order.Date.Year > lastYear &&
                                                                             car.Order.OrderStatus == OrderStatus.Closed)
                                                             .Sum(c => c.Price)
                                                   let town = dealer.Town.Name
                                                   //FIXME:
                                                   let orderCount =
                                                       dealer.Cars.Where(
                                                                         car =>
                                                                             car.Order != null &&
                                                                             car.Order.Date.Year > lastYear &&
                                                                             car.Order.OrderStatus == OrderStatus.Closed)
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

                document.AddMetadata()
                        .AddRow($"Total revenue by dealer for the last year.")
                        .AddTabularData(totalRevenueForThePastMonth)
                        .Save();
            }
        }
    }
}
