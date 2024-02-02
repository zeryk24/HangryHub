using HangryHub.OrderService.Core.OrderAggregate;

namespace HangryHub.OrderService.Core.Interfaces
{
    public interface IGetOrderByIdService
    {
        public Order GetOrderById(Guid Id);
    }
}
