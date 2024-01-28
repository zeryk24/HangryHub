using HangryHub.DeliveryService.Application.Common;
using MediatR;
using HangryHub.DeliveryService.Domain.DeliveryAggregate;
namespace HangryHub.DeliveryService.Application.Delivery.Get
{
    public class GetDeliveryHandler : IRequestHandler<GetDeliveryQuery, DeliveryDTO>
    {
        IRepository<Domain.DeliveryAggregate.Delivery> repository;
        public GetDeliveryHandler(IRepository<Domain.DeliveryAggregate.Delivery> repository)
        {
            this.repository = repository;
        }
        public async Task<DeliveryDTO> Handle(GetDeliveryQuery request, CancellationToken cancellationToken)
        {
            var delivery = await repository.GetByIdAsync(request.DeliveryId);

            DeliveryDTO deliveryDTO = new DeliveryDTO();

            return deliveryDTO;
        }
    }
}
