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


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private RestaurantLocation()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
