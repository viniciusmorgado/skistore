using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiStore.Core.Entities;

namespace SkiStore.Infrastructure.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
#if DEBUG
        builder.HasData(
            new Address
            {
                Id = 1,
                City = "New York",
                State = "NY",
                Country = "USA",
                PostalCode = "10001",
                Line1 = "123 Main St",
                Line2 = "Apt 4B"
            },
            new Address
            {
                Id = 2,
                City = "Los Angeles",
                State = "CA",
                Country = "USA",
                PostalCode = "90001",
                Line1 = "456 Elm St",
                Line2 = null
            },
            new Address
            {
                Id = 3,
                City = "Chicago",
                State = "IL",
                Country = "USA",
                PostalCode = "60601",
                Line1 = "789 Oak St",
                Line2 = "Suite 100"
            },
            new Address
            {
                Id = 4,
                City = "Houston",
                State = "TX",
                Country = "USA",
                PostalCode = "77001",
                Line1 = "101 Pine St",
                Line2 = null
            },
            new Address
            {
                Id = 5,
                City = "Phoenix",
                State = "AZ",
                Country = "USA",
                PostalCode = "85001",
                Line1 = "202 Maple St",
                Line2 = "Unit 5"
            },
            new Address
            {
                Id = 6,
                City = "Philadelphia",
                State = "PA",
                Country = "USA",
                PostalCode = "19019",
                Line1 = "303 Cedar St",
                Line2 = null
            },
            new Address
            {
                Id = 7,
                City = "San Antonio",
                State = "TX",
                Country = "USA",
                PostalCode = "78201",
                Line1 = "404 Birch St",
                Line2 = "Apt 3C"
            },
            new Address
            {
                Id = 8,
                City = "San Diego",
                State = "CA",
                Country = "USA",
                PostalCode = "92101",
                Line1 = "505 Walnut St",
                Line2 = null
            },
            new Address
            {
                Id = 9,
                City = "Dallas",
                State = "TX",
                Country = "USA",
                PostalCode = "75201",
                Line1 = "606 Cherry St",
                Line2 = "Suite 200"
            },
            new Address
            {
                Id = 10,
                City = "San Jose",
                State = "CA",
                Country = "USA",
                PostalCode = "95101",
                Line1 = "707 Spruce St",
                Line2 = null
            }
        );
#endif
    }
}
