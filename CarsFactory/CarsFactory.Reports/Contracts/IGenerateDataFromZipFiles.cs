using CarsFactory.Data.Contracts;

namespace CarsFactory.Reports.Contracts
{
    public interface IGenerateDataFromZipFiles
    {
        void GetDataFromZip(IMSSqlRepository repo, ICarsFactoryDbContext ctx);
    }
}
