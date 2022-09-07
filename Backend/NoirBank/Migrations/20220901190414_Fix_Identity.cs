using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class Fix_Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_AdminID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Cards_CardID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Customers_CustomerID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_HomeAddressID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionLogs_AspNetUsers_UserID",
                table: "SessionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionLogs_Customers_CustomerID",
                table: "SessionLogs");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Admins");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Admins_AdminID",
                table: "AspNetUsers",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerID",
                table: "AspNetUsers",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Cards_CardID",
                table: "BankAccounts",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Customers_CustomerID",
                table: "BankAccounts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_HomeAddressID",
                table: "Customers",
                column: "HomeAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionLogs_AspNetUsers_UserID",
                table: "SessionLogs",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionLogs_Customers_CustomerID",
                table: "SessionLogs",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Admins_AdminID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Cards_CardID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Customers_CustomerID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_HomeAddressID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionLogs_AspNetUsers_UserID",
                table: "SessionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionLogs_Customers_CustomerID",
                table: "SessionLogs");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_AdminID",
                table: "AspNetUsers",
                column: "AdminID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerID",
                table: "AspNetUsers",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Cards_CardID",
                table: "BankAccounts",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Customers_CustomerID",
                table: "BankAccounts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_HomeAddressID",
                table: "Customers",
                column: "HomeAddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionLogs_AspNetUsers_UserID",
                table: "SessionLogs",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionLogs_Customers_CustomerID",
                table: "SessionLogs",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
