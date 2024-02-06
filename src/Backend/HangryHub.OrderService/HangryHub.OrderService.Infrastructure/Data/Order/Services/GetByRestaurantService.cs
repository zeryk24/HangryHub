using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class GetByRestaurantService : IGetByRestaurantService
    {
        private IRepository<Core.OrderAggregate.Order> OrderRepository { get; set; }

        public GetByRestaurantService(IRepository<Core.OrderAggregate.Order> orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public async Task<ErrorOr<List<Core.OrderAggregate.Order>>> GetByRestaurant(Guid id)
        {
            var orders = await OrderRepository.GetAllAsync();
            if (orders == null)
            {
                return Error.Failure();
            }
            return orders.Where(o => o.RestaurantId.Id == id).ToList();
        }
    }
}
