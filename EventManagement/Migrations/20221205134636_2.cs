using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ticketNumber",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "ticketType",
                table: "bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
