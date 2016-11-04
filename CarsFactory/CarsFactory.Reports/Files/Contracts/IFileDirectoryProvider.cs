using System.IO;

namespace CarsFactory.Reports.Files.Contracts
{
    public interface IFileDirectoryProvider
    {
        bool DirectoryExists(string path);

        void CreateDirectory(string path);

        Stream CreateFileStream(string filePath);
    }
}
