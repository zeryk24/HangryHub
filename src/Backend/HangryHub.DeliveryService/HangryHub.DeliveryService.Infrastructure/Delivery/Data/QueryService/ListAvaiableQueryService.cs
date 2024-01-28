using HangryHub.DeliveryService.Application.Delivery.ListAvaiable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Infrastructure.Delivery.Data.QueryService
{
    public class ListAvaiableQueryService : IListAvaiableQueryService
    {
        public Task<ICollection<Domain.DeliveryAggregate.Delivery>> Fetch()
        {
            return Task.FromResult((ICollection<Domain.DeliveryAggregate.Delivery>)new List<Domain.DeliveryAggregate.Delivery>());
        }
    }
}
