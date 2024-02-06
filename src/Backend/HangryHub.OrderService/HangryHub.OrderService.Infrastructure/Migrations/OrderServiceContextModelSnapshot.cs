﻿// <auto-generated />
using System;
using HangryHub.OrderService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HangryHub.OrderService.Infrastructure.Migrations
{
    [DbContext(typeof(OrderServiceContext))]
    partial class OrderServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coupon");
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity.ExtraIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderItemId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderItemId");

                    b.ToTable("ExtraIngredient");
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CouponId")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderState")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity.Coupon", b =>
                {
                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity.ValueObjects.CouponName", "Name", b1 =>
                        {
                            b1.Property<Guid>("CouponId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("CouponId");

                            b1.ToTable("Coupon");

                            b1.WithOwner()
                                .HasForeignKey("CouponId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity.ValueObjects.CouponPrice", "Price", b1 =>
                        {
                            b1.Property<Guid>("CouponId")
                                .HasColumnType("TEXT");

                            b1.Property<double>("EuroPrice")
                                .HasColumnType("REAL");

                            b1.HasKey("CouponId");

                            b1.ToTable("Coupon");

                            b1.WithOwner()
                                .HasForeignKey("CouponId");
                        });

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity.ExtraIngredient", b =>
                {
                    b.HasOne("HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.OrderItem", null)
                        .WithMany("ExtraIngredients")
                        .HasForeignKey("OrderItemId");

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity.ValueObjects.IngredientName", "Name", b1 =>
                        {
                            b1.Property<Guid>("ExtraIngredientId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ExtraIngredientId");

                            b1.ToTable("ExtraIngredient");

                            b1.WithOwner()
                                .HasForeignKey("ExtraIngredientId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.Entities.IngredientEntity.ValueObjects.IngredientQuantity", "Quantity", b1 =>
                        {
                            b1.Property<Guid>("ExtraIngredientId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Quantity")
                                .HasColumnType("INTEGER");

                            b1.HasKey("ExtraIngredientId");

                            b1.ToTable("ExtraIngredient");

                            b1.WithOwner()
                                .HasForeignKey("ExtraIngredientId");
                        });

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Quantity")
                        .IsRequired();
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.OrderItem", b =>
                {
                    b.HasOne("HangryHub.OrderService.Core.OrderAggregate.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemName", "Name", b1 =>
                        {
                            b1.Property<Guid>("OrderItemId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemPrice", "Price", b1 =>
                        {
                            b1.Property<Guid>("OrderItemId")
                                .HasColumnType("TEXT");

                            b1.Property<double>("Price")
                                .HasColumnType("REAL");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.ItemQuantity", "Quantity", b1 =>
                        {
                            b1.Property<Guid>("OrderItemId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Quantity")
                                .HasColumnType("INTEGER");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.ValueObjects.RestaurantItemId", "RestaurantItemId", b1 =>
                        {
                            b1.Property<Guid>("OrderItemId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("ItemId")
                                .HasColumnType("TEXT");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Quantity")
                        .IsRequired();

                    b.Navigation("RestaurantItemId")
                        .IsRequired();
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Order", b =>
                {
                    b.HasOne("HangryHub.OrderService.Core.OrderAggregate.Entities.CouponEntity.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponId");

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.ValueObjects.Price", "PriceEuro", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("TEXT");

                            b1.Property<double>("Euro")
                                .HasColumnType("REAL");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.ValueObjects.RestaurantId", "RestaurantId", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.ValueObjects.UserId", "UserId", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Coupon");

                    b.Navigation("PriceEuro")
                        .IsRequired();

                    b.Navigation("RestaurantId")
                        .IsRequired();

                    b.Navigation("UserId")
                        .IsRequired();
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Entities.OrderItemEntity.OrderItem", b =>
                {
                    b.Navigation("ExtraIngredients");
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
