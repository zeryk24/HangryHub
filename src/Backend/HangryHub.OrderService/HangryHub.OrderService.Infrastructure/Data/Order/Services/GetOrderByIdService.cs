using HangryHub.OrderService.Core.Interfaces;
using HangryHub.OrderService.Core.OrderAggregate;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class GetOrderByIdService : IGetOrderByIdService
    {
        public Core.OrderAggregate.Order GetOrderById(Guid Id)
        {
            return new Core.OrderAggregate.Order(new Core.OrderAggregate.ValueObjects.Price(20));
        }
    }
}
