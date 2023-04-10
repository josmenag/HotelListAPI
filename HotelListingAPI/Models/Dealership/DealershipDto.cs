using HotelListingAPI.Models.Hotels;

namespace HotelListingAPI.Models.Country
{
    public class DealershipDto : BaseDealershipDto
    {
        public int Id { get; set; }
        
        public List<CarDto> Cars { get; set; }

    
    }
}

