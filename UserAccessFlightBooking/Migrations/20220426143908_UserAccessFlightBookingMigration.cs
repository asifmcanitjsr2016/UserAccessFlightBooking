using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAccessFlightBooking.Migrations
{
    public partial class UserAccessFlightBookingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "BookingHistory",
                columns: table => new
                {
                    PNRNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliedCoupon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHistory", x => x.PNRNumber);
                    table.ForeignKey(
                        name: "FK_BookingHistory_UserLoginDetails_UserID",
                        column: x => x.UserID,
                        principalTable: "UserLoginDetails",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ClassType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptForMeal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNo = table.Column<int>(type: "int", nullable: false),
                    BookingHistoryPNRNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.id);
                    table.ForeignKey(
                        name: "FK_Passenger_BookingHistory_BookingHistoryPNRNumber",
                        column: x => x.BookingHistoryPNRNumber,
                        principalTable: "BookingHistory",
                        principalColumn: "PNRNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_BookingHistoryPNRNumber",
                table: "Passenger",
                column: "BookingHistoryPNRNumber");
            migrationBuilder.CreateIndex(
                name: "IX_UserLoginDetails_UserID",
                table: "UserLoginDetails",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "BookingHistory");
        }
    }
}
