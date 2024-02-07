using HangryHub.MainService.Application.Repository;
using HangryHub.MainService.Application.Services;
using HangryHub.MainService.Contracts.Messages;
using HangryHub.MainService.Contracts.Messages.MessageParts;
using HangryHub.MainService.Domain.RestaurantAggregate.ValueObjects;
using HangryHub.MainService.Domain.ShoppingCartAggregate;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Order.Producers.CreateOrder
{
    public class CreateOrderProducer : IRequestHandler<CreateOrderCommand>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IShoppingCartAggregateRepository _shoppingCartAggregateRepository;
        private readonly IRestaurantAggregateRepository _restaurantAggregateRepository;
        private readonly IShoppingCartCalculationService _shoppingCartCalculationService;

        public CreateOrderProducer(IPublishEndpoint publishEndpoint, IShoppingCartAggregateRepository shoppingCartAggregateRepository, IRestaurantAggregateRepository restaurantAggregateRepository, IShoppingCartCalculationService shoppingCartCalculationService)
        {
            _publishEndpoint = publishEndpoint;
            _shoppingCartAggregateRepository = shoppingCartAggregateRepository;
            _restaurantAggregateRepository = restaurantAggregateRepository;
            _shoppingCartCalculationService = shoppingCartCalculationService;
        }

        // We are ommiting using mapster here to ensure that the messages are correctly sent, 
        // especially if they are as critical as orders.
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartId = new ShoppingCartId(request.ShoppingCartId);

            var shoppingCart = await _shoppingCartAggregateRepository.GetWithDetailsAsync(shoppingCartId);
            ValidateShoppingCart(shoppingCart);

            var restaurant = await _restaurantAggregateRepository.GetWithDetailsAsync(shoppingCart.RestaurantId);
            ValidateRestaurant(restaurant);

            var deliveryData = MapDeliveryData(shoppingCart);
            var restaurantData = MapRestaurantData(restaurant);
            var orderItems = MapOrderItems(shoppingCart);

            var subtotal = _shoppingCartCalculationService.CalculateSubtotal(shoppingCart);

            await _publishEndpoint.Publish(new OrderMessage()
            {
                UserId = shoppingCart.CustomerId.Value,
                RestaurantId = shoppingCart.RestaurantId.Value,
                RestaurantData = restaurantData,
                DeliveryData = deliveryData,
                Items = orderItems,
                // TODO
                Coupons = new(),
                Subtotal = subtotal,
            });
        }

        private DeliveryDataMessage MapDeliveryData(ShoppingCart shoppingCart)
        {
            return new DeliveryDataMessage()
            {
                DeliveryLocation = shoppingCart.SelectedDeliveryData.DeliveryLocation,
                Note = shoppingCart.SelectedDeliveryData.Note,
                UserContact = shoppingCart.SelectedDeliveryData.Contact,
            };
        }

        private RestaurantDataMessage MapRestaurantData(Domain.RestaurantAggregate.Restaurant restaurant)
        {
            return new RestaurantDataMessage()
            {
                Address = restaurant.Detail.Address,
                Note = restaurant.Detail.Note,
                Contact = restaurant.Detail.Contact,
            };
        }

        private List<OrderItemMessage> MapOrderItems(ShoppingCart shoppingCart)
        {
            var orderItems = new List<OrderItemMessage>();

            foreach (var item in shoppingCart.Items)
            {
                if (item.Price == 0)
                {
                    throw new ArgumentException($"The ShoppingCartItem price should not be a 0 (item.Id.Value: {item.Id.Value})");
                }

                var additionalItems = item.SelectedAdditionalIngredients
                    .Select(a => new AdditionalIngredientMessage()
                    {
                        AdditionalIngredientId = a.AdditionalIngredientId.Value,
                        Name = a.Name,
                        Quantity = a.Quantity,
                    })
                    .ToList();

                orderItems.Add(new OrderItemMessage()
                {
                    RestaurantItemId = item.RestaurantItemId.Value,
                    Name = item.ItemName,
                    Description = item.ItemDescription,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    AdditionalIngredients = additionalItems,
                });
            }

            return orderItems;
        }

        // not fan of this, but it works .-.

        private static void ValidateShoppingCart(ShoppingCart? shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentException("Shopping Cart was not found");
            }

            if (shoppingCart.SelectedDeliveryDataId == null || shoppingCart.SelectedDeliveryData == null)
            {
                throw new ArgumentException("Delivery Data are not valid");
            }

            if (!shoppingCart.Items.Any())
            {
                throw new ArgumentException("Shopping Cart is empty");
            }
        }

        private static void ValidateRestaurant(Domain.RestaurantAggregate.Restaurant? restaurant)
        {
            if (restaurant == null)
            {
                throw new ArgumentException("Shopping Cart was not found");
            }
        }
    }
}
