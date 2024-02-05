using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.Queries.GetState
{
    public interface IDeliveryStateService
    {
        Task<DeliveryState> GetState(Guid deliveryID);
        Task<TimeSpan> GetTimeEstimate(Guid deliveryID);

    }
}
