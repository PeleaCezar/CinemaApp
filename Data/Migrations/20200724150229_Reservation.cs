using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Data.Migrations
{
    public partial class Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReservations");

            migrationBuilder.AddColumn<string>(
                name: "MyUserId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MyUserId",
                table: "Reservations",
                column: "MyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MyUserId",
                table: "Reservations",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MyUserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_MyUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "Reservations");

            migrationBuilder.CreateTable(
                name: "UserReservations",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReservations", x => new { x.UserID, x.ReservationID });
                    table.ForeignKey(
                        name: "FK_UserReservations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReservations_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserReservations_ReservationID",
                table: "UserReservations",
                column: "ReservationID");
        }
    }
}
