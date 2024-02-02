using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Ready
{
    public class ReadyOrderHandler(IReadyOrderService readyOrderService) : IRequestHandler<ReadyOrderCommand, ErrorOr<OrderDTO>>
    {
        public async Task<ErrorOr<OrderDTO>> Handle(ReadyOrderCommand request, CancellationToken cancellationToken)
        {
            var orderResult = await readyOrderService.ReadyOrderAsync(request.Id);
            if (orderResult.IsError)
            {
                return orderResult.Errors;
            }
            var order = orderResult.Value;
            return order.Adapt<OrderDTO>();
        }
    }
}
