using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Allocator.API.DTO.Stock;

// ReSharper disable once InconsistentNaming
public class CreateStockDTO
{
    [Required]
    public int AccountId { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Company { get; set; }
}
