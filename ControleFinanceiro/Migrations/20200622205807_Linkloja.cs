using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class Linkloja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProdutoNome",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoDescricao",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DespFixaDescricao",
                table: "DespFixas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DespesaDirDescricao",
                table: "DespDiretas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesejoDescricao",
                table: "Desejos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesejoLoja",
                table: "Desejos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesejoLoja",
                table: "Desejos");

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoNome",
                table: "Produtos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoDescricao",
                table: "Produtos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DespFixaDescricao",
                table: "DespFixas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DespesaDirDescricao",
                table: "DespDiretas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DesejoDescricao",
                table: "Desejos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
