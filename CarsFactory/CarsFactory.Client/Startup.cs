using Dealership.Data;

namespace Cars.Client
{
    public class Startup
    {
        public static void Main()
        {
            using (var dbContext = new CarsFactoryDbContext())
            {
                dbContext.Database.CreateIfNotExists();
            }
        }
    }
}
