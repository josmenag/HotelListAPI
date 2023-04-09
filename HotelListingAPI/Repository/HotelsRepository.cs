using System;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;

namespace HotelListingAPI.Repository
{
	public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
	{
		public HotelsRepository(HotelListingDBContext contex) : base(contex)
		{
		}
	}
}

