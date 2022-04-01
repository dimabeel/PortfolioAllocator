using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allocator.API.DAL.Migrations
{
    public partial class RenameStockRowtoStockHistoryRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockRows_Stocks_StockId",
                table: "StockRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockRows",
                table: "StockRows");

            migrationBuilder.RenameTable(
                name: "StockRows",
                newName: "StockHistoryRows");

            migrationBuilder.RenameIndex(
                name: "IX_StockRows_StockId",
                table: "StockHistoryRows",
                newName: "IX_StockHistoryRows_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_StockRows_Id",
                table: "StockHistoryRows",
                newName: "IX_StockHistoryRows_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StockHistoryRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 1, 13, 46, 26, 867, DateTimeKind.Utc).AddTicks(437),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 1, 13, 45, 23, 220, DateTimeKind.Utc).AddTicks(7590));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockHistoryRows",
                table: "StockHistoryRows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistoryRows_Stocks_StockId",
                table: "StockHistoryRows",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistoryRows_Stocks_StockId",
                table: "StockHistoryRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockHistoryRows",
                table: "StockHistoryRows");

            migrationBuilder.RenameTable(
                name: "StockHistoryRows",
                newName: "StockRows");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistoryRows_StockId",
                table: "StockRows",
                newName: "IX_StockRows_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistoryRows_Id",
                table: "StockRows",
                newName: "IX_StockRows_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StockRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 1, 13, 45, 23, 220, DateTimeKind.Utc).AddTicks(7590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 1, 13, 46, 26, 867, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockRows",
                table: "StockRows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockRows_Stocks_StockId",
                table: "StockRows",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }
    }
}
