using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allocator.API.DAL.Migrations
{
    public partial class RemoveNameSurnamekeyinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "Name_Surname_Key",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StockHistoryRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 4, 15, 4, 58, 283, DateTimeKind.Utc).AddTicks(6405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 4, 9, 59, 36, 205, DateTimeKind.Utc).AddTicks(6437));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StockHistoryRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 4, 9, 59, 36, 205, DateTimeKind.Utc).AddTicks(6437),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 4, 15, 4, 58, 283, DateTimeKind.Utc).AddTicks(6405));

            migrationBuilder.AddUniqueConstraint(
                name: "Name_Surname_Key",
                table: "Users",
                columns: new[] { "Name", "Surname" });
        }
    }
}
