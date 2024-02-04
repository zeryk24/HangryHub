using HangryHub.MainService.Application.Restaurant.DTOs.RestaurantAggregate;
using HangryHub.MainService.Domain.RestaurantAggregate.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.MainService.Application.MapsterMappingConfigs
{
    public static class RestaurantMapperConfig
    {
        public static void RegisterMappings()
        {
            MappingForRestaurantAndRestaurantDTO();
            MappingForRestaurantItemAndRestaurantItemDTO();

            // IngredientDto to Ingredient
            TypeAdapterConfig<IngredientDto, Ingredient>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            // Ingredient to IngredientDto
            TypeAdapterConfig<Ingredient, IngredientDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            // AdditionalIngredientDto to AdditionalIngredient
            TypeAdapterConfig<AdditionalIngredientDto, AdditionalIngredient>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Price, src => src.Price);

            // AdditionalIngredient to AdditionalIngredientDto
            TypeAdapterConfig<AdditionalIngredient, AdditionalIngredientDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Price, src => src.Price);
        }

        private static void MappingForRestaurantAndRestaurantDTO()
        {
            // Map from RestaurantDto to Restaurant
            TypeAdapterConfig<RestaurantDto, Domain.RestaurantAggregate.Restaurant>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Detail, src => new RestaurantDetail
                {
                    Address = src.Detail.Address,
                    Contact = src.Detail.Contact,
                    Note = src.Detail.Note
                })
                .Map(dest => dest.Items, src => src.Items.Adapt<IEnumerable<RestaurantItem>>());

            // Restaurant to RestaurantDto
            TypeAdapterConfig<Domain.RestaurantAggregate.Restaurant, RestaurantDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Detail, src => new RestaurantDetailDto
                {
                    Address = src.Detail.Address,
                    Contact = src.Detail.Contact,
                    Note = src.Detail.Note
                })
                .Map(dest => dest.Items, src => src.Items.Adapt<List<RestaurantItemDto>>());
        }

        private static void MappingForRestaurantItemAndRestaurantItemDTO()
        {
            // Map from RestaurantItemDto to RestaurantItem
            TypeAdapterConfig<RestaurantItemDto, RestaurantItem>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Ingredients, src => src.Ingredients.Adapt<IEnumerable<Ingredient>>())
                .Map(dest => dest.AdditionalIngredients, src => src.AdditionalIngredients.Adapt<IEnumerable<AdditionalIngredient>>());

            // RestaurantItem to RestaurantItemDto
            TypeAdapterConfig<RestaurantItem, RestaurantItemDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Ingredients, src => src.Ingredients.Adapt<List<IngredientDto>>())
                .Map(dest => dest.AdditionalIngredients, src => src.AdditionalIngredients.Adapt<List<AdditionalIngredientDto>>());
        }
    }
}
