using ErrorOr;
using HangryHub.OderService.UseCases.Order.DTOs;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MassTransit;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Accept
{
    public class AcceptOrderHandler : IRequestHandler<AcceptOrderCommand, ErrorOr<OrderDTO>>
    {
        private IAcceptOrderService acceptOrderService;
        private IOrderStatusChangeService orderStatusChangeService;

        public AcceptOrderHandler(IAcceptOrderService acceptOrderService, IOrderStatusChangeService orderStatusChangeService)
        {
            this.acceptOrderService = acceptOrderService;
            this.orderStatusChangeService = orderStatusChangeService;
        }

        public async Task<ErrorOr<OrderDTO>> Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orderResult = await acceptOrderService.AcceptOrderAsync(request.Id);

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
