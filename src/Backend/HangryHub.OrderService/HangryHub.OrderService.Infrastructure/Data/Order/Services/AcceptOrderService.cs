using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class AcceptOrderService : IAcceptOrderService
    {
        private IRepository<Core.OrderAggregate.Order> OrderRepository { get; set; }

        public AcceptOrderService(IRepository<Core.OrderAggregate.Order> orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public async Task<ErrorOr<Core.OrderAggregate.Order>> AcceptOrderAsync(Guid id)
        {
            var order = await OrderRepository.GetByIdAsync(id);
            if (order is null)
            {
                return Error.NotFound();
            }

            order.AcceptOrder();
            OrderRepository.Update(order);
            await OrderRepository.SaveAsync();
            return order;
        }
    }
}
