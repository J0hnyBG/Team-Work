namespace CarsFactory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        private ICollection<Car> cars;

        public Order()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
