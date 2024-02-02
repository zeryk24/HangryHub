﻿using HangryHub.DeliveryService.Domain.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;

namespace HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities
{
    public class Restaurant : Entity
    {
        public RestaurantId Id { get; private set; }
        public RestaurantContact Contact { get; private set; }
        public RestaurantLocation Location { get; private set; }

        public Restaurant(RestaurantId id, RestaurantContact contact, RestaurantLocation location)
        {
            Id = id;
            Contact = contact;
            Location = location;
        }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Restaurant()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}