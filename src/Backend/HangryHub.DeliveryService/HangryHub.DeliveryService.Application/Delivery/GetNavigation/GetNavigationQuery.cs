using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.GetNavigation
{
    public record GetNavigationQuery (Guid DeliveryID) : IRequest<NavigationData>
    {
    }

}
