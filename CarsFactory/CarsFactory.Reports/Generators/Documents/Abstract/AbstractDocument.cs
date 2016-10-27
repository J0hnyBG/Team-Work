namespace CarsFactory.Reports.Generators.Documents.Abstract
{
    using System.Collections.Generic;

    using Contracts;

    public abstract class AbstractDocument : IDocument
    {
        protected AbstractDocument(string fileLocation)
        {
            this.FileLocation = fileLocation;
        }

        public string FileLocation { get; private set; }

        public abstract IDocument AddRow(string text);

        public abstract IDocument AddTabularData<T>(ICollection<T> tableData)
            where T: new();

        public abstract IDocument NewPage();

        public abstract IDocument AddMetadata();

        public abstract void Save();
    }
}
