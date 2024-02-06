using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.Queries.GetState
{
    public record GetStateQueryResult(GetStateQueryResultDeliveryState DeliveryState, TimeSpan TimeEstimate)
    {
    }

    public enum GetStateQueryResultDeliveryState
    {
        Cooking,
        WaitingForPickup,
        OnTheWay,
        Delivered,
    }
}
