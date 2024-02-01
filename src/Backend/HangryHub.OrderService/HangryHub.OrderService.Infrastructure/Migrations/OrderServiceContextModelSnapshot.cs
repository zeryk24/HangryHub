﻿// <auto-generated />
using System;
using HangryHub.OrderService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HangryHub.OrderService.Core.OrderAggregate.Order", b =>
                {
                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.ValueObjects.Accept", "OrderAccepted", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("Date")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsAccepted")
                                .HasColumnType("bit");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.ValueObjects.Decline", "OrderDeclined", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("Date")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsDeclined")
                                .HasColumnType("bit");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.ValueObjects.Price", "PriceEuro", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Euro")
                                .HasColumnType("float");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("HangryHub.OrderService.Core.OrderAggregate.ValueObjects.Ready", "OrderReady", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("Date")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsReady")
                                .HasColumnType("bit");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("OrderAccepted")
                        .IsRequired();

                    b.Navigation("OrderDeclined")
                        .IsRequired();

                    b.Navigation("OrderReady")
                        .IsRequired();

                    b.Navigation("PriceEuro")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
