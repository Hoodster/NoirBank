using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class Fix_SessionLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionLogs_Customers_CustomerID",
                table: "SessionLogs");

            migrationBuilder.DropIndex(
                name: "IX_SessionLogs_CustomerID",
                table: "SessionLogs");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "SessionLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerID",
                table: "SessionLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_CustomerID",
                table: "SessionLogs",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionLogs_Customers_CustomerID",
                table: "SessionLogs",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
