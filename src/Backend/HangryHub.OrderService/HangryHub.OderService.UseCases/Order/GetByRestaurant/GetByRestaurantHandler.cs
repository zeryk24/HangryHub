using ErrorOr;
using HangryHub.OderService.UseCases.Order.DTOs;
using HangryHub.OrderService.Core.Interfaces;
using Mapster;
using MediatR;

namespace HangryHub.OderService.UseCases.Order.GetByRestaurant
{
    public class GetByRestaurantHandler(IGetByRestaurantService orderRestaurantService) : IRequestHandler<GetByRestaurantQuery, ErrorOr<List<OrderDTO>>>
    {
        public async Task<ErrorOr<List<OrderDTO>>> Handle(GetByRestaurantQuery request, CancellationToken cancellationToken)
        {
            var result = await orderRestaurantService.GetByRestaurant(request.Id);
            if (result.IsError)
            {
                return result.Errors;
            }
            var orders = result.Value;
            if (orders == null)
            {
                return Error.Failure();
            }
            
            var ordersDTOs = new List<OrderDTO>();

            foreach (var orderEntity in orders)
            {
                ordersDTOs.Add(orderEntity.Adapt<OrderDTO>());
            }

            return ordersDTOs;
        }
    }
}
