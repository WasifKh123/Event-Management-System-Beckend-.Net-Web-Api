using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "man",
                table: "events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "man",
                table: "events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
