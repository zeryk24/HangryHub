using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Select
{
    public class SelectDeliveryHandler : IRequestHandler<SelectDeliveryCommand, bool>
    {

        IRepository<Domain.DeliveryAggregate.Delivery> repository;
        public SelectDeliveryHandler(IRepository<Domain.DeliveryAggregate.Delivery> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(SelectDeliveryCommand request, CancellationToken cancellationToken)
        {
            // TODO: refactor to seperate service?

            var result = await repository.GetByIdAsync(request.DeliveryId);

            if (result == null) { return false; } // TODO: better handling
            if (result.Freelencer != null) { return false; } // someone already has the delivery
            if (result.State != DeliveryState.NotAsigned) { return false; }



            Freelencer freelencer = new Freelencer(
                new FreelencerId(request.FreelencerId),
                TransportType.Bike, // TODO: get this data differently
                new FreelencerContact("66", "66"));

            result = new Domain.DeliveryAggregate.Delivery(
                result.Id,
                result.Restaurant,
                result.Order,
                result.Customer,
                freelencer,
                DeliveryState.WaitingForPickup
            );
            repository.Update( result );

            repository.SaveChanges();

            return true;
        }
    }
}
