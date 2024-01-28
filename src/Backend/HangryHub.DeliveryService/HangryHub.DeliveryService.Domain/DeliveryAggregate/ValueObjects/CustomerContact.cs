using HangryHub.DeliveryService.Domain.Common;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects
{
    public class CustomerContact : EntityValueObject
    {
        public string VirtualPhone { get; private set; }
        public string RealPhone { get; private set; }

        public CustomerContact(string virtualPhone, string realPhone)
        {
            VirtualPhone = virtualPhone;
            RealPhone = realPhone;
        }


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is CustomerContact o)
            {
                return o.VirtualPhone == VirtualPhone && o.RealPhone == RealPhone;
            }
            return false;
        }

        public override int GetHashCode() => (VirtualPhone, RealPhone).GetHashCode();



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CustomerContact()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
