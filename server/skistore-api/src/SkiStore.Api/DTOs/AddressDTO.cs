#nullable disable

using SkiStore.Core.Base.Entities;

namespace SkiStore.Api.DTOs;

public class AddressDTO
{
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Reference { get; set; }
    public string PostalCode { get; set; }
    public string Line1 { get; set; }
#nullable enable
    public string? Line2 { get; set; }
}
