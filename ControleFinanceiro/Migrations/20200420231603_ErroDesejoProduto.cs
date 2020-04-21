using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class ErroDesejoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "ListaProdutoProdutoId",
                table: "ListaDesejo");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "ListaDesejo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoId",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_ProdutoId",
                table: "ListaDesejo",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ProdutoId",
                table: "ListaDesejo",
                column: "ProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_ProdutoId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "CategoId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ListaDesejo");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "ListaDesejo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListaProdutoProdutoId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_ListaProdutoProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_ListaProduto_ListaProdutoProdutoId",
                table: "ListaDesejo",
                column: "ListaProdutoProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
