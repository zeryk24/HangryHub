namespace HangryHub.OderService.UseCases.Order.DTOs
{
    public class OrderItemDTO
    {
        public RestaurantItemIdDTO RestaurantItemId { get; set; }
        public ItemNameDTO Name { get; set; }
        public ItemQuantityDTO Quantity { get; set; }
        public ItemPriceDTO Price { get; set; }
        public List<ExtraIngredientDTO> ExtraIngredients { get; set; }
    }
}
