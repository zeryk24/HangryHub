using HangryHub.MainService.Application.Services;
using HangryHub.MainService.Domain.ShoppingCartAggregate;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using HangryHub.MainService.Domain.ShoppingCartAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Infrastructure.Services
{
    public class ShoppingCartCalculationService : IShoppingCartCalculationService
    {
        public decimal CalculateSubtotal(ShoppingCart shoppingCart)
        {
            decimal total = 0;

            // Linq is not needed, for perf it is better to do a forloop ;) [even tho I love linq]
            // if you are reading this, I have to commend you for being an awesome person ;)
            foreach (var shoppingCartItem in shoppingCart.Items)
            {
                total += CalculateOrderItemSubtotal(shoppingCartItem);
            }

            return total;
        }

        public decimal CalculateOrderItemSubtotal(ShoppingCartItem shoppingCartItem)
        {
            var itemPrice = shoppingCartItem.Price * shoppingCartItem.Quantity;

            foreach (var additionalIngredient in shoppingCartItem.SelectedAdditionalIngredients)
            {
                var ingredientPrice = additionalIngredient.Quantity * additionalIngredient.Price;
                itemPrice += ingredientPrice;
            }

            return itemPrice;
        }
    }
}
