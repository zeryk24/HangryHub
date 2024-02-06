using ErrorOr;

namespace HangryHub.OrderService.Core.Interfaces
{
    public interface IGetByRestaurantService
    {
        Task<ErrorOr<List<OrderAggregate.Order>>> GetByRestaurant(Guid id);
    }
}
