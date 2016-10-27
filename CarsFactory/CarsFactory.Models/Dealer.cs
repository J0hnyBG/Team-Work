using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace CarsFactory.Models
{
    public class Dealer
    {
        private ICollection<Car> cars;

        public Dealer()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public virtual ICollection<Car> Cars
        {
            get
            {
                return this.cars;
            }

            set
            {
                this.cars = value;
            }
        }
    }
}