using System;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;

namespace HotelListingAPI.Repository
{
	public class CarsRepository : GenericRepository<Car>, ICarsRepository
	{
		public CarsRepository(HotelListingDBContext contex) : base(contex)
		{
		}
	}
}