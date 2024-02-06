using MediatR;
namespace HangryHub.DeliveryService.Application.Delivery.Queries.ListAvaiable
{
    public record ListAvaiableQuery() : IRequest<ICollection<ListAvaiableQueryResultItem>> { }

}
