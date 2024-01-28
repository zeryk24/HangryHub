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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Freelencer()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
