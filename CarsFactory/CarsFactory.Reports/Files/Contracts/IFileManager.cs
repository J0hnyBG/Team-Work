namespace CarsFactory.Reports.Files.Contracts
{
    public interface IFileManager
    {
        bool WriteToDisk(string fileName, string fileContents);
    }
}
