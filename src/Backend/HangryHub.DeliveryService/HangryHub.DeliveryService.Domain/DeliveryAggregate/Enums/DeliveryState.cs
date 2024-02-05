using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums
{
    public enum DeliveryState
    {
        // Restaurant has not accepted the order yet
        NotAvailable,
        // Restaurant has accepted the order, freelencer can choose this delivery
        NotAsigned,
        // Food is ready, waiting for freelancer to pick it up
        WaitingForPickup,
        // Freelencer has picked up the food, on the way to the customer
        OnTheWay,
        // Delivery is finished
        Finished
    }
}
