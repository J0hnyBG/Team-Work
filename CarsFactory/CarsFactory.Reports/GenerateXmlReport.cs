﻿using System;
using System.Linq;
using System.Xml;

using CarsFactory.Data;

namespace CarsFactory.Reports
{
    public class GenerateXmlReport
    {
        private const string ProcessInformation = "Gathering information...";
        private const string SaveFilePath = @"..\..\..\SampleData\XML\";
        private const string FileName = "CarProducedReport.xml";
        private const string RootName = "manufacturers";

        public void CreateReport()
        {
            Console.WriteLine(ProcessInformation);
            XmlDocument report = new XmlDocument();
            XmlDeclaration xmlDeclaration = report.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = report.CreateElement(RootName);
            report.AppendChild(root);
            report.InsertBefore(xmlDeclaration, root);

            using (var db = new CarsFactoryDbContext())
            {
                var groupedCars = db.Models.GroupBy(s => s.Manufacturer)
                                        .ToList();

                foreach (var eachCar in groupedCars)
                {
                    XmlElement manufacturer = report.CreateElement("manufacturer");
                    manufacturer.SetAttribute("name", eachCar.Key.Name);
                    root.AppendChild(manufacturer);
                    foreach (var single in eachCar)
                    {
                        XmlElement car = report.CreateElement("car");
                        car.SetAttribute("model", single.Name.ToString());
                        car.SetAttribute("created-on", (single.Year.ToString()));
                        manufacturer.AppendChild(car);
                    }
                }
            }

            report.Save(SaveFilePath + FileName);
        }
    }
}
