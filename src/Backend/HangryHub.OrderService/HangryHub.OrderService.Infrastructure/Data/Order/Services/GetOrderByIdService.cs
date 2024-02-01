using HangryHub.OrderService.Core.Interfaces;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class GetOrderByIdService : IGetOrderByIdService
    {
        public Core.OrderAggregate.Order GetOrderById(Guid Id)
        {
            return new Core.OrderAggregate.Order(new Core.OrderAggregate.ValueObjects.Price(20),
                new Core.OrderAggregate.ValueObjects.Accept(false, null),
                new Core.OrderAggregate.ValueObjects.Decline(false, null));
        }
    }
}
