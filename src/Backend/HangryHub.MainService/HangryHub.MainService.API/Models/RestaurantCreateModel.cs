namespace HangryHub.MainService.API.Models
{
    public class RestaurantCreateModel
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Contact { get; set; }
        public required string Note { get; set; }
    }
}
