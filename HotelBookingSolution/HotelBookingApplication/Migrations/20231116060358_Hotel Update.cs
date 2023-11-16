using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingApplication.Migrations
{
    public partial class HotelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableRooms",
                table: "Rooms",
                newName: "TotalRooms");

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "TotalRooms",
                table: "Rooms",
                newName: "AvailableRooms");
        }
    }
}
