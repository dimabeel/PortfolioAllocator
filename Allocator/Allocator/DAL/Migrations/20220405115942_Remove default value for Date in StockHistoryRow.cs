using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allocator.API.DAL.Migrations
{
    public partial class RemovedefaultvalueforDateinStockHistoryRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StockHistoryRows",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 5, 11, 57, 52, 887, DateTimeKind.Utc).AddTicks(374));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StockHistoryRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 11, 57, 52, 887, DateTimeKind.Utc).AddTicks(374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
