using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums
{
    public enum DeliveryState
    {
        NotAsigned,
        WaitingForPickup,
        OnTheWay,
        Finished
    }
}
