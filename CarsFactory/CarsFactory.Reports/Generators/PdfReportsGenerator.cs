namespace CarsFactory.Reports.Generators
{
    using System;
    using System.Linq;

    using Abstract;

    using Data;

    using Documents;
    using Documents.Contracts;

    public class PdfReportsGenerator : AbstractGenerator
    {
        public override void GenerateReports(string fileLocation)
        {
            var dbContext = new CarsFactoryDbContext();

            using (dbContext)
            {
                var document = this.GetDocument(fileLocation);
                var cars = dbContext.Cars.ToList();
                document.AddMetadata()
                        .AddRow($"Report for {DateTime.Now}")
                        .AddTabularData(cars)
                        .Save();
            }
            
        }

        protected override IDocument GetDocument(string fileLocation)
        {
            return new PdfDocument(fileLocation);
        }
    }
}
