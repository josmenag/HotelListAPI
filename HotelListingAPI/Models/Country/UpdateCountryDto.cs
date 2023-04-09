using System;
using Microsoft.Identity.Client;

namespace HotelListingAPI.Models.Country
{
	public class UpdateCountryDto : BaseCountryDto
    {
        public int Id { get; set; }
    }
}

