using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models.Hotels
{
    public abstract class BaseCarDto
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public string vin { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int DealershipId { get; set; }
    }
}