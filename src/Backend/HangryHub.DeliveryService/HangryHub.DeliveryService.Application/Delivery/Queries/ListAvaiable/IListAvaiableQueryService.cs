using HangryHub.DeliveryService.Domain.DeliveryAggregate;

namespace HangryHub.DeliveryService.Application.Delivery.Queries.ListAvaiable
{
    public interface IListAvaiableQueryService
    {
        Task<ICollection<Domain.DeliveryAggregate.Delivery>> Fetch();
    }
}
