using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Allocator.API.DTO.Stock;

// ReSharper disable once InconsistentNaming
public class StockDTO
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public int StockId { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Company { get; set; }
}