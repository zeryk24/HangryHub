using HangryHub.OrderService.Core.Interfaces;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class GetOrderByIdService : IGetOrderByIdService
    {
        public Core.OrderAggregate.Order GetOrderById(Guid Id)
        {
            return null;
        }
    }
}
