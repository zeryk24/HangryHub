using ErrorOr;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Accept
{
    public class AcceptOrderHandler(IAcceptOrderService acceptOrderService) : IRequestHandler<AcceptOrderCommand, ErrorOr<OrderDTO>>
    {
        public async Task<ErrorOr<OrderDTO>> Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
        {
            var orderResult = await acceptOrderService.AcceptOrderAsync(request.Id);
            if (orderResult.IsError)
            {
                return orderResult.Errors;
            }
            var order = orderResult.Value;
            return order.Adapt<OrderDTO>();
        }
    }
}
