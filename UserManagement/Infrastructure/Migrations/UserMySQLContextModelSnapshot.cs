﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Infrastructure;

#nullable disable

namespace UserManagement.Infrastructure.Migrations
{
    [DbContext(typeof(UserMySQLContext))]
    partial class UserMySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("UserManagement.Domain.Support", b =>
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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SupportId");

                    b.HasIndex("UserId");

                    b.ToTable("Support");
                });

            modelBuilder.Entity("UserManagement.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
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
                            Address = "Logitech address",
                            Email = "Logitech@mail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "123456789"
                        },
                        new
                        {
                            UserId = 2,
                            Address = "Pokemon address",
                            Email = "Pokemon@mail.com",
                            FirstName = "Ash",
                            LastName = "Ketchum",
                            PhoneNumber = "987654321"
                        },
                        new
                        {
                            UserId = 3,
                            Address = "Red Bull Racing address",
                            Email = "Redbull@mail.com",
                            FirstName = "Max",
                            LastName = "Verstappen",
                            PhoneNumber = "192837465"
                        });
                });

            modelBuilder.Entity("UserManagement.Domain.Support", b =>
                {
                    b.HasOne("UserManagement.Domain.User", "User")
                        .WithMany("Supports")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserManagement.Domain.User", b =>
                {
                    b.Navigation("Supports");
                });
#pragma warning restore 612, 618
        }
    }
}
