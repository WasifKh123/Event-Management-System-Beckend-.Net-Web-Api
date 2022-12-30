using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "events");

            migrationBuilder.AddColumn<string>(
                name: "ticketNumber",
                table: "bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ticketType",
                table: "bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ticketNumber",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "ticketType",
                table: "bookings");

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "events",
                type: "int",
                nullable: true);
        }
    }
}
