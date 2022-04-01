using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Allocator.API.DTO.Stock;

// ReSharper disable once InconsistentNaming
public class GetStockDTO
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public int StockId { get; set; }
}