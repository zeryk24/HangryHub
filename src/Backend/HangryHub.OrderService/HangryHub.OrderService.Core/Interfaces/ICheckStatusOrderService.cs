using ErrorOr;

namespace HangryHub.OrderService.Core.Interfaces
{
    public interface ICheckStatusOrderService
    {
        Task<ErrorOr<OrderAggregate.Enums.OrderState>> CheckStatusOrderAsync(Guid id);
    }
}
