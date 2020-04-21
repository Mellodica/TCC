using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class AlteracaoFKProdDesejoViewDesejo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_FormaId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_ProdutoId",
                table: "ListaDesejo");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "ListaDesejo",
                newName: "ProdId");

            migrationBuilder.RenameColumn(
                name: "FormaId",
                table: "ListaDesejo",
                newName: "FormId");

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoFormaId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoProdutoId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_FormaPagamentoFormaId",
                table: "ListaDesejo",
                column: "FormaPagamentoFormaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_ListaProdutoProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoProdutoId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.RenameColumn(
                name: "ProdId",
                table: "ListaDesejo",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "ListaDesejo",
                newName: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_FormaId",
                table: "ListaDesejo",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_ProdutoId",
                table: "ListaDesejo",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaId",
                table: "ListaDesejo",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ProdutoId",
                table: "ListaDesejo",
                column: "ProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
