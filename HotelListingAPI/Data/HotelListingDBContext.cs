using System;
using System.Xml;
using HotelListingAPI.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data
{
	public class HotelListingDBContext : IdentityDbContext<ApiUser>
	{
		public HotelListingDBContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Country> Countries { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());


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
        }
	}
}

