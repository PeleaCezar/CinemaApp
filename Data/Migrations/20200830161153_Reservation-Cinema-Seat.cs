using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Data.Migrations
{
    public partial class ReservationCinemaSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MyUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MyUserId",
                table: "Reservations",
                newName: "MyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MyUserId",
                table: "Reservations",
                newName: "IX_Reservations_MyUserID");

            migrationBuilder.AddColumn<int>(
                name: "CinemaHallID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRunning",
                table: "Movies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CinemaHalls",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHalls", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNr = table.Column<int>(nullable: false),
                    CinemaHallID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seats_CinemaHalls_CinemaHallID",
                        column: x => x.CinemaHallID,
                        principalTable: "CinemaHalls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatReservations",
                columns: table => new
                {
                    SeatID = table.Column<int>(nullable: false),
                    ReservationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatReservations", x => new { x.SeatID, x.ReservationID });
                    table.ForeignKey(
                        name: "FK_SeatReservations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatReservations_Seats_SeatID",
                        column: x => x.SeatID,
                        principalTable: "Seats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CinemaHallID",
                table: "Reservations",
                column: "CinemaHallID");

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_ReservationID",
                table: "SeatReservations",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CinemaHallID",
                table: "Seats",
                column: "CinemaHallID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_CinemaHalls_CinemaHallID",
                table: "Reservations",
                column: "CinemaHallID",
                principalTable: "CinemaHalls",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MyUserID",
                table: "Reservations",
                column: "MyUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_CinemaHalls_CinemaHallID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MyUserID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "SeatReservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "CinemaHalls");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CinemaHallID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CinemaHallID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DateRunning",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MyUserID",
                table: "Reservations",
                newName: "MyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MyUserID",
                table: "Reservations",
                newName: "IX_Reservations_MyUserId");

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MyUserId",
                table: "Reservations",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
