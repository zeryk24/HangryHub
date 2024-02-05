namespace HangryHub.OderService.UseCases.Order.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public PriceDTO PriceEuro { get; set; }
        public AcceptDTO OrderAccepted { get; set; }
        public DeclineDTO OrderDeclined { get; set; }
        public OrderReadyDTO OrderReady { get; set; }
        public OrderStatusDTO OrderState { get; set; }
        public CouponDTO? Coupon { get; set; }
        public UserIdDTO UserId { get; set; }
        public RestaurantIdDTO RestaurantId { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
