using HangryHub.MainService.Application.Restaurant.DTOs.RestaurantAggregate;
using HangryHub.MainService.Application.Restaurant.DTOs.ShoppingCartAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using HangryHub.MainService.Domain.ShoppingCartAggregate.Entities;
using HangryHub.MainService.Domain.ShoppingCartAggregate;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.MapsterMappingConfigs
{
    public static class ShoppingCartMapperConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<ShoppingCart, ShoppingCartDto>.NewConfig();
            TypeAdapterConfig<DeliveryData, DeliveryDataDto>.NewConfig();
            TypeAdapterConfig<ShoppingCartItem, ShoppingCartItemDto>.NewConfig();
            TypeAdapterConfig<SelectedAdditionalIngredient, SelectedAdditionalIngredientDto>.NewConfig();

            // Reverse mappings
            TypeAdapterConfig<ShoppingCartDto, ShoppingCart>.NewConfig();
            TypeAdapterConfig<DeliveryDataDto, DeliveryData>.NewConfig();
            TypeAdapterConfig<ShoppingCartItemDto, ShoppingCartItem>.NewConfig();
            TypeAdapterConfig<SelectedAdditionalIngredientDto, SelectedAdditionalIngredient>.NewConfig();

        }
    }
}
