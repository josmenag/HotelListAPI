using System;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Repository
{
	public class DealershipsRepository : GenericRepository<Dealership>, IDealershipsRepository
    {
        private readonly HotelListingDBContext _context;

        public DealershipsRepository(HotelListingDBContext context) : base(context)
		{
            this._context = context;
		}

        public async Task<Dealership> GetDetails(int id)
        {
            return await _context.Dealerships.Include(q => q.Cars)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}

