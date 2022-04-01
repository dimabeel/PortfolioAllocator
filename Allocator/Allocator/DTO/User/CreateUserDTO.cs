using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace Allocator.API.DTO.User;

// ReSharper disable once InconsistentNaming
public class CreateUserDTO
{
    [Required]
    [MaxLength(50)]
    [MinLength(2)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string Surname { get; set; }
}
