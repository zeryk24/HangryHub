using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Queries.GetNavigation
{
    public record GetNavigationQuery(Guid DeliveryID) : IRequest<NavigationData>
    {
    }

}
