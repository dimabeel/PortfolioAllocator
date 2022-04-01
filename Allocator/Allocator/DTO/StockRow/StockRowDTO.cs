using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace Allocator.API.DTO.StockRow;

// ReSharper disable once InconsistentNaming
public class StockRowDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [Precision(2)]
    public double Input { get; set; }

    public DateTime Date { get; set; }

    [Required]
    [Precision(2)]
    public double Profit { get; set; }

    [Required]
    [Precision(2)]
    public double Output { get; set; }
}
