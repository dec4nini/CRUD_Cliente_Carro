using Microsoft.EntityFrameworkCore.Migrations;

namespace ClienteProduto.Migrations
{
    public partial class editModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "Clientes",
                newName: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Clientes",
                newName: "ClienteID");
        }
    }
}
