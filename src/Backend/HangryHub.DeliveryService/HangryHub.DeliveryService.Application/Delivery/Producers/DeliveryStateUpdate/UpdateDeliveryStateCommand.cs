using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.Producers.DeliveryStateUpdate
{
    public record UpdateDeliveryStateCommand : IRequest
    {
    }
}
