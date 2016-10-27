namespace CarsFactory.Models
{
    using System.Collections.Generic;

    public class Town
    {
        private ICollection<Dealer> dealers;

        public Town()
        {
            this.dealers = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealers
        {
            get { return this.dealers; }
            set { this.dealers = value; }
        }
    }
}
