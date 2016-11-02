using System;
using System.Collections.Generic;
using System.IO;

using CarsFactory.Reports.Reports.Contracts;
using CarsFactory.Reports.Documents.Contracts;

namespace CarsFactory.Reports.ReportManagers.Abstract
{
    public abstract class ReportManager
    {
        protected ICollection<IReport> Reports { get; private set; }

        public void GenerateReports(string directoryLocation)
        {
            if (this.Reports == null || this.Reports.Count == 0)
            {
                throw new InvalidOperationException("No reports to generate! You must add some reports first.");
            }

            if (!Directory.Exists(directoryLocation))
            {
                Directory.CreateDirectory(directoryLocation);
            }
            
            foreach (IReport report in this.Reports)
            {
                var fileNameAndPath =
                    $"{directoryLocation}{report.GetType().Name}-{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
                var document = this.CreateDocument(fileNameAndPath);

                report.Generate(document);
            }
        }

        public void Add(IReport report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report));
            }

            if (this.Reports == null)
            {
                this.Reports = new List<IReport>();
            }

            this.Reports.Add(report);
        }

        public void Add(ICollection<IReport> reports)
        {
            if (reports == null)
            {
                throw new ArgumentNullException(nameof(reports));
            }

            if (this.Reports == null)
            {
                this.Reports = reports;
            }
            else
            {
                foreach (var report in reports)
                {
                    this.Add(report);
                }
            }
        }

        protected abstract IDocumentAdapter CreateDocument(string fileLocation);
    }
}
