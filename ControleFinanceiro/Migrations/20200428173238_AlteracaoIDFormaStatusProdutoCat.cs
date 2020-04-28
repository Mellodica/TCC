using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class AlteracaoIDFormaStatusProdutoCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_FormaPagamento_FormaId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_StatusCompra_StatusId",
                table: "DespesaDireta");

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
                name: "FK_ListaDesejo_FormaPagamento_FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_FormaPagamento_FormaPagamentoFormaId",
                table: "ListaMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_ListaProduto_ListaProdutoProdutoId",
                table: "ListaMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_StatusCompra_StatusCompraStatusId",
                table: "ListaMercado");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_FormaId",
                table: "DespesaDireta");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_StatusId",
                table: "DespesaDireta");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "StatusCompra",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "ListaProduto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StatusCompraStatusId",
                table: "ListaMercado",
                newName: "StatusCompraId");

            migrationBuilder.RenameColumn(
                name: "ListaProdutoProdutoId",
                table: "ListaMercado",
                newName: "ListaProdutoId");

            migrationBuilder.RenameColumn(
                name: "FormaPagamentoFormaId",
                table: "ListaMercado",
                newName: "FormaPagamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaMercado_StatusCompraStatusId",
                table: "ListaMercado",
                newName: "IX_ListaMercado_StatusCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaMercado_ListaProdutoProdutoId",
                table: "ListaMercado",
                newName: "IX_ListaMercado_ListaProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaMercado_FormaPagamentoFormaId",
                table: "ListaMercado",
                newName: "IX_ListaMercado_FormaPagamentoId");

            migrationBuilder.RenameColumn(
                name: "StatusCompraStatusId",
                table: "ListaDesejo",
                newName: "StatusCompraId");

            migrationBuilder.RenameColumn(
                name: "ListaProdutoProdutoId",
                table: "ListaDesejo",
                newName: "ListaProdutoId");

            migrationBuilder.RenameColumn(
                name: "FormaPagamentoFormaId",
                table: "ListaDesejo",
                newName: "FormaPagamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaDesejo_StatusCompraStatusId",
                table: "ListaDesejo",
                newName: "IX_ListaDesejo_StatusCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaDesejo_ListaProdutoProdutoId",
                table: "ListaDesejo",
                newName: "IX_ListaDesejo_ListaProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaDesejo_FormaPagamentoFormaId",
                table: "ListaDesejo",
                newName: "IX_ListaDesejo_FormaPagamentoId");

            migrationBuilder.RenameColumn(
                name: "FormaId",
                table: "FormaPagamento",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StatusCompraStatusId",
                table: "DespesaFixa",
                newName: "StatusCompraId");

            migrationBuilder.RenameColumn(
                name: "ListaProdutoProdutoId",
                table: "DespesaFixa",
                newName: "ListaProdutoId");

            migrationBuilder.RenameColumn(
                name: "FormaPagamentoFormaId",
                table: "DespesaFixa",
                newName: "FormaPagamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_StatusCompraStatusId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_StatusCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_ListaProdutoProdutoId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_ListaProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_FormaPagamentoFormaId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_FormaPagamentoId");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Categoria",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoId",
                table: "DespesaDireta",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCompraId",
                table: "DespesaDireta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_FormaPagamentoId",
                table: "DespesaDireta",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_StatusCompraId",
                table: "DespesaDireta",
                column: "StatusCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_FormaPagamento_FormaPagamentoId",
                table: "DespesaDireta",
                column: "FormaPagamentoId",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_StatusCompra_StatusCompraId",
                table: "DespesaDireta",
                column: "StatusCompraId",
                principalTable: "StatusCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_FormaPagamento_FormaPagamentoId",
                table: "DespesaFixa",
                column: "FormaPagamentoId",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_ListaProduto_ListaProdutoId",
                table: "DespesaFixa",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_StatusCompra_StatusCompraId",
                table: "DespesaFixa",
                column: "StatusCompraId",
                principalTable: "StatusCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaPagamentoId",
                table: "ListaDesejo",
                column: "FormaPagamentoId",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusCompraId",
                table: "ListaDesejo",
                column: "StatusCompraId",
                principalTable: "StatusCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaMercado_FormaPagamento_FormaPagamentoId",
                table: "ListaMercado",
                column: "FormaPagamentoId",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaMercado_ListaProduto_ListaProdutoId",
                table: "ListaMercado",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaMercado_StatusCompra_StatusCompraId",
                table: "ListaMercado",
                column: "StatusCompraId",
                principalTable: "StatusCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_FormaPagamento_FormaPagamentoId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_StatusCompra_StatusCompraId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_FormaPagamento_FormaPagamentoId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_ListaProduto_ListaProdutoId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_StatusCompra_StatusCompraId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaPagamentoId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusCompraId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_FormaPagamento_FormaPagamentoId",
                table: "ListaMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_ListaProduto_ListaProdutoId",
                table: "ListaMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaMercado_StatusCompra_StatusCompraId",
                table: "ListaMercado");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_FormaPagamentoId",
                table: "DespesaDireta");

            migrationBuilder.DropIndex(
                name: "IX_DespesaDireta_StatusCompraId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "StatusCompraId",
                table: "DespesaDireta");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StatusCompra",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ListaProduto",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "StatusCompraId",
                table: "ListaMercado",
                newName: "StatusCompraStatusId");

            migrationBuilder.RenameColumn(
                name: "ListaProdutoId",
                table: "ListaMercado",
                newName: "ListaProdutoProdutoId");

            migrationBuilder.RenameColumn(
                name: "FormaPagamentoId",
                table: "ListaMercado",
                newName: "FormaPagamentoFormaId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaMercado_StatusCompraId",
                table: "ListaMercado",
                newName: "IX_ListaMercado_StatusCompraStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaMercado_ListaProdutoId",
                table: "ListaMercado",
                newName: "IX_ListaMercado_ListaProdutoProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaMercado_FormaPagamentoId",
                table: "ListaMercado",
                newName: "IX_ListaMercado_FormaPagamentoFormaId");

            migrationBuilder.RenameColumn(
                name: "StatusCompraId",
                table: "ListaDesejo",
                newName: "StatusCompraStatusId");

            migrationBuilder.RenameColumn(
                name: "ListaProdutoId",
                table: "ListaDesejo",
                newName: "ListaProdutoProdutoId");

            migrationBuilder.RenameColumn(
                name: "FormaPagamentoId",
                table: "ListaDesejo",
                newName: "FormaPagamentoFormaId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaDesejo_StatusCompraId",
                table: "ListaDesejo",
                newName: "IX_ListaDesejo_StatusCompraStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaDesejo_ListaProdutoId",
                table: "ListaDesejo",
                newName: "IX_ListaDesejo_ListaProdutoProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaDesejo_FormaPagamentoId",
                table: "ListaDesejo",
                newName: "IX_ListaDesejo_FormaPagamentoFormaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FormaPagamento",
                newName: "FormaId");

            migrationBuilder.RenameColumn(
                name: "StatusCompraId",
                table: "DespesaFixa",
                newName: "StatusCompraStatusId");

            migrationBuilder.RenameColumn(
                name: "ListaProdutoId",
                table: "DespesaFixa",
                newName: "ListaProdutoProdutoId");

            migrationBuilder.RenameColumn(
                name: "FormaPagamentoId",
                table: "DespesaFixa",
                newName: "FormaPagamentoFormaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_StatusCompraId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_StatusCompraStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_ListaProdutoId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_ListaProdutoProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_FormaPagamentoId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_FormaPagamentoFormaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categoria",
                newName: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_FormaId",
                table: "DespesaDireta",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDireta_StatusId",
                table: "DespesaDireta",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_FormaPagamento_FormaId",
                table: "DespesaDireta",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_StatusCompra_StatusId",
                table: "DespesaDireta",
                column: "StatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
