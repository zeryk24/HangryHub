using HangryHub.OrderService.Core.Interfaces;

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
                new Core.OrderAggregate.ValueObjects.Ready(false, null));
            await OrderRepository.CreateAsync(orderAggregate);
            await OrderRepository.SaveAsync();
            return orderAggregate;
        }
    }
}
