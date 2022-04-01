using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace Allocator.API.DTO.StockHistoryRow;

// ReSharper disable once InconsistentNaming
public class GetStockHistoryRowDTO
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public  int StockId { get; set; }

    [Required]
    public int StockRowId { get; set; }
}
