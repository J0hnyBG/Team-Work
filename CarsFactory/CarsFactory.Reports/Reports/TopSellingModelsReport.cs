using System;
using System.Linq;

using CarsFactory.Data;
using CarsFactory.Models.Enums;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports.Reports
{
    public class TopSellingModelsReport : IReport
    {
        public void Generate(IDocumentAdapter document)
        {
            var dbContext = new CarsFactoryDbContext();

            /*
             SELECT man.Name + ', ' + m.Name AS [Model], COUNT(c.OrderId) AS [CarsSold] FROM Cars c
                  INNER JOIN Models m ON c.ModelId = m.Id
                  INNER JOIN Manufacturers man ON m.ManufacturerId = man.Id
                  INNER JOIN Orders o ON c.OrderId = o.Id
                  WHERE o.OrderStatus = 3
                  GROUP BY man.Name, m.Name
                  ORDER BY COUNT(c.OrderId) DESC
              */

            using (dbContext)
            {
                var topModels =
                    (from car in
                        dbContext.Cars.Where(car => car.OrderId != null && car.Order.OrderStatus == OrderStatus.Closed)
                     group car by car.Model.Name + ", " + car.Model.Manufacturer.Name
                     into g
                     orderby g.Count() descending
                     select new
                            {
                                Model = g.Key,
                                OrderCount = g.Count()
                            })
                        .Take(20)
                        .ToList();

                document.AddMetadata()
                        .AddRow($"Top 20 selling models of all time. Generated on {DateTime.Now}")
                        .AddTabularData(topModels)
                        .Save();
            }
        }
    }
}
