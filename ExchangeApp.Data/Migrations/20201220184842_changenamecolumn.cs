using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeApp.Data.Migrations
{
    public partial class changenamecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ars",
                table: "Transactions",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "Ars");
        }
    }
}
