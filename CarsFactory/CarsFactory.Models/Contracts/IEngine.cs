using CarsFactory.Models.Enums;

namespace CarsFactory.Models.Contracts
{
   public interface IEngine
    {
         int Id { get; set; }

         FuelType Fuel { get; set; }

         int HorsePower { get; set; }
    }
}
