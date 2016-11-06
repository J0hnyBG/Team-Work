using System.Threading.Tasks;

using CarsFactory.Data.Contracts;
using CarsFactory.MongoDb.Data.Contracts;

namespace CarsFactory.Reports.Contracts
{
    public interface IGenerateDataFromMongoDb
    {
        Task SaveAllMongoData(IMongoDbRepository repo, IMSSqlRepository mssqlRepo, ICarsFactoryDbContext ctx);
    }
}
