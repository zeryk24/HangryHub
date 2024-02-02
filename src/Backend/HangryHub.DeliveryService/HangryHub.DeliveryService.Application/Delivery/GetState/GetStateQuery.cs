using HangryHub.DeliveryService.Application.Delivery.ListAvaiable;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.GetState
{
    public record GetStateQuery(Guid deliveryID)  : IRequest<GetStateQueryResult> { }
   
}
