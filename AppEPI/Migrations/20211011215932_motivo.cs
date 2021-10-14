using Microsoft.EntityFrameworkCore.Migrations;

namespace AppEPI.Migrations
{
    public partial class motivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotivoSolicitacao");

            migrationBuilder.DropColumn(
                name: "CodigoMotivo",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "Tamanho",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "CodigoMotivo",
                table: "SolicitacaoProduto",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CodigoMotivo",
                table: "SolicitacaoProduto");

            migrationBuilder.DropColumn(
                name: "MotivoCodigo",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "SolicitacaoProdutoCodigoProduto",
                table: "Motivo");

            migrationBuilder.DropColumn(
                name: "SolicitacaoProdutoCodigoSolicitacao",
                table: "Motivo");

            migrationBuilder.AddColumn<int>(
                name: "CodigoMotivo",
                table: "Solicitacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tamanho",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MotivoSolicitacao",
                columns: table => new
                {
                    MotivosCodigo = table.Column<int>(type: "int", nullable: false),
                    SolicitacoesCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoSolicitacao", x => new { x.MotivosCodigo, x.SolicitacoesCodigo });
                    table.ForeignKey(
                        name: "FK_MotivoSolicitacao_Motivo_MotivosCodigo",
                        column: x => x.MotivosCodigo,
                        principalTable: "Motivo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotivoSolicitacao_Solicitacao_SolicitacoesCodigo",
                        column: x => x.SolicitacoesCodigo,
                        principalTable: "Solicitacao",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotivoSolicitacao_SolicitacoesCodigo",
                table: "MotivoSolicitacao",
                column: "SolicitacoesCodigo");
        }
    }
}
