using HangryHub.DeliveryService.Application.Delivery.Commands.UpdateOrderState;
using HangryHub.DeliveryService.Domain.DeliveryAggregate.Enums;
using HangryHub.DeliveryService.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace HangryHub.DeliveryService.Infrastructure.Delivery.Services
{


    public class OrderStateUpdateService : IOrderStateUpdateService
    {
        DeliveryServiceContext _context;

        public OrderStateUpdateService(DeliveryServiceContext context)
        {
            _context = context;
        }

        public Task<Guid> FindDeliveryWithOrder(Guid orderId)
        {
            return _context.Deliveries
                .Where(d => d.Order.Id.Id == orderId)
                .Select(d => d.Id)
                .FirstOrDefaultAsync();
        }

        public Task MakeDeliveryAvaiable(Guid deliveryId)
        {
            var delivery = _context.Deliveries.Find(deliveryId);
            if (delivery == null)
            {
                throw new ArgumentException("Delivery not found");
            }
            var new_order = new Domain.DeliveryAggregate.Entities.Order(
                delivery.Order.Id,
                OrderState.Accepted
            );
            var new_delivery = new Domain.DeliveryAggregate.Delivery(
                delivery.Id,
                delivery.Restaurant,
                new_order,
                delivery.Customer,
                null, // no freelancer yet
                DeliveryState.NotAsigned
            );
            _context.Deliveries.Update(new_delivery);
            return _context.SaveChangesAsync();
        }
    }
}
