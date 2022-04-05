using System.ComponentModel.DataAnnotations;
using Allocator.API.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace Allocator.API.DTO.StockHistoryRow;

// ReSharper disable once InconsistentNaming
public class CreateStockHistoryRowDTO : IMapWith<Models.StockHistoryRow>
{
    [Required]
    public int StockId { get; set; }

    [Required]
    [Precision(2)]
    public double Input { get; set; }

    public DateTime Date { get; set; }

    [Required]
    [Precision(2)]
    public double Profit { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateStockHistoryRowDTO, Models.StockHistoryRow>();
    }
}
