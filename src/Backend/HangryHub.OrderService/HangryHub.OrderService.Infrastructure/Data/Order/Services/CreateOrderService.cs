using HangryHub.OrderService.Core.Interfaces;
using HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity.ValueObjects;
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

        public async Task<Core.OrderAggregate.Order> CreateOrderAsync(Core.OrderAggregate.Order order)
        {
            await OrderRepository.CreateAsync(order);
            await OrderRepository.SaveAsync();
            return order;
        }
    }
}
