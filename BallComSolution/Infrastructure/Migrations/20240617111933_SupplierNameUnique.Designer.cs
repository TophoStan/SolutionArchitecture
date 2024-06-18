﻿// <auto-generated />
using SupplierManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SupplierManagement.Infrastructure.Migrations
{
    [DbContext(typeof(SupplierMySQLContext))]
    [Migration("20240617111933_SupplierNameUnique")]
    partial class SupplierNameUnique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BallComSolution.Domain.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("SupplierId");

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.HasIndex("SupplierName")
                        .IsUnique();

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            Address = "Logitech address",
                            ContactEmail = "Logitech@mail.com",
                            ContactName = "John Doe",
                            ContactPhone = "123456789",
                            SupplierName = "Logitech BV."
                        },
                        new
                        {
                            SupplierId = 2,
                            Address = "Pokemon address",
                            ContactEmail = "Pokemon@mail.com",
                            ContactName = "Ash Ketchum",
                            ContactPhone = "987654321",
                            SupplierName = "Pokemon Inc."
                        },
                        new
                        {
                            SupplierId = 3,
                            Address = "Red Bull Racing address",
                            ContactEmail = "Redbull@mail.com",
                            ContactName = "Max Verstappen",
                            ContactPhone = "123456789",
                            SupplierName = "Red Bull Racing"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
