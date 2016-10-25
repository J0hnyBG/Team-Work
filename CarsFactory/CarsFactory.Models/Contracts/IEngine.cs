using Cars.Models.Enums;

namespace Cars.Models.Contracts
{
   public interface IEngine
    {
         int Id { get; set; }

         FuelType Fuel { get; set; }

         int HorsePower { get; set; }
    }
}
