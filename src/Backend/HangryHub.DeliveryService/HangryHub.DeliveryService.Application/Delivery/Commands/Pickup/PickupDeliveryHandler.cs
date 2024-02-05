using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.Pickup
{
    public class PickupDeliveryHandler : IRequestHandler<PickupDeliveryCommand, bool>
    {

        IRepository<Domain.DeliveryAggregate.Delivery> repository;
        public PickupDeliveryHandler(IRepository<Domain.DeliveryAggregate.Delivery> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(PickupDeliveryCommand request, CancellationToken cancellationToken)
        {
            // TODO: refactor to seperate service?

            var result = await repository.GetByIdAsync(request.DeliveryId);

            // TODO: better error handling, exceptions?
            if (result == null) { return false; }



            result = new Domain.DeliveryAggregate.Delivery(
                result.Id,
                result.Restaurant,
                result.Order,
                result.Customer,
                result.Freelencer,
                DeliveryState.OnTheWay
            );
            repository.Update(result);

            repository.SaveChanges();

            return true;
        }
    }
}
