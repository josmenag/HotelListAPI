using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models.Country;
using HotelListingAPI.Models.Hotels;
using HotelListingAPI.Models.Users;

namespace HotelListingAPI.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<Dealership, CreateDealershipDto>().ReverseMap();
            CreateMap<Dealership, GetDealershipDto>().ReverseMap();
            CreateMap<Dealership, DealershipDto>().ReverseMap();
            CreateMap<Dealership, UpdateDealershipDto>().ReverseMap();

            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CreateCarDto>().ReverseMap();

            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
        }
    }
}

