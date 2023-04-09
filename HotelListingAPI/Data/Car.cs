using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListingAPI.Data
{
	public class Car
	{
		public int Id { get; set; }
		public string Make { get; set; }
		public string Plate { get; set; }
		public int Year { get; set; }
		[ForeignKey(nameof(CountryId))]
		public int CountryId { get; set; }
		public Country Country { get; set; }
	}
}