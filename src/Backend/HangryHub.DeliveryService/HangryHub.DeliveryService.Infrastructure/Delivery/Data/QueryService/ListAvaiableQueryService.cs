using HangryHub.DeliveryService.Application.Delivery.ListAvaiable;
using HangryHub.DeliveryService.Infrastructure.Common.Data;

namespace HangryHub.DeliveryService.Infrastructure.Delivery.Data.QueryService
{
    public class ListAvaiableQueryService : IListAvaiableQueryService
    {
        DeliveryServiceContext _context;
        public ListAvaiableQueryService(DeliveryServiceContext context) {
            _context = context;
        }

        public Task<ICollection<Domain.DeliveryAggregate.Delivery>> Fetch()
        {
            var res = _context.Deliveries.Where(
                x => x.State == Domain.DeliveryAggregate.Enums.DeliveryState.NotAsigned);
            var col = (ICollection<Domain.DeliveryAggregate.Delivery>)res.ToList();

            return Task.FromResult(col);
        }
    }
}
