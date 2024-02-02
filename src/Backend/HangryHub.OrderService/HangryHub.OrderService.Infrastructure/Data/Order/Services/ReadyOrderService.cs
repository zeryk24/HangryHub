using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class ReadyOrderService : IReadyOrderService
    {
        private IRepository<Core.OrderAggregate.Order> OrderRepository { get; set; }

        public ReadyOrderService(IRepository<Core.OrderAggregate.Order> orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public async Task<ErrorOr<Core.OrderAggregate.Order>> ReadyOrderAsync(Guid id)
        {
            var order = await OrderRepository.GetByIdAsync(id);
            if (order is null)
            {
                return Error.NotFound();
            }

            order.OrderIsReady();
            OrderRepository.Update(order);
            await OrderRepository.SaveAsync();
            return order;
        }
    }
}
