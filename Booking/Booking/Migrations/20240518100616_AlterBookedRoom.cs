using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Migrations
{
    /// <inheritdoc />
    public partial class AlterBookedRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_BookedRooms_RoomId_UserId_StartDate",
                table: "BookedRooms");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "BookedRooms");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "BookedRooms",
                newName: "BookedDate");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_BookedRooms_RoomId_UserId_BookedDate",
                table: "BookedRooms",
                columns: new[] { "RoomId", "UserId", "BookedDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_BookedRooms_RoomId_UserId_BookedDate",
                table: "BookedRooms");

            migrationBuilder.RenameColumn(
                name: "BookedDate",
                table: "BookedRooms",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "BookedRooms",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_BookedRooms_RoomId_UserId_StartDate",
                table: "BookedRooms",
                columns: new[] { "RoomId", "UserId", "StartDate" });
        }
    }
}
