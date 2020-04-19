using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class ListaDesejoInnerJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "FormaPagamentoFormaId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "ListaDesejo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormaId",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ListaDesejo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_FormaId",
                table: "ListaDesejo",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_StatusId",
                table: "ListaDesejo",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaId",
                table: "ListaDesejo",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusId",
                table: "ListaDesejo",
                column: "StatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_Categoria_CategoriaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_FormaPagamento_FormaId",
                table: "ListaDesejo");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_FormaId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_StatusId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "FormaId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ListaDesejo");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "ListaDesejo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FormaPagamentoFormaId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCompraStatusId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_FormaPagamentoFormaId",
                table: "ListaDesejo",
                column: "FormaPagamentoFormaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_StatusCompraStatusId",
                table: "ListaDesejo",
                column: "StatusCompraStatusId");

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
                name: "FK_ListaDesejo_StatusCompra_StatusCompraStatusId",
                table: "ListaDesejo",
                column: "StatusCompraStatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
