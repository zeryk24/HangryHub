using ErrorOr;

namespace HangryHub.OrderService.Core.Interfaces
{
    public interface IAcceptOrderService
    {
        Task<ErrorOr<OrderAggregate.Order>> AcceptOrderAsync(Guid id);
    }
}
