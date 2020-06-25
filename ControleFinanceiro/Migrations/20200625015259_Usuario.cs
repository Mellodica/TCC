using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropColumn(
                name: "SalarioData",
                table: "Salarios");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalarioValor",
                table: "Salarios",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoMimeType",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimeiroNome",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SalarioId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_UsuarioId",
                table: "AspNetUsers",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SalarioId",
                table: "AspNetUsers",
                column: "SalarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Salarios_SalarioId",
                table: "AspNetUsers",
                column: "SalarioId",
                principalTable: "Salarios",
                principalColumn: "SalarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Salarios_SalarioId",
                table: "AspNetUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_UsuarioId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SalarioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FotoMimeType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrimeiroNome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SalarioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalarioValor",
                table: "Salarios",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "SalarioData",
                table: "Salarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaId = table.Column<int>(nullable: false),
                    FormaId = table.Column<int>(nullable: false),
                    ProdutoDescricao = table.Column<string>(nullable: false),
                    ProdutoNome = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_StatusCompras_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusCompras",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FormaId",
                table: "Produtos",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_StatusId",
                table: "Produtos",
                column: "StatusId");
        }
    }
}
