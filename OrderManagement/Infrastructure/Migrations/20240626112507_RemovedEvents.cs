using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "1",
                columns: new[] { "OrderDate", "SupplierName" },
                values: new object[] { new DateTime(2024, 6, 26, 13, 25, 6, 975, DateTimeKind.Local).AddTicks(2842), "Logitech" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "2",
                columns: new[] { "OrderDate", "SupplierName" },
                values: new object[] { new DateTime(2024, 6, 26, 13, 25, 6, 975, DateTimeKind.Local).AddTicks(2891), "Pokemon" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "3",
                columns: new[] { "OrderDate", "SupplierName" },
                values: new object[] { new DateTime(2024, 6, 26, 13, 25, 6, 975, DateTimeKind.Local).AddTicks(2893), "RedBull" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventData = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EventType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Events_AggregateId",
                table: "Events",
                column: "AggregateId");
        }
    }
}
