using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminAccessFlightBooking.Migrations
{
    public partial class AdminAccessFlightBookingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightDetails",
                columns: table => new
                {
                    FlightNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ToPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstrumentUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBusinessClassSeat = table.Column<int>(type: "int", nullable: false),
                    TotalNonBusinessClassSeat = table.Column<int>(type: "int", nullable: false),
                    AirlineStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfRows = table.Column<int>(type: "int", nullable: false),
                    Meal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDetails", x => x.FlightNumber);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    FlightDetailsFlightNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_FlightDetails_FlightDetailsFlightNumber",
                        column: x => x.FlightDetailsFlightNumber,
                        principalTable: "FlightDetails",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate:ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discount_FlightDetailsFlightNumber",
                table: "Discount",
                column: "FlightDetailsFlightNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "FlightDetails");
        }
    }
}
