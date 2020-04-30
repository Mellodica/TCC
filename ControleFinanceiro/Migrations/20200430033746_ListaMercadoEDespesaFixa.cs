using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class ListaMercadoEDespesaFixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoId",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdId",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatId",
                table: "ListaMercado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoId",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdId",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatId",
                table: "DespesaFixa",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "ProdId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "StatId",
                table: "ListaMercado");

            migrationBuilder.DropColumn(
                name: "CategoId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "ProdId",
                table: "DespesaFixa");

            migrationBuilder.DropColumn(
                name: "StatId",
                table: "DespesaFixa");
        }
    }
}
