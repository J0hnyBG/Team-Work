using CarsFactory.Data.Contracts;

namespace CarsFactory.Reports.Contracts
{
    public interface IGenerateDataFromZipFiles
    {
        void SaveAllDataFromZip(IMSSqlRepository repo, ICarsFactoryDbContext ctx, string filePath);
    }
}
