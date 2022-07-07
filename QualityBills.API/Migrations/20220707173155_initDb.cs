using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualityBills.API.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerType = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BankName = table.Column<string>(type: "TEXT", nullable: false),
                    BankIban = table.Column<string>(type: "TEXT", nullable: false),
                    BankBic = table.Column<string>(type: "TEXT", nullable: false),
                    BankAccountOwner = table.Column<string>(type: "TEXT", nullable: false),
                    Organization = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Address2 = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Mobile = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    VatId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PreferredUsername = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Birthdate", "Email", "FamilyName", "GivenName", "PasswordHash", "PasswordSalt", "PreferredUsername" },
                values: new object[] { 1, new DateOnly(2022, 6, 7), "test@email.de", "familyName", "givenName", new byte[] { 81, 73, 82, 204, 197, 33, 170, 121, 15, 76, 192, 145, 208, 187, 221, 14, 1, 50, 152, 33, 115, 103, 237, 1, 201, 118, 100, 26, 19, 79, 82, 77, 223, 162, 49, 115, 123, 61, 10, 100, 32, 232, 132, 61, 32, 134, 228, 205, 144, 185, 184, 68, 227, 183, 193, 247, 85, 27, 48, 53, 43, 162, 146, 114 }, new byte[] { 27, 248, 49, 177, 39, 231, 218, 0, 162, 1, 154, 92, 252, 15, 213, 116, 56, 57, 85, 1, 190, 19, 186, 120, 202, 181, 252, 170, 78, 214, 255, 92, 21, 48, 164, 50, 124, 96, 83, 241, 41, 195, 131, 213, 151, 128, 123, 112, 71, 102, 250, 108, 241, 33, 54, 233, 54, 242, 240, 42, 174, 244, 54, 125, 61, 117, 122, 114, 76, 20, 31, 102, 161, 194, 84, 181, 219, 106, 74, 255, 167, 94, 229, 98, 215, 245, 144, 233, 148, 235, 2, 83, 34, 161, 230, 102, 234, 149, 141, 206, 133, 176, 161, 8, 119, 15, 101, 148, 191, 152, 76, 15, 200, 108, 234, 51, 14, 179, 143, 190, 67, 222, 40, 75, 127, 196, 192, 46 }, "username" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
