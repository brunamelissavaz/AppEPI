using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppEPI.Migrations
{
    public partial class tamanho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Codigo);
                });

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
                name: "Solicitacao",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostoDeTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoMotivo = table.Column<int>(type: "int", nullable: false),
                    CodigoUF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "UF",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UF", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CodigoCategoria",
                        column: x => x.CodigoCategoria,
                        principalTable: "Categoria",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SolicitacaoUF",
                columns: table => new
                {
                    SolicitacoesCodigo = table.Column<int>(type: "int", nullable: false),
                    UFsCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoUF", x => new { x.SolicitacoesCodigo, x.UFsCodigo });
                    table.ForeignKey(
                        name: "FK_SolicitacaoUF_Solicitacao_SolicitacoesCodigo",
                        column: x => x.SolicitacoesCodigo,
                        principalTable: "Solicitacao",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoUF_UF_UFsCodigo",
                        column: x => x.UFsCodigo,
                        principalTable: "UF",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoProduto",
                columns: table => new
                {
                    CodigoSolicitacao = table.Column<int>(type: "int", nullable: false),
                    CodigoProduto = table.Column<int>(type: "int", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoProduto", x => new { x.CodigoProduto, x.CodigoSolicitacao });
                    table.ForeignKey(
                        name: "FK_SolicitacaoProduto_Produto_CodigoProduto",
                        column: x => x.CodigoProduto,
                        principalTable: "Produto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoProduto_Solicitacao_CodigoSolicitacao",
                        column: x => x.CodigoSolicitacao,
                        principalTable: "Solicitacao",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotivoSolicitacao_SolicitacoesCodigo",
                table: "MotivoSolicitacao",
                column: "SolicitacoesCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CodigoCategoria",
                table: "Produto",
                column: "CodigoCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoProduto_CodigoSolicitacao",
                table: "SolicitacaoProduto",
                column: "CodigoSolicitacao");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoUF_UFsCodigo",
                table: "SolicitacaoUF",
                column: "UFsCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotivoSolicitacao");

            migrationBuilder.DropTable(
                name: "SolicitacaoProduto");

            migrationBuilder.DropTable(
                name: "SolicitacaoUF");

            migrationBuilder.DropTable(
                name: "Motivo");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.DropTable(
                name: "UF");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
