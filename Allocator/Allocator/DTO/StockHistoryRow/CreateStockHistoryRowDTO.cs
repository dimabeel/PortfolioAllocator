using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace Allocator.API.DTO.StockHistoryRow;

// ReSharper disable once InconsistentNaming
public class CreateStockHistoryRowDTO
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public int StockId { get; set; }

    [Required]
    [Precision(2)]
    public double Input { get; set; }

    public DateTime Date { get; set; }

    [Required]
    [Precision(2)]
    public double Profit { get; set; }
}
