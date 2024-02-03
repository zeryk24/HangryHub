namespace HangryHub.MainService.API.Models
{
    public class RestaurantCreateModel
    {
        public required string Name { get; set; }
        public required string AddressLine1 { get; set; }
        public required string AddressLine2 { get; set; }
        public required string Country { get; set; }
    }
}
