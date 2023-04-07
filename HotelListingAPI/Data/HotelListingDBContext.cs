using System;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data
{
	public class HotelListingDBContext : DbContext
	{
		public HotelListingDBContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Country> Countries { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Country>()
				.Property(e => e.Name)
				.HasMaxLength(50); // Set the maximum length of the property to 50 characters
            modelBuilder.Entity<Country>()
                .Property(e => e.ShortName)
                .HasMaxLength(50); // Set the maximum length of the property to 50 characters
            modelBuilder.Entity<Hotel>()
                .Property(e => e.Name)
                .HasMaxLength(100); // Set the maximum length of the property to 100 characters
            modelBuilder.Entity<Hotel>()
                .Property(e => e.Address)
                .HasMaxLength(50); // Set the maximum length of the property to 50 characters


            modelBuilder.Entity<Country>().HasData(
                    new Country
                    {
                        Id = 1,
                        Name = "Jamaica",
                        ShortName = "JM"
                    },
                    new Country
                    {
                        Id = 2,
                        Name = "Bahamas",
                        ShortName = "BS"
                    },
                    new Country
                    {
                        Id = 3,
                        Name = "Cayman Island",
                        ShortName = "CI"
                    }
                );

            modelBuilder.Entity<Hotel>().HasData(
                    new Hotel
                    {
                        Id = 1,
                        Name = "Sandals Resort and Spa",
                        Address = "Negril",
                        CountryId = 1,
                        Rating = 4.5
                    },
                    new Hotel
                    {
                        Id = 2,
                        Name = "Comfort Suites",
                        Address = "George Town",
                        CountryId = 3,
                        Rating = 4.3
                    },
                    new Hotel
                    {
                        Id = 3,
                        Name = "Grand Palldium",
                        Address = "Nassua",
                        CountryId = 2,
                        Rating = 4
                    }
                );
        }
	}
}

