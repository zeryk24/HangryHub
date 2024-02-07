using HangryHub.MainService.Domain.ShoppingCartAggregate;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.Services
{
    public interface IShoppingCartCalculationService
    {
        /// <summary>
        /// helper method for calculating an order Subtotal (Quantity * Price) for all of the order items and coupons
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        decimal CalculateSubtotal(ShoppingCart shoppingCart);

        /// <summary>
        /// helper method for calculating an order item Subtotal (Quantity * Price)
        /// </summary>
        /// <param name="shoppingCartItem"></param>
        /// <returns></returns>
        decimal CalculateOrderItemSubtotal(ShoppingCartItem shoppingCartItem);
    }
}
