using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class DespesaDiretaInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FormaPagamentoFormaId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "ListaProdutoProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "StatusCompraStatusId",
                table: "DespesaDireta");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DespesaDireta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormaId",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoId",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_FormaId",
                table: "DespesaDireta",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_ListaProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_StatusId",
                table: "DespesaDireta",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_Categoria_CategoriaId",
                table: "DespesaDireta",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_FormaPagamento_FormaId",
                table: "DespesaDireta",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_StatusCompra_StatusId",
                table: "DespesaDireta",
                column: "StatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_Categoria_CategoriaId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_FormaPagamento_FormaId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_StatusCompra_StatusId",
                table: "DespesaDireta");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_FormaId",
                table: "DespesaDireta");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_ListaProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_StatusId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "FormaId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "ListaProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "DespesaDireta");

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
        }
    }
}
