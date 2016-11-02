using System.Collections.Generic;
using CarsFactory.Reports.Documents.Contracts;

namespace CarsFactory.Reports.Documents.Abstract
{
    public abstract class AbstractDocumentAdapter : IDocumentAdapter
    {
        protected AbstractDocumentAdapter(string fileLocation)
        {
            this.FileLocation = fileLocation;
        }

        public string FileLocation { get; private set; }

        public abstract IDocumentAdapter AddRow(string text);

        public abstract IDocumentAdapter AddTabularData<T>(ICollection<T> tableData);

        public abstract IDocumentAdapter NewPage();

        public abstract IDocumentAdapter AddMetadata();

        public abstract void Save();
    }
}
