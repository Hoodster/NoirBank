using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class Card_Cover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Cards_CardID",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_CardID",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CardID",
                table: "BankAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountAccountID",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BankAccountAccountID",
                table: "Cards",
                column: "BankAccountAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_BankAccounts_BankAccountAccountID",
                table: "Cards",
                column: "BankAccountAccountID",
                principalTable: "BankAccounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_BankAccounts_BankAccountAccountID",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BankAccountAccountID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BankAccountAccountID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Cards");

            migrationBuilder.AddColumn<Guid>(
                name: "CardID",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CardID",
                table: "BankAccounts",
                column: "CardID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Cards_CardID",
                table: "BankAccounts",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
