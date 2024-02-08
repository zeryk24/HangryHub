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

            TypeAdapterConfig<AdditionalIngredient, SelectedAdditionalIngredient>.NewConfig()
                .ConstructUsing(src => new SelectedAdditionalIngredient(new(Guid.NewGuid())))
                .Map(dest => dest.AdditionalIngredientId, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Quantity, src => 1);

            TypeAdapterConfig<RestaurantItem, ShoppingCartItem>.NewConfig()
                .ConstructUsing(src => new ShoppingCartItem(new(Guid.NewGuid())))
                .Map(dest => dest.RestaurantItemId, src => src.Id)
                .Map(dest => dest.ItemName, src => src.Name)
                .Map(dest => dest.ItemDescription, src => src.Description)
                .Map(dest => dest.Price, src => src.Price + src.AdditionalIngredients.Sum(ai => ai.Price))
                .Map(dest => dest.Quantity, src => 1)
                .Map(dest => dest.SelectedAdditionalIngredients, src => src.AdditionalIngredients.Adapt<IEnumerable<SelectedAdditionalIngredient>>());
        }
    }
}
