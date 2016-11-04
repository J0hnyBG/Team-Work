using System.IO;

using CarsFactory.Reports.Files.Contracts;

namespace CarsFactory.Reports.Files
{
    public class FileDirectoryProvider : IFileDirectoryProvider
    {
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public Stream CreateFileStream(string filePath)
        {
            return new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        }
    }
}
