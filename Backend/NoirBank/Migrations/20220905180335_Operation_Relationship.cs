using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class Operation_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountID",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountID",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Operations_BankAccountID",
                table: "Operations",
                column: "BankAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountID",
                table: "Cards",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_BankAccounts_AccountID",
                table: "Cards",
                column: "AccountID",
                principalTable: "BankAccounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_BankAccounts_BankAccountID",
                table: "Operations",
                column: "BankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_BankAccounts_AccountID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_BankAccounts_BankAccountID",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_BankAccountID",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Cards_AccountID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BankAccountID",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Cards");

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountAccountID",
                table: "Cards",
                type: "uniqueidentifier",
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
    }
}
