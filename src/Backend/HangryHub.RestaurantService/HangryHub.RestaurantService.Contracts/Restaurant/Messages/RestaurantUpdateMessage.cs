namespace HangryHub.RestaurantService.Contracts.Restaurant.Messages
{
    public record RestaurantUpdateMessage
    {
        public Guid RestaurantId { get; init; }
        public string RestaurantName { get; set; }
        public string Address { get; init; }
        public string Contact { get; init; }
        public string Note { get; init; }
    }
}
