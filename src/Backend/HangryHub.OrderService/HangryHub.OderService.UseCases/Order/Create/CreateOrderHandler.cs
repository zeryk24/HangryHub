using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.Create
{
    public class CreateOrderHandler(ICreateOrderService createOrderService) : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await createOrderService.CreateOrderAsync(request.EuroPrice);
            return order.Adapt<OrderDTO>();
        }
    }
}
