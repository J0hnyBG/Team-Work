using System.ComponentModel.DataAnnotations;

namespace Cars.Models.Contracts
{
    public interface IPlatform
    {
        int Id { get; }

        [Required]
        [MaxLength(50)]
        string Name { get; }
    }
}
