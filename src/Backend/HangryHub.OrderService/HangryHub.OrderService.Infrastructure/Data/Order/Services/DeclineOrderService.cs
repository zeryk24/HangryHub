using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class DeclineOrderService : IDeclineOrderService
    {
        private IRepository<Core.OrderAggregate.Order> OrderRepository { get; set; }
        
        public DeclineOrderService(IRepository<Core.OrderAggregate.Order> orderRepository)
        {
            OrderRepository=orderRepository;
        }
        
        public async Task<ErrorOr<Core.OrderAggregate.Order>> DeclineOrderAsync(Guid id)
        {
            var order = await OrderRepository.GetByIdAsync(id);
            if (order is null)
            {
                return Error.NotFound();
            }

            order.DeclineOrder();
            OrderRepository.Update(order);
            await OrderRepository.SaveAsync();
            return order;
        }
    }
}
