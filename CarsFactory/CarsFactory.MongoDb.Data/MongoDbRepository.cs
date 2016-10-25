using Cars.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsFactory.MongoDb.Data
{
    public class MongoDbRepository
    {
        private const string ConnectionString = " mongodb://rank1:rank1234@ds033607.mlab.com:33607/carsfactory";
        private static readonly MongoClient Client = new MongoClient(ConnectionString);
        private static readonly IMongoDatabase Database = Client.GetDatabase("carsfactory");

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
            var teams = (await CarsCollection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<Car>(bs)).ToList();

            return teams;
        }

    }
}
