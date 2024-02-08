namespace HangryHub.OrderService.Core.Interfaces
{
    public interface ICreateOrderService
    {
        Task<OrderAggregate.Order> CreateOrderAsync(Core.OrderAggregate.Order order);
    }
}
