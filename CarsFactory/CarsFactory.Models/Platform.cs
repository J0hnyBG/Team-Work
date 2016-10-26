using Cars.Models.Contracts;
using Cars.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    public class Platform : IPlatform
    {
        public int Id { get; set; }

        [Required]
        public PlatformType PlatformType { get; set; }

        public int NumberOfDoors { get; set; }
    }
}