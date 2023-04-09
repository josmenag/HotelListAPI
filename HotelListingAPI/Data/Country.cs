namespace HotelListingAPI.Data
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public virtual IList<Car> Cars { get; set; }
    }
}