using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaProduto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdutoNome = table.Column<string>(nullable: true),
                    ProdutoDescricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaProduto", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "DespesaDireta",
                columns: table => new
                {
                    DespDirId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DespDirValor = table.Column<double>(nullable: false),
                    DespDirData = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    FormaPagamento = table.Column<int>(nullable: false),
                    FormaPagamentoId = table.Column<int>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    ListaProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesaDireta", x => x.DespDirId);
                    table.ForeignKey(
                        name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                        column: x => x.ListaProdutoId,
                        principalTable: "ListaProduto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespesaFixa",
                columns: table => new
                {
                    DespFixaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DespFixaValor = table.Column<double>(nullable: false),
                    DespFixaData = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    FormaPagamento = table.Column<int>(nullable: false),
                    FormaPagamentoId = table.Column<int>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    ListaProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesaFixa", x => x.DespFixaId);
                    table.ForeignKey(
                        name: "FK_DespesaFixa_ListaProduto_ListaProdutoId",
                        column: x => x.ListaProdutoId,
                        principalTable: "ListaProduto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaDesejo",
                columns: table => new
                {
                    DesejoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesejoValor = table.Column<double>(nullable: false),
                    DesejoData = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    FormaPagamento = table.Column<int>(nullable: false),
                    FormaPagamentoId = table.Column<int>(nullable: false),
                    ListaProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDesejo", x => x.DesejoId);
                    table.ForeignKey(
                        name: "FK_ListaDesejo_ListaProduto_ListaProdutoId",
                        column: x => x.ListaProdutoId,
                        principalTable: "ListaProduto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaMercado",
                columns: table => new
                {
                    MercadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MercadoValor = table.Column<double>(nullable: false),
                    MercadoData = table.Column<DateTime>(nullable: false),
                    ListaProdutoId = table.Column<int>(nullable: false),
                    FormaPagamento = table.Column<int>(nullable: false),
                    FormaPagamentoId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaMercado", x => x.MercadoId);
                    table.ForeignKey(
                        name: "FK_ListaMercado_ListaProduto_ListaProdutoId",
                        column: x => x.ListaProdutoId,
                        principalTable: "ListaProduto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_ListaProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_ListaProdutoId",
                table: "DespesaFixa",
                column: "ListaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_ListaProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaMercado_ListaProdutoId",
                table: "ListaMercado",
                column: "ListaProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesaDireta");

            migrationBuilder.DropTable(
                name: "DespesaFixa");

            migrationBuilder.DropTable(
                name: "ListaDesejo");

            migrationBuilder.DropTable(
                name: "ListaMercado");

            migrationBuilder.DropTable(
                name: "ListaProduto");
        }
    }
}
