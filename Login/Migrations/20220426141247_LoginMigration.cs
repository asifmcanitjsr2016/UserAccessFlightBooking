using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Login.Migrations
{
    public partial class LoginMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLoginDetails",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AccountCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginDetails", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "UserLoginDetails",
                columns: new[] { "UserID", "AccountCreated", "Age", "Gender", "Name", "Password", "UserType" },
                values: new object[] { "asif123@gmail.com", new DateTime(2022, 4, 26, 19, 42, 46, 649, DateTimeKind.Local).AddTicks(7866), 30, "Male", "Asif Hussain", "Asif@123Hussain", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoginDetails");
        }
    }
}
