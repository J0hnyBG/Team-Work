using System.IO;

using CarsFactory.Reports.Documents.Contracts;

namespace CarsFactory.Reports.Documents
{
    public interface IDocumentAdapterFactory
    {
        IDocumentAdapter GetPdfDocumentAdapter(string fileName, Stream stream);
    }
}
