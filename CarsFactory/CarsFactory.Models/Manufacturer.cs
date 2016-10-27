using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsFactory.Models
{
    public class Manufacturer
    {
        private ICollection<Model> models;

        public Manufacturer()
        {
            this.models = new HashSet<Model>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}