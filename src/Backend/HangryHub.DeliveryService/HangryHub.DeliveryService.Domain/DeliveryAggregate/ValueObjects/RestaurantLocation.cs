using HangryHub.DeliveryService.Domain.Common;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects
{
    public class RestaurantLocation : EntityValueObject
    {
        public string Address {  get; private set; }
        public string Description { get; private set; }


        public RestaurantLocation(string address, string description)
        {
            Address = address;
            Description = description;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is RestaurantLocation o)
            {
                return o.Address == Address && o.Description == Description;
            }
            return false;
        }

        public override int GetHashCode() => (Address, Description).GetHashCode();
    }
}
