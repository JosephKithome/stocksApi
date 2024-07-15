using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class trade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Trade",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "EntryPrice",
                table: "Trade",
                type: "decimal(18,5)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExitDate",
                table: "Trade",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExitPrice",
                table: "Trade",
                type: "decimal(18,5)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PipSize",
                table: "Trade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Trade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "StopLoss",
                table: "Trade",
                type: "decimal(18,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TakeProfit",
                table: "Trade",
                type: "decimal(18,5)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trade_StockId",
                table: "Trade",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Stock_StockId",
                table: "Trade",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Stock_StockId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_StockId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "EntryPrice",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "ExitDate",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "ExitPrice",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "PipSize",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "StopLoss",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "TakeProfit",
                table: "Trade");
        }
    }
}
