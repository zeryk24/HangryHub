using HangryHub.OrderService.Core.Interfaces;
using HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class CreateOrderService : ICreateOrderService
    {
        private IRepository<Core.OrderAggregate.Order> OrderRepository { get; set; }

        public CreateOrderService(IRepository<Core.OrderAggregate.Order> orderRepository)
        {
            this.OrderRepository = orderRepository;
        }

        public async Task<Core.OrderAggregate.Order> CreateOrderAsync(double euroPrice)
        {
            var orderAggregate = new Core.OrderAggregate.Order(new Core.OrderAggregate.ValueObjects.Price(euroPrice),
                new Core.OrderAggregate.ValueObjects.Accept(false, null),
                new Core.OrderAggregate.ValueObjects.Decline(false, null),
                new Core.OrderAggregate.ValueObjects.Ready(false, null),
                null,
                new Core.OrderAggregate.ValueObjects.UserId(Guid.Empty),
                new List<Core.OrderAggregate.Entities.OrderItemEntity.OrderItem>
                {
                    new Core.OrderAggregate.Entities.OrderItemEntity.OrderItem(
                        new RestaurantItemId(Guid.Empty),
                    new ItemName("Watter"),
                    new ItemQuantity(1),
                    new ItemPrice(20))
                });
            await OrderRepository.CreateAsync(orderAggregate);
            await OrderRepository.SaveAsync();
            return orderAggregate;
        }
    }
}
