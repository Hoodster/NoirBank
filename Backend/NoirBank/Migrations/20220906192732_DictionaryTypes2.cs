using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class DictionaryTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: new Guid("2a272075-8fcc-4f5c-a7f8-0517d9c48bb7"),
                column: "Type",
                value: "Business");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: new Guid("37dee5ac-da17-49f4-a619-4c4ac12846d5"),
                column: "Type",
                value: "Saving");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: new Guid("fbed716d-f4ab-4235-bce3-fb08fa9d5baf"),
                column: "Type",
                value: "Investment");

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "TransactionTypeID",
                keyValue: new Guid("ca898a8f-4bf9-4f05-aed6-5e9c0f746b3c"),
                column: "Type",
                value: "Income");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: new Guid("2a272075-8fcc-4f5c-a7f8-0517d9c48bb7"),
                column: "Type",
                value: "Saving");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: new Guid("37dee5ac-da17-49f4-a619-4c4ac12846d5"),
                column: "Type",
                value: "Business");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: new Guid("fbed716d-f4ab-4235-bce3-fb08fa9d5baf"),
                column: "Type",
                value: "Investmentew3");

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "TransactionTypeID",
                keyValue: new Guid("ca898a8f-4bf9-4f05-aed6-5e9c0f746b3c"),
                column: "Type",
                value: "Incomre");
        }
    }
}
