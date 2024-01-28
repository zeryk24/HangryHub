﻿// <auto-generated />
using System;
using HangryHub.DeliveryService.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HangryHub.DeliveryService.Infrastructure.Migrations
{
    [DbContext(typeof(DeliveryServiceContext))]
    partial class DeliveryServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HangryHub.DeliveryService.Domain.DeliveryAggregate.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.OrderId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("OrderId");
                });

            modelBuilder.Entity("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.RestaurantId", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RestaurantId");
                });

            modelBuilder.Entity("HangryHub.DeliveryService.Domain.DeliveryAggregate.Delivery", b =>
                {
                    b.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities.Customer", "Customer", b1 =>
                        {
                            b1.Property<Guid>("DeliveryId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");

                            b1.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.CustomerContact", "Contact", b2 =>
                                {
                                    b2.Property<Guid>("CustomerDeliveryId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("RealPhone")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("VirtualPhone")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("CustomerDeliveryId");

                                    b2.ToTable("Deliveries");

                                    b2.WithOwner()
                                        .HasForeignKey("CustomerDeliveryId");
                                });

                            b1.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.CustomerDeliveryLocation", "DeliveryLocation", b2 =>
                                {
                                    b2.Property<Guid>("CustomerDeliveryId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Address")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Note")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("Type")
                                        .HasColumnType("int");

                                    b2.HasKey("CustomerDeliveryId");

                                    b2.ToTable("Deliveries");

                                    b2.WithOwner()
                                        .HasForeignKey("CustomerDeliveryId");
                                });

                            b1.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.CustomerId", "Id", b2 =>
                                {
                                    b2.Property<Guid>("CustomerDeliveryId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("CustomerDeliveryId");

                                    b2.ToTable("Deliveries");

                                    b2.WithOwner()
                                        .HasForeignKey("CustomerDeliveryId");
                                });

                            b1.Navigation("Contact")
                                .IsRequired();

                            b1.Navigation("DeliveryLocation")
                                .IsRequired();

                            b1.Navigation("Id")
                                .IsRequired();
                        });

                    b.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities.Freelencer", "Freelencer", b1 =>
                        {
                            b1.Property<Guid>("DeliveryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("TransportType")
                                .HasColumnType("int");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");

                            b1.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.FreelencerContact", "Contact", b2 =>
                                {
                                    b2.Property<Guid>("FreelencerDeliveryId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("RealPhone")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("VirtualPhone")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("FreelencerDeliveryId");

                                    b2.ToTable("Deliveries");

                                    b2.WithOwner()
                                        .HasForeignKey("FreelencerDeliveryId");
                                });

                            b1.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.FreelencerId", "Id", b2 =>
                                {
                                    b2.Property<Guid>("FreelencerDeliveryId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("FreelencerDeliveryId");

                                    b2.ToTable("Deliveries");

                                    b2.WithOwner()
                                        .HasForeignKey("FreelencerDeliveryId");
                                });

                            b1.Navigation("Contact")
                                .IsRequired();

                            b1.Navigation("Id")
                                .IsRequired();
                        });

                    b.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities.Order", "Order", b1 =>
                        {
                            b1.Property<Guid>("DeliveryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id1")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("DeliveryId");

                            b1.HasIndex("Id1");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");

                            b1.HasOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.OrderId", "Id")
                                .WithMany()
                                .HasForeignKey("Id1")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Id");
                        });

                    b.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.Entities.Restaurant", "Restaurant", b1 =>
                        {
                            b1.Property<Guid>("DeliveryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id1")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("DeliveryId");

                            b1.HasIndex("Id1");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");

                            b1.HasOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.RestaurantId", "Id")
                                .WithMany()
                                .HasForeignKey("Id1")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.RestaurantContact", "Contact", b2 =>
                                {
                                    b2.Property<Guid>("RestaurantDeliveryId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("RealPhone")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("VirtualPhone")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("RestaurantDeliveryId");

                                    b2.ToTable("Deliveries");

                                    b2.WithOwner()
                                        .HasForeignKey("RestaurantDeliveryId");
                                });

                            b1.OwnsOne("HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects.RestaurantLocation", "Location", b2 =>
                                {
                                    b2.Property<Guid>("RestaurantDeliveryId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Address")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("RestaurantDeliveryId");

                                    b2.ToTable("Deliveries");

                                    b2.WithOwner()
                                        .HasForeignKey("RestaurantDeliveryId");
                                });

                            b1.Navigation("Contact")
                                .IsRequired();

                            b1.Navigation("Id");

                            b1.Navigation("Location")
                                .IsRequired();
                        });

                    b.Navigation("Customer")
                        .IsRequired();

                    b.Navigation("Freelencer")
                        .IsRequired();

                    b.Navigation("Order")
                        .IsRequired();

                    b.Navigation("Restaurant")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
