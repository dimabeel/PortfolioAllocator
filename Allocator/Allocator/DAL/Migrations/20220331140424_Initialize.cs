using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allocator.API.DAL.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("Name_Surname_Key", x => new { x.Name, x.Surname });
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StockRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Input = table.Column<double>(type: "float(2)", precision: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 31, 14, 4, 24, 861, DateTimeKind.Utc).AddTicks(7491)),
                    Profit = table.Column<double>(type: "float(2)", precision: 2, nullable: false),
                    Output = table.Column<double>(type: "float", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockRows_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Id",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Title",
                table: "Accounts",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockRows_Id",
                table: "StockRows",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StockRows_StockId",
                table: "StockRows",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_AccountId",
                table: "Stocks",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Company",
                table: "Stocks",
                column: "Company");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Id",
                table: "Stocks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockRows");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
