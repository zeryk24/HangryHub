namespace HangryHub.OderService.UseCases.Order.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public PriceDTO PriceEuro { get; set; }
        public OrderStatusDTO OrderState { get; set; }
        public CouponDTO? Coupon { get; set; }
        public UserIdDTO UserId { get; set; }
        public RestaurantIdDTO RestaurantId { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
