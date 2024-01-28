using HangryHub.DeliveryService.Domain.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects
{
    public class CustomerDeliveryLocation : EntityValueObject
    {
        public string Address { get; private set; }
        public string Note { get; private set; }

        public CustomerLocationType Type { get; private set; }


        public CustomerDeliveryLocation(string address, string description, CustomerLocationType type)
        {
            Address = address;
            Note = description;
            Type = type;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is CustomerDeliveryLocation o)
            {
                return o.Address == Address && o.Note == Note && Type == o.Type;
            }
            return false;
        }

        public override int GetHashCode() => (Address, Note,Type).GetHashCode();



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CustomerDeliveryLocation()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
