using System.ComponentModel.DataAnnotations;
using Allocator.API.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace Allocator.API.DTO.StockHistoryRow;

// ReSharper disable once InconsistentNaming
public class StockHistoryRowDTO : IMapWith<Models.StockHistoryRow>
{
    [Required]
    public int StockId { get; set; }

    [Required]
    public int StockHistoryRowId { get; set; }
    
    [Required]
    public decimal Input { get; set; }

    public DateTime Date { get; set; }

    [Required]
    public decimal Profit { get; set; }

    [Required]
    public decimal Output { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<StockHistoryRowDTO, Models.StockHistoryRow>();
        profile.CreateMap<Models.StockHistoryRow, StockHistoryRowDTO>();
    }
}
