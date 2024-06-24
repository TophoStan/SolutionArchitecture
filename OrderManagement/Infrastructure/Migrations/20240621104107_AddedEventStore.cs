using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventData = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "AggregateId", "EventData", "EventTime", "EventType" },
                values: new object[,]
                {
                    { -2L, "4321", "{\"OrderNumber\":\"4321\",\"UserEmail\":\"thomas@mail.com\",\"OrderDate\":\"2024-06-21T12:41:06.7514524+02:00\",\"Status\":\"Done\"}", new DateTime(2024, 6, 21, 12, 41, 6, 751, DateTimeKind.Local).AddTicks(5720), "OrderCreated" },
                    { -1L, "1234", "{\"OrderNumber\":\"1234\",\"UserEmail\":\"stijn@mail.com\",\"OrderDate\":\"2024-06-21T12:41:06.7514476+02:00\",\"Status\":\"Processing\"}", new DateTime(2024, 6, 21, 12, 41, 6, 751, DateTimeKind.Local).AddTicks(5702), "OrderCreated" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "1234",
                column: "OrderDate",
                value: new DateTime(2024, 6, 21, 12, 41, 6, 751, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "4321",
                column: "OrderDate",
                value: new DateTime(2024, 6, 21, 12, 41, 6, 751, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.CreateIndex(
                name: "IX_Events_AggregateId",
                table: "Events",
                column: "AggregateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "1234",
                column: "OrderDate",
                value: new DateTime(2024, 6, 21, 10, 42, 39, 486, DateTimeKind.Local).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderNumber",
                keyValue: "4321",
                column: "OrderDate",
                value: new DateTime(2024, 6, 21, 10, 42, 39, 486, DateTimeKind.Local).AddTicks(4278));
        }
    }
}
