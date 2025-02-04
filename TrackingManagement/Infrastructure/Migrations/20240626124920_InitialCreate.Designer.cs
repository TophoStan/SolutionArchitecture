﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackingManagement.Infrastructure;

#nullable disable

namespace TrackingManagement.Infrastructure.Migrations
{
    [DbContext(typeof(TrackingMySQLContext))]
    [Migration("20240626124920_InitialCreate")]
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

            modelBuilder.Entity("TrackingManagement.Domain.TrackingData", b =>
                {
                    b.Property<int>("TrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TrackingId"));

                    b.Property<string>("Carrier")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EstimatedDelivery")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("TrackingId");

                    b.HasIndex("TrackingId")
                        .IsUnique();

                    b.ToTable("Trackings");
                });
#pragma warning restore 612, 618
        }
    }
}
