using System;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Repository
{
	public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
	{
        private readonly HotelListingDBContext _context;

        public CountriesRepository(HotelListingDBContext context) : base(context)
		{
            this._context = context;
		}

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}

