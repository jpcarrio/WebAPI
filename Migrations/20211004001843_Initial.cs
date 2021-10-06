using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ContactType = table.Column<int>(nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactId = table.Column<int>(nullable: false),
                    ReservationPlace = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 1, "ContactType 1" });

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 2, "ContactType 2" });

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 3, "ContactType 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
