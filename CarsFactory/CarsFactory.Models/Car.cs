using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CarsFactory.Models.Contracts;

namespace CarsFactory.Models
{
    public class Car : ICar
    {
        private decimal price;

        public int Id { get; set; }

        public int ModelId { get; set; }

        public virtual IModel Model { get; set; }

        public int DealerId { get; set; }

        public virtual IDealer Dealer { get; set; }

        public int ManufacturerId { get; set; }

        public virtual IManufacturer Manufacturer { get; set; }

        public DateTime Year { get; set; }

        public int EngineId { get; set; }

        public virtual IEngine Engine { get; set; }

        public int PlatformId { get; set; }

        public virtual IPlatform Platform { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }

                this.price = value;
            }
        }
    }
}
