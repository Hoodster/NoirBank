using Microsoft.EntityFrameworkCore.Migrations;

namespace NoirBank.Migrations
{
    public partial class OperationSenderInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientAccountNumber",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderAccountNumber",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientAccountNumber",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "SenderAccountNumber",
                table: "Operations");
        }
    }
}
