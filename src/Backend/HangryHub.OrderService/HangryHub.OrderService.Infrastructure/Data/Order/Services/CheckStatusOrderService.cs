using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;
using HangryHub.OrderService.Core.OrderAggregate.Enums;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class CheckStatusOrderService : ICheckStatusOrderService
    {
        private IRepository<Core.OrderAggregate.Order> OrderRepository { get; set; }

        public CheckStatusOrderService(IRepository<Core.OrderAggregate.Order> orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public async Task<ErrorOr<OrderState>> CheckStatusOrderAsync(Guid id)
        {
            var order = await OrderRepository.GetByIdAsync(id);
            if (order is null)
            {
                return Error.NotFound();
            }
            return order.OrderState;
        }
    }
}
