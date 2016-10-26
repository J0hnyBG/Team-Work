using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsFactory.Models
{
    public class Car
    {
        private decimal price;

        public int Id { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        public DateTime Year { get; set; }

        public Nullable<int> OrderId { get; set; }

        public Order Order { get; set; }

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
