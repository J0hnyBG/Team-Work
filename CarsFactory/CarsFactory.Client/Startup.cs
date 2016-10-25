using Cars.Models;
using Cars.Models.Contracts;
using Dealership.Data;

namespace Cars.Client
{
    public class Startup
    {
        public static void Main()
        {
            var dbContext = new CarsFactoryDbContext();
            var newCar = new Car
            {
                Model = "I"
            };

            dbContext.Cars.Add(newCar);
        }
    }
}
