using ErrorOr;
using HangryHub.OderService.UseCases.Order.DTOs;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.CheckStatus
{
    public class CheckStatusOrderHandler(ICheckStatusOrderService checkStatusOrderService) : IRequestHandler<CheckStatusOrderCommand, ErrorOr<OrderStatusDTO>>
    {
        public async Task<ErrorOr<OrderStatusDTO>> Handle(CheckStatusOrderCommand request, CancellationToken cancellationToken)
        {
            var orderResult = await checkStatusOrderService.CheckStatusOrderAsync(request.Id);
            if (orderResult.IsError)
            {
                return orderResult.Errors;
            }
            var order = orderResult.Value;
            return order.Adapt<OrderStatusDTO>();
        }
    }
}
