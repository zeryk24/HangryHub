using ErrorOr;

namespace HangryHub.OrderService.Core.Interfaces
{
    public interface IReadyOrderService
    {
        Task<ErrorOr<OrderAggregate.Order>> ReadyOrderAsync(Guid id);
    }
}
