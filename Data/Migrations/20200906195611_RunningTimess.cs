using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Data.Migrations
{
    public partial class RunningTimess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunningTime_CinemaHalls_CinemaHallId",
                table: "RunningTime");

            migrationBuilder.DropForeignKey(
                name: "FK_RunningTime_Movies_MovieID",
                table: "RunningTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RunningTime",
                table: "RunningTime");

            migrationBuilder.RenameTable(
                name: "RunningTime",
                newName: "RunningTimes");

            migrationBuilder.RenameIndex(
                name: "IX_RunningTime_CinemaHallId",
                table: "RunningTimes",
                newName: "IX_RunningTimes_CinemaHallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RunningTimes",
                table: "RunningTimes",
                columns: new[] { "MovieID", "CinemaHallId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RunningTimes_CinemaHalls_CinemaHallId",
                table: "RunningTimes",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunningTimes_Movies_MovieID",
                table: "RunningTimes",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunningTimes_CinemaHalls_CinemaHallId",
                table: "RunningTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_RunningTimes_Movies_MovieID",
                table: "RunningTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RunningTimes",
                table: "RunningTimes");

            migrationBuilder.RenameTable(
                name: "RunningTimes",
                newName: "RunningTime");

            migrationBuilder.RenameIndex(
                name: "IX_RunningTimes_CinemaHallId",
                table: "RunningTime",
                newName: "IX_RunningTime_CinemaHallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RunningTime",
                table: "RunningTime",
                columns: new[] { "MovieID", "CinemaHallId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RunningTime_CinemaHalls_CinemaHallId",
                table: "RunningTime",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunningTime_Movies_MovieID",
                table: "RunningTime",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
