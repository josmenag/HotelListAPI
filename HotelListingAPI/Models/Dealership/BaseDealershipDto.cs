using System;
using Microsoft.Build.Framework;

namespace HotelListingAPI.Models.Country
{
	public class BaseDealershipDto
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}

