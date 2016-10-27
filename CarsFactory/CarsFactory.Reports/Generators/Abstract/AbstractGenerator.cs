namespace CarsFactory.Reports.Generators.Abstract
{
    using Documents.Contracts;

    public abstract class AbstractGenerator
    {
        public abstract void GenerateReports(string fileLocation);

        protected abstract IDocument GetDocument(string fileLocation);
    }
}
