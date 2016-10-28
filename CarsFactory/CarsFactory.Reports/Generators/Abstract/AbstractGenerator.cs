namespace CarsFactory.Reports.Generators.Abstract
{
    using Documents.Contracts;

    public abstract class AbstractGenerator
    {
        protected AbstractGenerator()
        {
        }

        public abstract void GenerateReports(string directoryLocation);

        protected abstract IDocument GetDocument(string fileLocation);
    }
}
