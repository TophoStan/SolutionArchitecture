using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "John", "Doe", "123456789" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Ash", "Ketchum", "987654321" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Max", "Verstappen", "192837465" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "John Doe", "123456789", "Logitech BV." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Ash Ketchum", "987654321", "Pokemon Inc." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Max Verstappen", "123456789", "Red Bull Racing" });
        }
    }
}
