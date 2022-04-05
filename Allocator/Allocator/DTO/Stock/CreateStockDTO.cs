using System.ComponentModel.DataAnnotations;
using Allocator.API.Mapping;
using AutoMapper;

#pragma warning disable CS8618
namespace Allocator.API.DTO.Stock;

// ReSharper disable once InconsistentNaming
public class CreateStockDTO : IMapWith<Models.Stock>
{
    [Required]
    public int AccountId { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Company { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateStockDTO, Models.Stock>();
    }
}
