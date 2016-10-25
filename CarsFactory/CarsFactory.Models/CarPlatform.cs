using Cars.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    public class CarPlatform : IPlatform
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}