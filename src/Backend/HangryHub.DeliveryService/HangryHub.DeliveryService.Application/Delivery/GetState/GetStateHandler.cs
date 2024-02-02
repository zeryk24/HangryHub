using HangryHub.DeliveryService.Application.Delivery.Get;
using HangryHub.DeliveryService.Application.Delivery.ListAvaiable;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.GetState
{
    public class GetStateHandler : IRequestHandler<GetStateQuery, GetStateQueryResult>
    {
        IDeliveryStateService _queryService;
        public GetStateHandler(IDeliveryStateService queryService)
        {
            _queryService = queryService;
        }
        public async Task<GetStateQueryResult> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            var state = await _queryService.GetState(request.deliveryID);
            var timeEstimate = await _queryService.GetTimeEstimate(request.deliveryID);

            var response_state = state switch
            {
                DeliveryState.NotAsigned => GetStateQueryResultDeliveryState.Cooking,
                DeliveryState.WaitingForPickup => GetStateQueryResultDeliveryState.WaitingForPickup,
                DeliveryState.OnTheWay => GetStateQueryResultDeliveryState.OnTheWay,
                DeliveryState.Finished => GetStateQueryResultDeliveryState.Delivered,
                _ => throw new Exception("Invalid state"),
            };
            return new GetStateQueryResult(response_state, timeEstimate);
        }
    }
}
