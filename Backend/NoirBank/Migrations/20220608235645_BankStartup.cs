using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class BankStartup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Accounts_AccountID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Accounts_SenderAccountId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Cards_AccountID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "SenderAccountId",
                table: "Operations",
                newName: "SenderAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_SenderAccountId",
                table: "Operations",
                newName: "IX_Operations_SenderAccountID");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "AccountID");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Accounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "CardID",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CardID",
                table: "Accounts",
                column: "CardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Cards_CardID",
                table: "Accounts",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Accounts_SenderAccountID",
                table: "Operations",
                column: "SenderAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Cards_CardID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Accounts_SenderAccountID",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CardID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CardID",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "SenderAccountID",
                table: "Operations",
                newName: "SenderAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_SenderAccountID",
                table: "Operations",
                newName: "IX_Operations_SenderAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Accounts",
                newName: "AccountId");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountID",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountID",
                table: "Cards",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Accounts_AccountID",
                table: "Cards",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Accounts_SenderAccountId",
                table: "Operations",
                column: "SenderAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
