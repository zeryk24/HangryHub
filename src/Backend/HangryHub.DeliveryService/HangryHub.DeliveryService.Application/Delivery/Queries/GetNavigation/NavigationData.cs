using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Application.Delivery.Queries.GetNavigation
{
    public record NavigationData(
        string RestaurantAddress,
        string RestaurantInfo,
        string RestaurantVirtualPhone,
        string DeliveryAddress,
        string DeliveryInfo,
        string DeliveryVirtualPhone)
    {
    }
}
