using System.ComponentModel.DataAnnotations;
using Allocator.API.Mapping;
using AutoMapper;

#pragma warning disable CS8618

namespace Allocator.API.DTO.Account;

// ReSharper disable once InconsistentNaming
public class CreateAccountDTO : IMapWith<Models.Account>
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(3)]
    public string Currency { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateAccountDTO, Models.Account>();
    }
}
