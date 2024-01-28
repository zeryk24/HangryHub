using HangryHub.DeliveryService.Domain.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate
{
    public class Delivery : AggregateRoot
    {
        public Restaurant Restaurant { get; private set; }
        public Order Order { get; private set; }
        public Customer Customer { get; private set; }
        public Freelencer Freelencer { get; private set; }

        public DeliveryState State { get; private set; }


        public Delivery(Guid id, Restaurant restaurant, Order order, Customer customer, Freelencer freelencer, DeliveryState state) : base(id)
        {
            Restaurant = restaurant;
            Order = order;
            Customer = customer;
            Freelencer = freelencer;
            State = state;
        }
    }
}
