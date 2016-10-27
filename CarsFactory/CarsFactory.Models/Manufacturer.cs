using System.Collections.Generic;

namespace CarsFactory.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        private ICollection<Model> models;

        public Manufacturer()
        {
            this.models = new HashSet<Model>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}