using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Queries.GetState
{
    public record GetStateQuery(Guid deliveryID) : IRequest<GetStateQueryResult> { }

}
