﻿using System;
using System.Linq;

using CarsFactory.Data;
using CarsFactory.Models.Enums;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Reports.Reports.Contracts;

namespace CarsFactory.Reports.Reports
{
    public class TopSellingModelsReport : IReport
    {
        public void Generate(IDocumentAdapter document, CarsFactoryDbContext dbContext)
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