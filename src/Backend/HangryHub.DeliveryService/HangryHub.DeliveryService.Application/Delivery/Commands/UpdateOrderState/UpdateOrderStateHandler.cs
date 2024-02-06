using HangryHub.DeliveryService.Application.Common;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;
using MediatR;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.Complete
{
    public class UpdateOrderStateHandler : IRequestHandler<UpdateOrderStateCommand, bool>
    {

        IRepository<Domain.DeliveryAggregate.Delivery> repository;
        public UpdateOrderStateHandler(IRepository<Domain.DeliveryAggregate.Delivery> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(UpdateOrderStateCommand request, CancellationToken cancellationToken)
        {
            

            return true;
        }
    }
}
