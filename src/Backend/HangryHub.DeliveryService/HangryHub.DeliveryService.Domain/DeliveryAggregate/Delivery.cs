using HangryHub.DeliveryService.Domain.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate
{
    public class Delivery : AggregateRoot
    {
        private Order order;
        private Customer customer;
        private object value;
        private DeliveryState notAsigned;

        public Restaurant Restaurant { get; private set; }
        public Order Order { get; private set; }
        public Customer Customer { get; private set; }
        public Freelencer? Freelencer { get; private set; }

        public DeliveryState State { get; private set; }


        public Delivery(Guid id, Restaurant restaurant, Order order, Customer customer, Freelencer? freelencer, DeliveryState state) : base(id)
        {
            Restaurant = restaurant;
            Order = order;
            Customer = customer;
            Freelencer = freelencer;
            State = state;


            // check invariants
            if (state == DeliveryState.NotAsigned && freelencer != null)
            {
                throw new System.Exception("Delivery cannot be in state NotAsigned and have a freelencer");
            }
            if (state == DeliveryState.OnTheWay || state == DeliveryState.WaitingForPickup || state == DeliveryState.Finished)
            {
                if (freelencer == null)
                {
                    throw new System.Exception("Delivery cannot be asigned without a freelancer.");
                }
            }
        }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Delivery() : base(Guid.Empty)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

    }
}
