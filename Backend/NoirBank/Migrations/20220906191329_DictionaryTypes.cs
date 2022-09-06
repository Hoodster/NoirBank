using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class DictionaryTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "TranscationType",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "BankAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "OperationTypeID",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionTypeID",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CardTypeID",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountTypeID",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    CardTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.CardTypeID);
                });

            migrationBuilder.CreateTable(
                name: "OperationTypes",
                columns: table => new
                {
                    OperationTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypes", x => x.OperationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    TransactionTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.TransactionTypeID);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "AccountTypeID", "Type" },
                values: new object[,]
                {
                    { new Guid("79c2ca91-3af7-4615-9bc9-2e7b5a2b4abd"), "Standard" },
                    { new Guid("37dee5ac-da17-49f4-a619-4c4ac12846d5"), "Business" },
                    { new Guid("2a272075-8fcc-4f5c-a7f8-0517d9c48bb7"), "Saving" },
                    { new Guid("fbed716d-f4ab-4235-bce3-fb08fa9d5baf"), "Investmentew3" }
                });

            migrationBuilder.InsertData(
                table: "CardTypes",
                columns: new[] { "CardTypeID", "Type" },
                values: new object[,]
                {
                    { new Guid("37b71328-e1a8-4d3c-9939-a3816243cab9"), "Debit" },
                    { new Guid("9944d4f9-3d34-449b-a531-a8fbcb2f0751"), "Credit" }
                });

            migrationBuilder.InsertData(
                table: "OperationTypes",
                columns: new[] { "OperationTypeID", "Type" },
                values: new object[,]
                {
                    { new Guid("bd8b5c71-f5ae-4356-9e91-8ee54c62f801"), "Deposit" },
                    { new Guid("a1b21558-f719-4203-b986-fe68e5844d44"), "CardTransaciton" },
                    { new Guid("18d8de41-d705-4dde-beed-3b27c4a67395"), "Transfer" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "TransactionTypeID", "Type" },
                values: new object[,]
                {
                    { new Guid("ca898a8f-4bf9-4f05-aed6-5e9c0f746b3c"), "Incomre" },
                    { new Guid("09fc3207-4da1-4048-bf7b-40e687b88ca5"), "Outcome" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationTypeID",
                table: "Operations",
                column: "OperationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_TransactionTypeID",
                table: "Operations",
                column: "TransactionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTypeID",
                table: "Cards",
                column: "CardTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_AccountTypeID",
                table: "BankAccounts",
                column: "AccountTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_AccountTypes_AccountTypeID",
                table: "BankAccounts",
                column: "AccountTypeID",
                principalTable: "AccountTypes",
                principalColumn: "AccountTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTypes_CardTypeID",
                table: "Cards",
                column: "CardTypeID",
                principalTable: "CardTypes",
                principalColumn: "CardTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationTypes_OperationTypeID",
                table: "Operations",
                column: "OperationTypeID",
                principalTable: "OperationTypes",
                principalColumn: "OperationTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_TransactionTypes_TransactionTypeID",
                table: "Operations",
                column: "TransactionTypeID",
                principalTable: "TransactionTypes",
                principalColumn: "TransactionTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_AccountTypes_AccountTypeID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTypes_CardTypeID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationTypes_OperationTypeID",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_TransactionTypes_TransactionTypeID",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "OperationTypes");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Operations_OperationTypeID",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_TransactionTypeID",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CardTypeID",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_AccountTypeID",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "OperationTypeID",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "TransactionTypeID",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "CardTypeID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "AccountTypeID",
                table: "BankAccounts");

            migrationBuilder.AddColumn<string>(
                name: "OperationType",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TranscationType",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardType",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
