using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListingAPI.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                    new Car
                    {
                        Id = 1,
                        Make = "BMW",
                        Plate = "F45T",
                        CountryId = 1,
                        Year = 2020
                    },
                    new Car
                    {
                        Id = 2,
                        Make = "Mercedes-Benz",
                        Plate = "KOOL-1",
                        CountryId = 3,
                        Year = 2023
                    },
                    new Car
                    {
                        Id = 3,
                        Make = "Lamborghini",
                        Plate = "D14BL0",
                        CountryId = 2,
                        Year = 2021
                    }
                );
        }
    }
}

