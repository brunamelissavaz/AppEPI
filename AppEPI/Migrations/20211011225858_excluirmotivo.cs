using Microsoft.EntityFrameworkCore.Migrations;

namespace AppEPI.Migrations
{
    public partial class excluirmotivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotivoSolicitacaoProduto");

            migrationBuilder.DropTable(
                name: "Motivo");

            migrationBuilder.DropColumn(
                name: "CodigoMotivo",
                table: "SolicitacaoProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoMotivo",
                table: "SolicitacaoProduto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "MotivoSolicitacaoProduto",
                columns: table => new
                {
                    MotivosCodigo = table.Column<int>(type: "int", nullable: false),
                    SolicitacaoProdutosCodigoProduto = table.Column<int>(type: "int", nullable: false),
                    SolicitacaoProdutosCodigoSolicitacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoSolicitacaoProduto", x => new { x.MotivosCodigo, x.SolicitacaoProdutosCodigoProduto, x.SolicitacaoProdutosCodigoSolicitacao });
                    table.ForeignKey(
                        name: "FK_MotivoSolicitacaoProduto_Motivo_MotivosCodigo",
                        column: x => x.MotivosCodigo,
                        principalTable: "Motivo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotivoSolicitacaoProduto_SolicitacaoProduto_SolicitacaoProdutosCodigoProduto_SolicitacaoProdutosCodigoSolicitacao",
                        columns: x => new { x.SolicitacaoProdutosCodigoProduto, x.SolicitacaoProdutosCodigoSolicitacao },
                        principalTable: "SolicitacaoProduto",
                        principalColumns: new[] { "CodigoProduto", "CodigoSolicitacao" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotivoSolicitacaoProduto_SolicitacaoProdutosCodigoProduto_SolicitacaoProdutosCodigoSolicitacao",
                table: "MotivoSolicitacaoProduto",
                columns: new[] { "SolicitacaoProdutosCodigoProduto", "SolicitacaoProdutosCodigoSolicitacao" });
        }
    }
}
