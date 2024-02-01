﻿using HangryHub.OrderService.Core.Common;
using HangryHub.OrderService.Core.OrderAggregate.ValueObjects;

namespace HangryHub.OrderService.Core.OrderAggregate
{
    public class Order : AggregateRoot<Guid>
    {
        public Price PriceEuro { get; private set; }
        public Accept OrderAccepted { get; private set; }

        public Order(Price euro, Accept orderAccepted)
        {
            PriceEuro = euro;
            OrderAccepted = orderAccepted;
        }

        private Order() { }

        public void AcceptOrder()
        {
            OrderAccepted.AcceptOrder();
        }
    }
}
