using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class remodelado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_ListaProduto_ListaProdutoId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_ListaProduto_ListaProdutoId",
                table: "ListaMercado");

            migrationBuilder.DropIndex(
                name: "IX_ListaMercado_ListaProdutoId",
                table: "ListaMercado");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_ListaProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_DespesaFixa_ListaProdutoId",
                table: "DespesaFixa");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_ListaProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "FormaPagamento",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "ListaProdutoId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "FormaPagamento",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "ListaProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "FormaPagamento",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "ListaProdutoId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "FormaPagamento",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "ListaProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "DespesaDireta");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "ListaMercado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoFormaId",
                table: "ListaMercado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoProdutoId",
                table: "ListaMercado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCompraStatusId",
                table: "ListaMercado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoFormaId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoProdutoId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCompraStatusId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DespesaFixa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoFormaId",
                table: "DespesaFixa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoProdutoId",
                table: "DespesaFixa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCompraStatusId",
                table: "DespesaFixa",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DespesaDireta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoFormaId",
                table: "DespesaDireta",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoProdutoId",
                table: "DespesaDireta",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCompraStatusId",
                table: "DespesaDireta",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    FormaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormaNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.FormaId);
                });

            migrationBuilder.CreateTable(
                name: "StatusCompra",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCompra", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaMercado_CategoriaId",
                table: "ListaMercado",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaMercado_FormaPagamentoFormaId",
                table: "ListaMercado",
                column: "FormaPagamentoFormaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaMercado_ListaProdutoProdutoId",
                table: "ListaMercado",
                column: "ListaProdutoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaMercado_StatusCompraStatusId",
                table: "ListaMercado",
                column: "StatusCompraStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_CategoriaId",
                table: "ListaDesejo",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_FormaPagamentoFormaId",
                table: "ListaDesejo",
                column: "FormaPagamentoFormaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_ListaProdutoProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_StatusCompraStatusId",
                table: "ListaDesejo",
                column: "StatusCompraStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_CategoriaId",
                table: "DespesaFixa",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_FormaPagamentoFormaId",
                table: "DespesaFixa",
                column: "FormaPagamentoFormaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_ListaProdutoProdutoId",
                table: "DespesaFixa",
                column: "ListaProdutoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_StatusCompraStatusId",
                table: "DespesaFixa",
                column: "StatusCompraStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_CategoriaId",
                table: "DespesaDireta",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_FormaPagamentoFormaId",
                table: "DespesaDireta",
                column: "FormaPagamentoFormaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_ListaProdutoProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_StatusCompraStatusId",
                table: "DespesaDireta",
                column: "StatusCompraStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_Categoria_CategoriaId",
                table: "DespesaDireta",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_FormaPagamento_FormaPagamentoFormaId",
                table: "DespesaDireta",
                column: "FormaPagamentoFormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_StatusCompra_StatusCompraStatusId",
                table: "DespesaDireta",
                column: "StatusCompraStatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_Categoria_CategoriaId",
                table: "DespesaFixa",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_FormaPagamento_FormaPagamentoFormaId",
                table: "DespesaFixa",
                column: "FormaPagamentoFormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_ListaProduto_ListaProdutoProdutoId",
                table: "DespesaFixa",
                column: "ListaProdutoProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_StatusCompra_StatusCompraStatusId",
                table: "DespesaFixa",
                column: "StatusCompraStatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaPagamentoFormaId",
                table: "ListaDesejo",
                column: "FormaPagamentoFormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusCompraStatusId",
                table: "ListaDesejo",
                column: "StatusCompraStatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaMercado_Categoria_CategoriaId",
                table: "ListaMercado",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaMercado_FormaPagamento_FormaPagamentoFormaId",
                table: "ListaMercado",
                column: "FormaPagamentoFormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaMercado_ListaProduto_ListaProdutoProdutoId",
                table: "ListaMercado",
                column: "ListaProdutoProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaMercado_StatusCompra_StatusCompraStatusId",
                table: "ListaMercado",
                column: "StatusCompraStatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_Categoria_CategoriaId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_FormaPagamento_FormaPagamentoFormaId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_StatusCompra_StatusCompraStatusId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_Categoria_CategoriaId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_FormaPagamento_FormaPagamentoFormaId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_ListaProduto_ListaProdutoProdutoId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_StatusCompra_StatusCompraStatusId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_Categoria_CategoriaId",
                table: "ListaMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_FormaPagamento_FormaPagamentoFormaId",
                table: "ListaMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_ListaProduto_ListaProdutoProdutoId",
                table: "ListaMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_StatusCompra_StatusCompraStatusId",
                table: "ListaMercado");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "StatusCompra");

            migrationBuilder.DropIndex(
                name: "IX_ListaMercado_CategoriaId",
                table: "ListaMercado");

            migrationBuilder.DropIndex(
                name: "IX_ListaMercado_FormaPagamentoFormaId",
                table: "ListaMercado");

            migrationBuilder.DropIndex(
                name: "IX_ListaMercado_ListaProdutoProdutoId",
                table: "ListaMercado");

            migrationBuilder.DropIndex(
                name: "IX_ListaMercado_StatusCompraStatusId",
                table: "ListaMercado");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_CategoriaId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_DespesaFixa_CategoriaId",
                table: "DespesaFixa");

            migrationBuilder.DropIndex(
                name: "IX_DespesaFixa_FormaPagamentoFormaId",
                table: "DespesaFixa");

            migrationBuilder.DropIndex(
                name: "IX_DespesaFixa_ListaProdutoProdutoId",
                table: "DespesaFixa");

            migrationBuilder.DropIndex(
                name: "IX_DespesaFixa_StatusCompraStatusId",
                table: "DespesaFixa");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_CategoriaId",
                table: "DespesaDireta");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_FormaPagamentoFormaId",
                table: "DespesaDireta");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_ListaProdutoProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_StatusCompraStatusId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoFormaId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "ListaProdutoProdutoId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "StatusCompraStatusId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoFormaId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "ListaProdutoProdutoId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "StatusCompraStatusId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoFormaId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "ListaProdutoProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "StatusCompraStatusId",
                table: "DespesaDireta");

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamento",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoId",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoId",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamento",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoId",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoId",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DespesaFixa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamento",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoId",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoId",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DespesaDireta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamento",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoId",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoId",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ListaMercado_ListaProdutoId",
                table: "ListaMercado",
                column: "ListaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_ListaProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_ListaProdutoId",
                table: "DespesaFixa",
                column: "ListaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_ListaProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_ListaProduto_ListaProdutoId",
                table: "DespesaFixa",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaMercado_ListaProduto_ListaProdutoId",
                table: "ListaMercado",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
