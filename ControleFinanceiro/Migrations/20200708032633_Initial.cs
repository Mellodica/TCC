using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Controles",
                columns: table => new
                {
                    Capacity = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    PrimeiroNome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaNome = table.Column<string>(nullable: true),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                    table.ForeignKey(
                        name: "FK_Categorias_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Formas",
                columns: table => new
                {
                    FormaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormaNome = table.Column<string>(nullable: true),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formas", x => x.FormaId);
                    table.ForeignKey(
                        name: "FK_Formas_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salarios",
                columns: table => new
                {
                    SalarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalarioNome = table.Column<string>(nullable: false),
                    SalarioValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalarioData = table.Column<DateTime>(nullable: false),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarios", x => x.SalarioId);
                    table.ForeignKey(
                        name: "FK_Salarios_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusCompras",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusNome = table.Column<string>(nullable: true),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCompras", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_StatusCompras_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desejos",
                columns: table => new
                {
                    DesejoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesejoValor = table.Column<double>(nullable: false),
                    DesejoNome = table.Column<string>(nullable: false),
                    DesejoDescricao = table.Column<string>(nullable: false),
                    DesejoData = table.Column<DateTime>(nullable: false),
                    DesejoLoja = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    FormaId = table.Column<int>(nullable: false),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desejos", x => x.DesejoId);
                    table.ForeignKey(
                        name: "FK_Desejos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Desejos_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Desejos_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desejos_StatusCompras_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusCompras",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespDiretas",
                columns: table => new
                {
                    DespDirId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DespesaDirNome = table.Column<string>(nullable: false),
                    DespesaDirDescricao = table.Column<string>(nullable: false),
                    DespDirValor = table.Column<double>(nullable: false),
                    DespDirData = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    FormaId = table.Column<int>(nullable: false),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespDiretas", x => x.DespDirId);
                    table.ForeignKey(
                        name: "FK_DespDiretas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DespDiretas_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DespDiretas_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DespDiretas_StatusCompras_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusCompras",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespFixas",
                columns: table => new
                {
                    DespFixaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DespFixaNome = table.Column<string>(nullable: false),
                    DespFixaDescricao = table.Column<string>(nullable: false),
                    DespFixaValor = table.Column<double>(nullable: false),
                    DespFixaData = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    FormaId = table.Column<int>(nullable: false),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespFixas", x => x.DespFixaId);
                    table.ForeignKey(
                        name: "FK_DespFixas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DespFixas_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DespFixas_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DespFixas_StatusCompras_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusCompras",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    MercadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MercadoNome = table.Column<string>(nullable: false),
                    MercadoData = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    FormaId = table.Column<int>(nullable: false),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.MercadoId);
                    table.ForeignKey(
                        name: "FK_Mercados_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mercados_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mercados_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercados_StatusCompras_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusCompras",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    ListaMercadoMercadoId = table.Column<int>(nullable: true),
                    ProdutoNome = table.Column<string>(nullable: true),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServicoControlesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Mercados_ListaMercadoMercadoId",
                        column: x => x.ListaMercadoMercadoId,
                        principalTable: "Mercados",
                        principalColumn: "MercadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Controles_ServicoControlesId",
                        column: x => x.ServicoControlesId,
                        principalTable: "Controles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ServicoControlesId",
                table: "AspNetUsers",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ServicoControlesId",
                table: "Categorias",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_CategoriaId",
                table: "Desejos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_FormaId",
                table: "Desejos",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_ServicoControlesId",
                table: "Desejos",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_StatusId",
                table: "Desejos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DespDiretas_CategoriaId",
                table: "DespDiretas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespDiretas_FormaId",
                table: "DespDiretas",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespDiretas_ServicoControlesId",
                table: "DespDiretas",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_DespDiretas_StatusId",
                table: "DespDiretas",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DespFixas_CategoriaId",
                table: "DespFixas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespFixas_FormaId",
                table: "DespFixas",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespFixas_ServicoControlesId",
                table: "DespFixas",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_DespFixas_StatusId",
                table: "DespFixas",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Formas_ServicoControlesId",
                table: "Formas",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_CategoriaId",
                table: "Mercados",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_FormaId",
                table: "Mercados",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_ServicoControlesId",
                table: "Mercados",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_StatusId",
                table: "Mercados",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ListaMercadoMercadoId",
                table: "Produtos",
                column: "ListaMercadoMercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ServicoControlesId",
                table: "Produtos",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_Salarios_ServicoControlesId",
                table: "Salarios",
                column: "ServicoControlesId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCompras_ServicoControlesId",
                table: "StatusCompras",
                column: "ServicoControlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Desejos");

            migrationBuilder.DropTable(
                name: "DespDiretas");

            migrationBuilder.DropTable(
                name: "DespFixas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Salarios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Formas");

            migrationBuilder.DropTable(
                name: "StatusCompras");

            migrationBuilder.DropTable(
                name: "Controles");
        }
    }
}
