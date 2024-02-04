using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MassTransit;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Accept
{
    public class AcceptOrderHandler : IRequestHandler<AcceptOrderCommand, ErrorOr<OrderDTO>>
    {
        private IAcceptOrderService acceptOrderService;
        private IPublishEndpoint publishEndpoint;

        public AcceptOrderHandler(IAcceptOrderService acceptOrderService, IPublishEndpoint publishEndpoint)
        {
            this.acceptOrderService = acceptOrderService;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task<ErrorOr<OrderDTO>> Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
        {
            var orderResult = await acceptOrderService.AcceptOrderAsync(request.Id);
            if (orderResult.IsError)
            {
                return orderResult.Errors;
            }

            await UpdateOrderStateAsync();

            var order = orderResult.Value;
            return order.Adapt<OrderDTO>();
        }

        private async Task UpdateOrderStateAsync()
        {
            await publishEndpoint.Publish<OrderSubmitted>(new()
            {
                OrderId = "27",
                OrderDate = DateTime.UtcNow,
            });
        }
    }

    public record OrderSubmitted
    {
        public string OrderId { get; init; }
        public DateTime OrderDate { get; init; }
    }
}
