namespace HangryHub.OrderService.Contracts.Messages
{
    public record OrderStatusUpdate
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
