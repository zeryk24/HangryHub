namespace HangryHub.MainService.API.Models
{
    public class RestaurantFetchListModel
    {
        public required IEnumerable<Guid> RestaurantGuids { get; set; }
    }
}
