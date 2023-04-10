using System;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;

namespace HotelListingAPI.Repository
{
	public class CarsRepository : GenericRepository<Car>, ICarsRepository
	{
		public CarsRepository(CarsInventoryDBContext contex) : base(contex)
		{
		}
	}
}