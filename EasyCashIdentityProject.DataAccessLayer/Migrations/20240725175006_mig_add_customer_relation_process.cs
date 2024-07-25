using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayer.Migrations
{
    public partial class mig_add_customer_relation_process : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverID",
                table: "CustomerAccountProccesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "CustomerAccountProccesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountProccesses_ReceiverID",
                table: "CustomerAccountProccesses",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountProccesses_SenderID",
                table: "CustomerAccountProccesses",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountProccesses_CustomerAccounts_ReceiverID",
                table: "CustomerAccountProccesses",
                column: "ReceiverID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountProccesses_CustomerAccounts_SenderID",
                table: "CustomerAccountProccesses",
                column: "SenderID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProccesses_CustomerAccounts_ReceiverID",
                table: "CustomerAccountProccesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProccesses_CustomerAccounts_SenderID",
                table: "CustomerAccountProccesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountProccesses_ReceiverID",
                table: "CustomerAccountProccesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountProccesses_SenderID",
                table: "CustomerAccountProccesses");

            migrationBuilder.DropColumn(
                name: "ReceiverID",
                table: "CustomerAccountProccesses");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "CustomerAccountProccesses");
        }
    }
}
