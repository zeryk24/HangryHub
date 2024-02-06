using ErrorOr;
using HangryHub.OderService.UseCases.Order.DTOs;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Decline
{
    public class DeclineOrderHandler : IRequestHandler<DeclineOrderCommand, ErrorOr<OrderDTO>>
    {
        private IDeclineOrderService declineOrderService;
        private IOrderStatusChangeService orderStatusChangeService;

        public DeclineOrderHandler(IDeclineOrderService declineOrderService, IOrderStatusChangeService orderStatusChangeService)
        {
            this.declineOrderService = declineOrderService;
            this.orderStatusChangeService = orderStatusChangeService;
        }

        public async Task<ErrorOr<OrderDTO>> Handle(DeclineOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orderResult = await declineOrderService.DeclineOrderAsync(request.Id);
                if (orderResult.IsError)
                {
                    return orderResult.Errors;
                }
                var order = orderResult.Value;
                await orderStatusChangeService.OrderStatusChangeAsync(order.Id, order.OrderState);

                return order.Adapt<OrderDTO>();
            }
            catch (ArgumentException)
            {
                return Error.Conflict();
            }
        }
    }
}
