using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class AlteracaoFKsDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_Categoria_CategoriaId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                table: "DespesaDireta");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "DespesaDireta",
                newName: "StatId");

            migrationBuilder.RenameColumn(
                name: "FormaId",
                table: "DespesaDireta",
                newName: "ProdId");

            migrationBuilder.AlterColumn<int>(
                name: "ListaProdutoId",
                table: "DespesaDireta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DespesaDireta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoId",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "DespesaDireta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_Categoria_CategoriaId",
                table: "DespesaDireta",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_Categoria_CategoriaId",
                table: "DespesaDireta");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "CategoId",
                table: "DespesaDireta");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "DespesaDireta");

            migrationBuilder.RenameColumn(
                name: "StatId",
                table: "DespesaDireta",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "ProdId",
                table: "DespesaDireta",
                newName: "FormaId");

            migrationBuilder.AlterColumn<int>(
                name: "ListaProdutoId",
                table: "DespesaDireta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DespesaDireta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_Categoria_CategoriaId",
                table: "DespesaDireta",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDireta_ListaProduto_ListaProdutoId",
                table: "DespesaDireta",
                column: "ListaProdutoId",
                principalTable: "ListaProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
