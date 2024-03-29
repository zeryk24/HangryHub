﻿// <auto-generated />
using System;
using HangryHub.RestaurantService.Infrastructure.Common.Persistance.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HangryHub.RestaurantService.Infrastructure.Migrations
{
    [DbContext(typeof(RestaurantServiceDbContext))]
    partial class RestaurantServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("HangryHub.RestaurantService.Domain.Restaurant.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("RestaurantId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Restaurants", (string)null);
                });

            modelBuilder.Entity("HangryHub.RestaurantService.Domain.Restaurant.Restaurant", b =>
                {
                    b.OwnsMany("HangryHub.RestaurantService.Domain.Restaurant.Entities.MenuItemEntity.MenuItem", "MenuItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT")
                                .HasColumnName("MenuItemId");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Price")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("RestaurantId")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("RestaurantId");

                            b1.ToTable("MenuItems", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RestaurantId");

                            b1.OwnsMany("HangryHub.RestaurantService.Domain.Restaurant.Entities.IngredientEntity.Ingredient", "Ingredients", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("TEXT")
                                        .HasColumnName("IngredientId");

                                    b2.Property<Guid>("MenuItemId")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.Property<float>("Weight")
                                        .HasColumnType("REAL");

                                    b2.HasKey("Id");

                                    b2.HasIndex("MenuItemId");

                                    b2.ToTable("Ingredients", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MenuItemId");
                                });

                            b1.Navigation("Ingredients");
                        });

                    b.Navigation("MenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}
