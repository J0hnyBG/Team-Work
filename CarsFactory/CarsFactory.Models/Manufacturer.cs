using Cars.Models.Contracts;
using System.Collections.Generic;

namespace Cars.Models
{
    public class Manufacturer : IManufacturer
    {
        private ICollection<ICar> cars;

        public Manufacturer()
        {
            this.cars = new HashSet<ICar>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

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