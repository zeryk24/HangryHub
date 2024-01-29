using HangryHub.RestaurantService.Domain.Restaurant;
using HangryHub.RestaurantService.Domain.Restaurant.Entities.IngredientEntity.ValueObjects;
using HangryHub.RestaurantService.Domain.Restaurant.Entities.MenuItemEntity.ValueObjects;
using HangryHub.RestaurantService.Domain.Restaurant.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HangryHub.RestaurantService.Infrastructure.Persistance.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    private const string _restaurantsTableName = "Restaurants";
    private const string _restaurantPrimaryKey = "RestaurantId";

    private const string _menuItemsTableName = "MenuItems";
    private const string _menuItemPrimaryKey = "MenuItemId";

    private const string _ingredientsTableName = "Ingredients";
    private const string _ingredientsPrimaryKey = "IngredientId";


    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        ConfigureRestaurantsTable(builder);
        ConfigureMenuItemsTable(builder);
        ConfigureIngredientsTable(builder);
    }

    private void ConfigureRestaurantsTable(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable(_restaurantsTableName);

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName(_restaurantPrimaryKey)
            .ValueGeneratedNever()
            .HasConversion(
                restaurantId => restaurantId.Value,
                restaurantValue => RestaurantId.Create(restaurantValue)
            );

        builder.Property(r => r.Name)
            .HasConversion(
                name => name.Value,
                value => RestaurantName.Create(value)
             );

        builder.Property(r => r.Description)
            .HasConversion(
                description => description.Value,
                value => RestaurantDescription.Create(value)
             );
    }

    private void ConfigureMenuItemsTable(EntityTypeBuilder<Restaurant> builder)
    {
        builder.OwnsMany(r => r.MenuItems, mib =>
        {
            mib.ToTable(_menuItemsTableName);

            mib.HasKey(mi => mi.Id);

            mib.Property(mi => mi.Id)
                .HasColumnName(_menuItemPrimaryKey)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuItemId.Create(value)
                );

            mib.WithOwner().HasForeignKey(_restaurantPrimaryKey);

            mib.Property(mi => mi.Name)
                .HasConversion(
                name => name.Value,
                value => MenuItemName.Create(value)
            );

            mib.Property(mi => mi.Description)
                .HasConversion(
                description => description.Value,
                value => MenuItemDescription.Create(value)
            );

            mib.Property(mi => mi.Price)
                .HasConversion(
                price => price.Czk,
                czk => MenuItemPrice.Create(czk)
            );
        });
    }

    private void ConfigureIngredientsTable(EntityTypeBuilder<Restaurant> builder)
    {
        builder.OwnsMany(r => r.MenuItems, mib => mib.OwnsMany(mi => mi.Ingredients, ib =>
        {
            ib.ToTable(_ingredientsTableName);

            ib.HasKey(i => i.Id);

            ib.Property(i => i.Id)
                .HasColumnName(_ingredientsPrimaryKey)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => IngredientId.Create(value)
            );

            ib.Property(i => i.Name)
                .HasConversion(
                name => name.Value,
                value => IngredientName.Create(value)
            );

            ib.Property(i => i.Weight)
                .HasConversion(
                weight => weight.Grams,
                grams => IngredientWeight.Create(grams)
            );

        }));
    }

}
