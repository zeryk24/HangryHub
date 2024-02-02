using HangryHub.DeliveryService.Application.Delivery.ListAvaiable;
using MediatR;
namespace HangryHub.DeliveryService.Application.Delivery.Get
{
    public record ListAvaiableQuery() : IRequest<ICollection<ListAvaiableQueryResultItem>> { }

}
