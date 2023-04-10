using HotelListingAPI.Data;

namespace HotelListingAPI.Contracts
{
    public interface IDealershipsRepository : IGenericRepository<Dealership>
    {
        Task<Dealership> GetDetails(int id);
    }
}

