using HangryHub.OrderService.Contracts.Messages;
using HangryHub.OrderService.Core.Interfaces;
using HangryHub.OrderService.Core.OrderAggregate.Enums;
using MassTransit;

namespace HangryHub.OrderService.Infrastructure.Data.Order.Services
{
    public class OrderStatusChangeService : IOrderStatusChangeService
    {
        private IPublishEndpoint publishEndpoint;

        public OrderStatusChangeService(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task OrderStatusChangeAsync(Guid id, OrderState status)
        {
            await publishEndpoint.Publish<OrderStatusUpdate>(new()
            {
                Id = id,
                Status = MapStatus(status),
            });
        }

        private OrderStatus MapStatus(OrderState status)
        {
            if (status == OrderState.Accepted)
                return OrderStatus.Accepted;
            if (status == OrderState.Ready)
                return OrderStatus.Ready;
            if (status == OrderState.Declined)
                return OrderStatus.Declined;
            throw new ArgumentException("Status not allowed in this case");
        }
    }
}
