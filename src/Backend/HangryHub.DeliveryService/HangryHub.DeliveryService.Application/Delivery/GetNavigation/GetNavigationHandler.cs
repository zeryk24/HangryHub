using HangryHub.DeliveryService.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.GetNavigation
{
    public class GetNavigationHandler : IRequestHandler<GetNavigationQuery, NavigationData>
    {

        IRepository<Domain.DeliveryAggregate.Delivery> _deliveryRepository;
        public GetNavigationHandler(IRepository<Domain.DeliveryAggregate.Delivery> deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }
        public async Task<NavigationData> Handle(GetNavigationQuery request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(request.DeliveryID);

            if (delivery == null)
            {
                throw new Exception("Delivery not found");
            }

            return new NavigationData
            (
                delivery.Restaurant.Location.Address,
                delivery.Restaurant.Location.Description,
                delivery.Restaurant.Contact.VirtualPhone,
                delivery.Customer.DeliveryLocation.Address,
                delivery.Customer.DeliveryLocation.Note,
                delivery.Customer.Contact.VirtualPhone
            );
        }
    }
}
