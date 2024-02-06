using HangryHub.OrderService.Core.OrderAggregate.Enums;

namespace HangryHub.OrderService.Core.Interfaces
{
    public interface IOrderStatusChangeService
    {
        Task OrderStatusChangeAsync(Guid id, OrderState status);
    }
}
