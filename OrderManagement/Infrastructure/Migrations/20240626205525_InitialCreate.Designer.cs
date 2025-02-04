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
    [Migration("20240626205525_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("OrderManagement.Domain.Order", b =>
                {
                    b.Property<string>("OrderNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderNumber");

                    b.HasIndex("OrderNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderNumber = "1",
                            OrderDate = new DateTime(2024, 6, 26, 22, 55, 24, 670, DateTimeKind.Local).AddTicks(6575),
                            Status = "Delivered",
                            SupplierName = "Logitech",
                            UserId = 1
                        },
                        new
                        {
                            OrderNumber = "2",
                            OrderDate = new DateTime(2024, 6, 26, 22, 55, 24, 670, DateTimeKind.Local).AddTicks(6617),
                            Status = "Processing",
                            SupplierName = "Pokemon",
                            UserId = 2
                        },
                        new
                        {
                            OrderNumber = "3",
                            OrderDate = new DateTime(2024, 6, 26, 22, 55, 24, 670, DateTimeKind.Local).AddTicks(6619),
                            Status = "Shipped",
                            SupplierName = "RedBull",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("OrderManagement.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = "Energy drink",
                            Price = 5f,
                            ProductDescription = "Energy drink with wodka",
                            ProductName = "Red Bull Wodka",
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 2,
                            Category = "Energy drink",
                            Price = 3f,
                            ProductDescription = "Energy drink with watermelon",
                            ProductName = "Red Bull Watermelon",
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 3,
                            Category = "Energy drink",
                            Price = 4f,
                            ProductDescription = "Energy drink with grapefruit",
                            ProductName = "Red Bull Grapefruit",
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 4,
                            Category = "Energy drink",
                            Price = 70f,
                            ProductDescription = "Wireless gaming mouse",
                            ProductName = "Logitech G603",
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 5,
                            Category = "Energy drink",
                            Price = 50f,
                            ProductDescription = "Wired gaming mouse",
                            ProductName = "Logitech G Pro",
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 6,
                            Category = "Energy drink",
                            Price = 40f,
                            ProductDescription = "Gaming keyboard",
                            ProductName = "Logitech G213",
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 7,
                            Category = "Energy drink",
                            Price = 100f,
                            ProductDescription = "Electric pokemon",
                            ProductName = "Pikachu",
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 8,
                            Category = "Energy drink",
                            Price = 200f,
                            ProductDescription = "Sleeping pokemon",
                            ProductName = "Snorlax",
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 9,
                            Category = "Energy drink",
                            Price = 150f,
                            ProductDescription = "Fire pokemon",
                            ProductName = "Charizard",
                            Quantity = 0
                        });
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

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("OrdersOrderNumber", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("OrderProduct");

                    b.HasData(
                        new
                        {
                            OrdersOrderNumber = "1",
                            ProductsProductId = 1
                        },
                        new
                        {
                            OrdersOrderNumber = "1",
                            ProductsProductId = 2
                        },
                        new
                        {
                            OrdersOrderNumber = "2",
                            ProductsProductId = 2
                        },
                        new
                        {
                            OrdersOrderNumber = "2",
                            ProductsProductId = 3
                        },
                        new
                        {
                            OrdersOrderNumber = "3",
                            ProductsProductId = 1
                        });
                });

            modelBuilder.Entity("OrderManagement.Domain.Order", b =>
                {
                    b.HasOne("OrderManagement.Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
