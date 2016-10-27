using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CarsFactory.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CarsFactory.MongoDb.Data
{
    public class MongoDbRepository
    {
        private const string ConnectionString = "mongodb://pesho:gosho@ds033297.mlab.com:33297/factory";
        private static readonly MongoClient Client = new MongoClient(ConnectionString);
        private static readonly IMongoDatabase Database = Client.GetDatabase("factory");

        private static readonly IMongoCollection<BsonDocument> CarsCollection = MbDatabase.GetCollection<BsonDocument>("Cars");

        public static IMongoDatabase MbDatabase
        {
            get
            {
                return Database;
            }
        }

        public async Task<IList<Car>> GetCarsData()
        {
            var cars = (await CarsCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Car>(bs)).ToList();

            return cars;
        }

    }
}
