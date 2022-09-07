using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class FixTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationTypes",
                keyColumn: "OperationTypeID",
                keyValue: new Guid("a1b21558-f719-4203-b986-fe68e5844d44"),
                column: "Type",
                value: "CardTransaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationTypes",
                keyColumn: "OperationTypeID",
                keyValue: new Guid("a1b21558-f719-4203-b986-fe68e5844d44"),
                column: "Type",
                value: "CardTransaciton");
        }
    }
}
