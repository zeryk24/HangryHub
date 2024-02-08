using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.Complete
{
    public class CreateFromOrderHandler : IRequestHandler<CreateFromOrderCommand>
    {

        IRepository<Domain.DeliveryAggregate.Delivery> deliveryRepository;
        IRepository<Domain.RestaurantAggregate.Restaurant> restaurantRepository { get; }
        public CreateFromOrderHandler(
            IRepository<Domain.DeliveryAggregate.Delivery> deliveryRepository, 
            IRepository<Domain.RestaurantAggregate.Restaurant> restaurantRepository)
        {
            this.deliveryRepository = deliveryRepository;
            this.restaurantRepository = restaurantRepository;
        }

        public async Task Handle(CreateFromOrderCommand request, CancellationToken cancellationToken)
        {
            var order_m = request.Message;

            Domain.RestaurantAggregate.Restaurant? restaurant = await restaurantRepository.GetByIdAsync(order_m.RestaurantId);

            string restaurantName = restaurant == null ? "Unknown" : restaurant.Name;

            var delivery = new Domain.DeliveryAggregate.Delivery(
                Guid.NewGuid(), 
                new RestaurantDeliveryInfo(
                    new RestaurantId(order_m.RestaurantId),
                    new RestaurantContact(order_m.RestaurantData.Contact,"" ),
                    new RestaurantLocation(order_m.RestaurantData.Address, order_m.RestaurantData.Note),
                    restaurantName
                ),
                new Order(new OrderId(order_m.OrderId), OrderState.JustCreated),
                new Customer(
                        new CustomerId(order_m.UserId),
                        new CustomerContact(order_m.DeliveryData.UserContact,""),
                        new CustomerDeliveryLocation(order_m.DeliveryData.DeliveryLocation, order_m.DeliveryData.Note,CustomerLocationType.Home)
                    ),
                null,
                DeliveryState.NotAvailable            
            );
            deliveryRepository.Insert(delivery);
            deliveryRepository.SaveChanges();
            
        }
    }
}
