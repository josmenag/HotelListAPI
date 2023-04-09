﻿using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models.Hotels
{
    public abstract class BaseHotelDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double? Rating { get; set; } // ? = not required
        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}

