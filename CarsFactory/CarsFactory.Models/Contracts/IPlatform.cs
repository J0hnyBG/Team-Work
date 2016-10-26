using CarsFactory.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarsFactory.Models.Contracts
{
    public interface IPlatform
    {
        int Id { get; }

        [Required]
        PlatformType PlatformType{ get; }

        int NumberOfDoors { get; }
    }
}
