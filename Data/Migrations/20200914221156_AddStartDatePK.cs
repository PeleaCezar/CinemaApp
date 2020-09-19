using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Data.Migrations
{
    public partial class AddStartDatePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RunningTimes",
                table: "RunningTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RunningTimes",
                table: "RunningTimes",
                columns: new[] { "MovieID", "CinemaHallId", "StartDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RunningTimes",
                table: "RunningTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RunningTimes",
                table: "RunningTimes",
                columns: new[] { "MovieID", "CinemaHallId" });
        }
    }
}
