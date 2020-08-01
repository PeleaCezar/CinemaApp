using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Data.Migrations
{
    public partial class MovieReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MovieID",
                table: "Reservations",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Movies_MovieID",
                table: "Reservations",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Movies_MovieID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MovieID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Reservations");
        }
    }
}
