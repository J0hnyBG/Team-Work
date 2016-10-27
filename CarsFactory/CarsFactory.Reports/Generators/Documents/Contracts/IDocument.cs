namespace CarsFactory.Reports.Generators.Documents.Contracts
{
    using System.Collections.Generic;

    public interface IDocument
    {
        string FileLocation { get; }

        IDocument AddRow(string text);

        IDocument AddTabularData<T>(ICollection<T> tableData)
            where T: new();

        IDocument NewPage();

        IDocument AddMetadata();

        void Save();
    }
}
