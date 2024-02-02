using HangryHub.DeliveryService.Application.Delivery.Get;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.ListAvaiable
{
    public class ListAvaiableHandler : IRequestHandler<ListAvaiableQuery, ICollection<ListAvaiableQueryResultItem>>
    {
        IListAvaiableQueryService _queryService;
        public ListAvaiableHandler(IListAvaiableQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<ICollection<ListAvaiableQueryResultItem>> Handle(ListAvaiableQuery request, CancellationToken cancellationToken)
        {
            var result = await _queryService.Fetch();
      

            List<ListAvaiableQueryResultItem> items = new();
            foreach (var item in result)
            {
                items.Add(new ListAvaiableQueryResultItem()
                {
                    DeliveryId = item.Id,
                    CustomerDeliveryLocation = item.Customer.DeliveryLocation,
                    Restaurant = item.Restaurant.Location
                }) ;
            }

            return items;
        }
    }
}
