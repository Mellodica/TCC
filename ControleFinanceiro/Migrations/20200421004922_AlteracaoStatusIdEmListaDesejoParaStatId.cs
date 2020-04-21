using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class AlteracaoStatusIdEmListaDesejoParaStatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_StatusId",
                table: "ListaDesejo");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "ListaDesejo",
                newName: "StatId");

            migrationBuilder.AddColumn<int>(
                name: "StatusCompraStatusId",
                table: "ListaDesejo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_StatusCompraStatusId",
                table: "ListaDesejo",
                column: "StatusCompraStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusCompraStatusId",
                table: "ListaDesejo",
                column: "StatusCompraStatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.DropIndex(
                name: "IX_ListaDesejo_StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.DropColumn(
                name: "StatusCompraStatusId",
                table: "ListaDesejo");

            migrationBuilder.RenameColumn(
                name: "StatId",
                table: "ListaDesejo",
                newName: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_StatusId",
                table: "ListaDesejo",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDesejo_StatusCompra_StatusId",
                table: "ListaDesejo",
                column: "StatusId",
                principalTable: "StatusCompra",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
