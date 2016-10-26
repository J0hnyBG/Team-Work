using System.ComponentModel.DataAnnotations;

using CarsFactory.Models.Contracts;
using CarsFactory.Models.Enums;

namespace CarsFactory.Models
{
    public class Platform : IPlatform
    {
        public int Id { get; set; }

        [Required]
        public PlatformType PlatformType { get; set; }

        public int NumberOfDoors { get; set; }
    }
}