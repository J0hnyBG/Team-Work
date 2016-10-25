using System.ComponentModel.DataAnnotations;

using Cars.Models.Enums;
using Cars.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class Car : ICar
    {
        public int Id { get; set; }

        public DateTime Year { get; set; }

        [Required]
        [Column(TypeName="Money")]
        public decimal Price { get; set; }

        public int DealerId { get; set; }

        public virtual IDealer Dealer { get; set; }

        public int ManufacturerId { get; set; }

        public virtual IManufacturer Manufacturer { get; set; }

        public int ModelId { get; set; }

        public virtual IModel Model { get; set; }

        public int EngineId { get; set; }

        public virtual IEngine Engine { get; set; }

        public int PlatformId { get; set; }

        public virtual IPlatform Platform { get; set; }
    }
}
