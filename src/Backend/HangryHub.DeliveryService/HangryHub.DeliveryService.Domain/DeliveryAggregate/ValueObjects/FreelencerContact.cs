using HangryHub.DeliveryService.Domain.Common;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects
{
    public class FreelencerContact : EntityValueObject
    {
        public string VirtualPhone {  get; private set; }
        public string RealPhone { get; private set; }

        public FreelencerContact(string virtualPhone, string realPhone)
        {
            VirtualPhone = virtualPhone;
            RealPhone = realPhone;
        }


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is  FreelencerContact contact) {
                return contact.VirtualPhone == VirtualPhone && contact.RealPhone == RealPhone;
            }
            return false;
        }

        public override int GetHashCode() => (VirtualPhone, RealPhone).GetHashCode();

    }
}
