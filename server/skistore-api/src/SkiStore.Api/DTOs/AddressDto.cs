#nullable disable

using System.ComponentModel.DataAnnotations;
using SkiStore.Core.Base.Entities;

namespace SkiStore.Api.DTOs;

public class AddressDto
{
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string PostalCode { get; set; }
    [Required]
    public string Line1 { get; set; }
#nullable enable
    public string? Line2 { get; set; }
}
