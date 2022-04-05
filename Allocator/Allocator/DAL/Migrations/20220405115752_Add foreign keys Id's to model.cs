using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allocator.API.DAL.Migrations
{
    public partial class AddforeignkeysIdstomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stocks",
                newName: "StockId");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_Id",
                table: "Stocks",
                newName: "IX_Stocks_StockId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StockHistoryRows",
                newName: "StockHistoryRowId");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistoryRows_Id",
                table: "StockHistoryRows",
                newName: "IX_StockHistoryRows_StockHistoryRowId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_Id",
                table: "Accounts",
                newName: "IX_Accounts_AccountId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StockHistoryRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 5, 11, 57, 52, 887, DateTimeKind.Utc).AddTicks(374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 4, 15, 4, 58, 283, DateTimeKind.Utc).AddTicks(6405));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Stocks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_StockId",
                table: "Stocks",
                newName: "IX_Stocks_Id");

            migrationBuilder.RenameColumn(
                name: "StockHistoryRowId",
                table: "StockHistoryRows",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistoryRows_StockHistoryRowId",
                table: "StockHistoryRows",
                newName: "IX_StockHistoryRows_Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_AccountId",
                table: "Accounts",
                newName: "IX_Accounts_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StockHistoryRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 4, 15, 4, 58, 283, DateTimeKind.Utc).AddTicks(6405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 5, 11, 57, 52, 887, DateTimeKind.Utc).AddTicks(374));
        }
    }
}
