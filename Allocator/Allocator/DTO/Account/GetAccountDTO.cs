using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace Allocator.API.DTO.Account;

// ReSharper disable once InconsistentNaming
public class GetAccountDTO
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int AccountId { get; set; }
}
