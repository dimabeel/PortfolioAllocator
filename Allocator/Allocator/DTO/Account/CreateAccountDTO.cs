﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace Allocator.API.DTO.Account;

// ReSharper disable once InconsistentNaming
public class CreateAccountDTO
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(3)]
    public string Currency { get; set; }
}
