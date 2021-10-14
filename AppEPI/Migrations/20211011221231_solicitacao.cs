using Microsoft.EntityFrameworkCore.Migrations;

namespace AppEPI.Migrations
{
    public partial class solicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motivo_SolicitacaoProduto_SolicitacaoProdutoCodigoProduto_SolicitacaoProdutoCodigoSolicitacao",
                table: "Motivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Motivo_MotivoCodigo",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_MotivoCodigo",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Motivo_SolicitacaoProdutoCodigoProduto_SolicitacaoProdutoCodigoSolicitacao",
                table: "Motivo");

            migrationBuilder.DropColumn(
                name: "MotivoCodigo",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "SolicitacaoProdutoCodigoProduto",
                table: "Motivo");

            migrationBuilder.DropColumn(
                name: "SolicitacaoProdutoCodigoSolicitacao",
                table: "Motivo");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotivoSolicitacaoProduto");

            migrationBuilder.AddColumn<int>(
                name: "MotivoCodigo",
                table: "Solicitacao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SolicitacaoProdutoCodigoProduto",
                table: "Motivo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SolicitacaoProdutoCodigoSolicitacao",
                table: "Motivo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_MotivoCodigo",
                table: "Solicitacao",
                column: "MotivoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Motivo_SolicitacaoProdutoCodigoProduto_SolicitacaoProdutoCodigoSolicitacao",
                table: "Motivo",
                columns: new[] { "SolicitacaoProdutoCodigoProduto", "SolicitacaoProdutoCodigoSolicitacao" });

            migrationBuilder.AddForeignKey(
                name: "FK_Motivo_SolicitacaoProduto_SolicitacaoProdutoCodigoProduto_SolicitacaoProdutoCodigoSolicitacao",
                table: "Motivo",
                columns: new[] { "SolicitacaoProdutoCodigoProduto", "SolicitacaoProdutoCodigoSolicitacao" },
                principalTable: "SolicitacaoProduto",
                principalColumns: new[] { "CodigoProduto", "CodigoSolicitacao" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Motivo_MotivoCodigo",
                table: "Solicitacao",
                column: "MotivoCodigo",
                principalTable: "Motivo",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
