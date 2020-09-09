using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Data.Migrations
{
    public partial class SeedSeatCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "CinemaHallID", "SeatNr" },
                values: new object[] { 89, 1, 89 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "ID",
                keyValue: 89);
        }
    }
}
