using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Data.Migrations
{
    public partial class RunningTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunningTime",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    CinemaHallId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningTime", x => new { x.MovieID, x.CinemaHallId });
                    table.ForeignKey(
                        name: "FK_RunningTime_CinemaHalls_CinemaHallId",
                        column: x => x.CinemaHallId,
                        principalTable: "CinemaHalls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RunningTime_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RunningTime_CinemaHallId",
                table: "RunningTime",
                column: "CinemaHallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunningTime");
        }
    }
}
