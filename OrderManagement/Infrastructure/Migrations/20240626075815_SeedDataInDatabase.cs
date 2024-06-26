using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderNumber", "OrderDate", "Status", "UserId" },
                values: new object[,]
                {
                    { "1", new DateTime(2024, 6, 26, 9, 58, 15, 345, DateTimeKind.Local).AddTicks(5446), "Delivered", 1 },
                    { "2", new DateTime(2024, 6, 26, 9, 58, 15, 345, DateTimeKind.Local).AddTicks(5497), "Processing", 2 },
                    { "3", new DateTime(2024, 6, 26, 9, 58, 15, 345, DateTimeKind.Local).AddTicks(5499), "Shipped", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { "1", 50f, "Mechanical Keyboard with RGB lighting", "Keyboard" },
                    { "2", 30f, "Gaming Mouse with 12 programmable buttons", "Mouse" },
                    { "3", 70f, "Wireless Headset with 7.1 Surround Sound", "Headset" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "3");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
