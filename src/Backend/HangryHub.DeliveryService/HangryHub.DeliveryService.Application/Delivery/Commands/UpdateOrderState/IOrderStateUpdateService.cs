using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.Commands.UpdateOrderState
{
    public interface IOrderStateUpdateService
    {
        Task<Guid> FindDeliveryWithOrder(Guid orderId);
        Task MakeDeliveryAvaiable(Guid deliveryId);
    }
}
