using CarsFactory.Data;
using CarsFactory.Models.Enums;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace CarsFactory.Reports.Reports
{
    /// <summary>
    /// Class to generate JSON reports
    /// </summary>
    public static class GenerateJSONReport
    {
        /// <summary>
        /// Generate a JSON file for each order
        /// Filename is the Id of order
        /// </summary>
        public static void GenerateJSON()
        {
            using (CarsFactoryDbContext ctx = new CarsFactoryDbContext())
            {
                var ordersList = (from order in ctx.Orders

                                  let date =
                                      order.Date

                                  let totalRevenue =
                                       (decimal?)order.Cars.Where(
                                                                   y =>
                                                                       y.OrderId != null &&
                                                                       y.Order.OrderStatus == OrderStatus.Closed)
                                                       .Sum(x => x.Price)
                                  let unitsSold =
                                      order.Cars.Count(
                                                        y =>
                                                            y.OrderId != null &&
                                                            y.Order.OrderStatus == OrderStatus.Closed)
                                  select new
                                  {
                                      OrderId = order.Id,
                                      Date = date,
                                      UnitsSold = unitsSold,
                                      TotalRevenue = totalRevenue,
                                  })
                    .ToList();

                foreach (var order in ordersList)
                {
                    var path = "..\\..\\..\\Output\\Json-Reports";
                    var di = Directory.CreateDirectory(path);
                    using (var writer = new StreamWriter("..\\..\\..\\Output\\Json-Reports\\" + order.OrderId + ".json"))
                    {
                        writer.Write(JsonConvert.SerializeObject(order, Formatting.Indented));
                    }
                }
            }
        }
    }
}
