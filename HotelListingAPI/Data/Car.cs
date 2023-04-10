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
		[ForeignKey(nameof(DealershipId))]
		public int DealershipId { get; set; }
		public Dealership dealership { get; set; }
	}
}