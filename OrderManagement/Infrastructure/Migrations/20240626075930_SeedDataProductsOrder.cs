using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProductsOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrdersOrderNumber", "ProductsProductId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "1", "2" },
                    { "2", "2" },
                    { "2", "3" },
                    { "3", "1" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "1",
                column: "OrderDate",
                value: new DateTime(2024, 6, 26, 9, 59, 30, 539, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "2",
                column: "OrderDate",
                value: new DateTime(2024, 6, 26, 9, 59, 30, 539, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "3",
                column: "OrderDate",
                value: new DateTime(2024, 6, 26, 9, 59, 30, 539, DateTimeKind.Local).AddTicks(4663));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersOrderNumber", "ProductsProductId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersOrderNumber", "ProductsProductId" },
                keyValues: new object[] { "1", "2" });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersOrderNumber", "ProductsProductId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersOrderNumber", "ProductsProductId" },
                keyValues: new object[] { "2", "3" });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersOrderNumber", "ProductsProductId" },
                keyValues: new object[] { "3", "1" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "1",
                column: "OrderDate",
                value: new DateTime(2024, 6, 26, 9, 58, 15, 345, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "2",
                column: "OrderDate",
                value: new DateTime(2024, 6, 26, 9, 58, 15, 345, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "3",
                column: "OrderDate",
                value: new DateTime(2024, 6, 26, 9, 58, 15, 345, DateTimeKind.Local).AddTicks(5499));
        }
    }
}
