using ErrorOr;
using HangryHub.OderService.UseCases.Order.DTOs;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Ready
{
    public class ReadyOrderHandler : IRequestHandler<ReadyOrderCommand, ErrorOr<OrderDTO>>
    {
        private IReadyOrderService readyOrderService;
        private IOrderStatusChangeService orderStatusChangeService;

        public ReadyOrderHandler(IReadyOrderService readyOrderService, IOrderStatusChangeService orderStatusChangeService)
        {
            this.readyOrderService = readyOrderService;
            this.orderStatusChangeService = orderStatusChangeService;
        }

        public async Task<ErrorOr<OrderDTO>> Handle(ReadyOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orderResult = await readyOrderService.ReadyOrderAsync(request.Id);
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
