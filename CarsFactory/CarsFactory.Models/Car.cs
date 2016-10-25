using System.ComponentModel.DataAnnotations;

using Cars.Models.Enums;
using Cars.Models.Contracts;

namespace Cars.Models
{
    public class Car : ICar
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public ushort Year { get; set; }

        public FuelType Fuel { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int DealerId { get; set; }

        public virtual IDealer Dealer { get; set; }

        public int ManufacturerId { get; set; }

        public virtual IManufacturer Manufacturer { get; set; }

        public virtual IPlatform CarPlatform { get; set; }
    }
}
