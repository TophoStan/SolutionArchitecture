﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.Infrastructure.Order;

#nullable disable

namespace OrderManagement.Infrastructure.Migrations
{
    [DbContext(typeof(OrderMySQLContext))]
    [Migration("20240626074140_AddedSeedData")]
    partial class AddedSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("OrderManagement.Domain.Events.OrderEvent", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("EventId"));

                    b.Property<string>("AggregateId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EventData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EventId");

                    b.HasIndex("AggregateId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("OrderManagement.Domain.Order", b =>
                {
                    b.Property<string>("OrderNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderNumber");

                    b.HasIndex("OrderNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderManagement.Domain.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OrderManagement.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "Logitech@mail.com",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "Pokemon@mail.com",
                            FirstName = "Ash",
                            LastName = "Ketchum"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "Redbull@mail.com",
                            FirstName = "Max",
                            LastName = "Verstappen"
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<string>("OrdersOrderNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductsProductId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("OrdersOrderNumber", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("OrderManagement.Domain.Order", b =>
                {
                    b.HasOne("OrderManagement.Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("OrderManagement.Domain.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderManagement.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderManagement.Domain.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
