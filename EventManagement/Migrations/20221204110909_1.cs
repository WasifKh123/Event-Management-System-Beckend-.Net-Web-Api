using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organzationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    registrationEndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.eventId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    bookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticketNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eventID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.bookingId);
                    table.UniqueConstraint("AK_bookings_userID_eventID", x => new { x.userID, x.eventID });
                    table.ForeignKey(
                        name: "FK_bookings_events_eventID",
                        column: x => x.eventID,
                        principalTable: "events",
                        principalColumn: "eventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_eventID",
                table: "bookings",
                column: "eventID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
