using Microsoft.EntityFrameworkCore.Migrations;

namespace AppEPI.Migrations
{
    public partial class motivo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Motivo",
                table: "SolicitacaoProduto",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motivo",
                table: "SolicitacaoProduto");
        }
    }
}
