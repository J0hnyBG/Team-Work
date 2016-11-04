﻿using System.Collections.Generic;

namespace CarsFactory.Reports.Documents.Contracts
{
    public interface IDocumentAdapter
    {
        string FileLocation { get; }

        IDocumentAdapter AddHeader(string text);

        IDocumentAdapter AddTabularData<T>(ICollection<T> tableData);

        IDocumentAdapter NewPage();

        IDocumentAdapter AddMetadata();

        void Save();
    }
}
