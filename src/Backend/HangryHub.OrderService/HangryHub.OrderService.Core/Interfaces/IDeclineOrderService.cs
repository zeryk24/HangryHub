using ErrorOr;

namespace HangryHub.OrderService.Core.Interfaces
{
    public interface IDeclineOrderService
    {
        Task<ErrorOr<OrderAggregate.Order>> DeclineOrderAsync(Guid id);
    }
}
