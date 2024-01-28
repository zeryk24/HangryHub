using HangryHub.DeliveryService.Domain.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities
{
    public class Freelencer : Entity
    {
        public FreelencerId Id { get; private set; }
        public TransportType TransportType { get; private set; }

        public FreelencerContact Contact { get; private set; }


        public Freelencer(FreelencerId id, TransportType transportType, FreelencerContact contact)
        {
            Id = id;
            TransportType = transportType;
            Contact = contact;
        }
    }
}
