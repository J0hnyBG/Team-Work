using Cars.Models.Contracts;
using Cars.Models.Enums;

namespace Cars.Models
{
    public class Engine : IEngine
    {
        public int Id { get; set; }

        public FuelType Fuel { get; set; }

        public int HorsePower { get; set; }
    }
}
