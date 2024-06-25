﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupportManagement.Infrastructure;

#nullable disable

namespace SupportManagement.Infrastructure.Migrations
{
    [DbContext(typeof(SupportMySQLContext))]
    partial class SupportMySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SupportManagement.Domain.Support", b =>
                {
                    b.Property<int>("SupportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SupportId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SupportTicketNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SupportId");

                    b.HasIndex("SupportId")
                        .IsUnique();

                    b.ToTable("Supports");

                    b.HasData(
                        new
                        {
                            SupportId = 1,
                            Description = "Unable to login to the account.",
                            IssueDate = new DateTime(2024, 6, 25, 14, 35, 40, 861, DateTimeKind.Local).AddTicks(208),
                            Status = "Open",
                            SupportTicketNumber = "ST-1001",
                            UserEmail = "user1@example.com",
                            UserId = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
