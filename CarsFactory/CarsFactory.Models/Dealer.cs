using System.Collections.Generic;

using CarsFactory.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace CarsFactory.Models
{
    public class Dealer : IDealer
    {
        private ICollection<ICar> cars;

        public Dealer()
        {
            this.cars = new HashSet<ICar>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Town { get; set; }

        public virtual ICollection<ICar> Cars
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