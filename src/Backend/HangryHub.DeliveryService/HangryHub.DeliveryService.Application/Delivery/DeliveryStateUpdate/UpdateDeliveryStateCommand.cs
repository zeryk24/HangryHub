using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.DeliveryStateUpdate
{
    public record UpdateDeliveryStateCommand : IRequest
    {
    }
}
