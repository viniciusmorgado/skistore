using SkiStore.Api.DTOs;
using SkiStore.Core.Entities;

namespace SkiStore.Api.Extensions;

public static class AddressMappingExtensions
{
    public static AddressDTO ToDto(this Address address)
    {
        // if (address == null) return null;
        ArgumentNullException.ThrowIfNull(address);

        return new AddressDTO
        {
            Line1 = address.Line1,
            Line2 = address.Line2,
            City = address.City,
            State = address.State,
            Country = address.Country,
            PostalCode = address.PostalCode,
            Reference = address.Reference
        };
    }

    public static Address ToEntity(this AddressDTO addressDto)
    {
        ArgumentNullException.ThrowIfNull(addressDto);

        return new Address
        {
            Line1 = addressDto.Line1,
            Line2 = addressDto.Line2,
            City = addressDto.City,
            State = addressDto.State,
            Country = addressDto.Country,
            PostalCode = addressDto.PostalCode,
            Reference = addressDto.Reference
        };
    }

    public static void UpdateFromDto(this Address address, AddressDTO addressDto)
    {
        ArgumentNullException.ThrowIfNull(addressDto);
        ArgumentNullException.ThrowIfNull(address);

        address.Line1 = addressDto.Line1;
        address.Line2 = addressDto.Line2;
        address.City = addressDto.City;
        address.State = addressDto.State;
        address.Country = addressDto.Country;
        address.PostalCode = addressDto.PostalCode;
        address.Reference = addressDto.Reference;
    }
}
