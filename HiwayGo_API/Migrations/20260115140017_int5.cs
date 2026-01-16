using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiwayGo_API.Migrations
{
    /// <inheritdoc />
    public partial class int5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoOfSeats",
                table: "BusBookings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfSeats",
                table: "BusBookings");
        }
    }
}
