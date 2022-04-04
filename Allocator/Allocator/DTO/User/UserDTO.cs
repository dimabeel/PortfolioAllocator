using System.ComponentModel.DataAnnotations;
using Allocator.API.Mapping;
using AutoMapper;

#pragma warning disable CS8618

namespace Allocator.API.DTO.User;

// ReSharper disable once InconsistentNaming
public class UserDTO : IMapWith<Models.User>
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [MinLength(2)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string Surname { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Models.User, UserDTO>();
        profile.CreateMap<UserDTO, Models.User>();
    }
}
