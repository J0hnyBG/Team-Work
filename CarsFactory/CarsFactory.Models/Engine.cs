using CarsFactory.Models.Enums;

namespace CarsFactory.Models
{
    public class Engine
    {
        public int Id { get; set; }

        public FuelType Fuel { get; set; }

        public int HorsePower { get; set; }
    }
}
