#nullable disable

using SkiStore.Core.Base.Entities;

namespace SkiStore.Core.Entities;

public class Address : BaseEntity
{
    public required string City { get; set; }
    public required string State { get; set; } // or province
    public required string Country { get; set; }
    public required string Reference { get; set; }
    public required string PostalCode { get; set; }
    public required string Line1 { get; set; }
#nullable enable
    public string? Line2 { get; set; }
}
