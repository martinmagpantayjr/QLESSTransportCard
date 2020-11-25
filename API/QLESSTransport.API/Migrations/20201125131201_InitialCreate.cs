using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLESSTransport.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MrtFares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fare = table.Column<int>(type: "INTEGER", nullable: false),
                    FromLocation = table.Column<string>(type: "TEXT", nullable: true),
                    ToLocation = table.Column<string>(type: "TEXT", nullable: true),
                    Line = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrtFares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountId = table.Column<string>(type: "TEXT", nullable: true),
                    DiscountRegistrationType = table.Column<int>(type: "INTEGER", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUsedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Load = table.Column<double>(type: "REAL", nullable: false),
                    TransportCardType = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscountAppliedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MrtFares");

            migrationBuilder.DropTable(
                name: "TransportCards");
        }
    }
}
