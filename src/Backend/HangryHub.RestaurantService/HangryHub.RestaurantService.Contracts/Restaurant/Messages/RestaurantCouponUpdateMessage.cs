namespace HangryHub.RestaurantService.Contracts.Restaurant.Messages
{
    public record RestaurantCouponUpdateMessage
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public double EuroPrice { get; init; }
        public DateTime ExpirationDate { get; init; }
    }
}
