namespace HangryHub.RestaurantService.Contracts.Restaurant.Messages
{
    public record RestaurantItemUpdateMessage
    {
        public Guid Id { get; init; }
        public List<RestaurantItemMessage> RestaurantItems { get; init; }
    }

    public record RestaurantItemMessage
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public double EuroPrice { get; init; }
        public List<RestaurantItemIngredient> Ingredients { get; init; }
        public List<RestaurantItemExtraIngredient> ExtraIngredients { get; init; }
    }

    public record RestaurantItemIngredient
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }

    public record RestaurantItemExtraIngredient
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
    }
}
