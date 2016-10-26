using Cars.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models.Contracts
{
    public interface IPlatform
    {
        int Id { get; }

        [Required]
        PlatformType PlatformType{ get; }

        int NumberOfDoors { get; }
    }
}
