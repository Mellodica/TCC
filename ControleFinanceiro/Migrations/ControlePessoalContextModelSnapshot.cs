﻿// <auto-generated />
using System;
using ControleFinanceiro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleFinanceiro.Migrations
{
    [DbContext(typeof(ControlePessoalContext))]
    partial class ControlePessoalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleFinanceiro.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoriaNome");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaDireta", b =>
                {
                    b.Property<int?>("DespDirId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DespDirData");

                    b.Property<double>("DespDirValor");

                    b.Property<string>("DespesaDirDescricao")
                        .IsRequired();

                    b.Property<string>("DespesaDirNome")
                        .IsRequired();

                    b.Property<int>("FormaId");

                    b.Property<int>("StatusId");

                    b.HasKey("DespDirId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("StatusId");

                    b.ToTable("DespDiretas");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaFixa", b =>
                {
                    b.Property<int?>("DespFixaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DespFixaData");

                    b.Property<string>("DespFixaDescricao")
                        .IsRequired();

                    b.Property<string>("DespFixaNome")
                        .IsRequired();

                    b.Property<double>("DespFixaValor");

                    b.Property<int>("FormaId");

                    b.Property<int>("StatusId");

                    b.HasKey("DespFixaId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("StatusId");

                    b.ToTable("DespFixas");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.FormaPagamento", b =>
                {
                    b.Property<int>("FormaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FormaNome");

                    b.HasKey("FormaId");

                    b.ToTable("Formas");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.Infra.UsuarioApp", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaDesejo", b =>
                {
                    b.Property<int?>("DesejoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DesejoData");

                    b.Property<string>("DesejoDescricao")
                        .IsRequired();

                    b.Property<string>("DesejoLoja");

                    b.Property<string>("DesejoNome")
                        .IsRequired();

                    b.Property<double>("DesejoValor");

                    b.Property<int>("FormaId");

                    b.Property<int>("StatusId");

                    b.HasKey("DesejoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("StatusId");

                    b.ToTable("Desejos");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaMercado", b =>
                {
                    b.Property<int?>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<int>("FormaId");

                    b.Property<DateTime>("MercadoData");

                    b.Property<string>("MercadoDescricao")
                        .IsRequired();

                    b.Property<string>("MercadoNome")
                        .IsRequired();

                    b.Property<double>("MercadoValor");

                    b.Property<int>("StatusId");

                    b.HasKey("MercadoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("StatusId");

                    b.ToTable("Mercados");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaProduto", b =>
                {
                    b.Property<int?>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<int>("FormaId");

                    b.Property<string>("ProdutoDescricao")
                        .IsRequired();

                    b.Property<string>("ProdutoNome")
                        .IsRequired();

                    b.Property<int>("StatusId");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("StatusId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.Salario", b =>
                {
                    b.Property<int?>("SalarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("SalarioData");

                    b.Property<decimal>("SalarioValor");

                    b.HasKey("SalarioId");

                    b.ToTable("Salarios");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.StatusCompra", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusNome");

                    b.HasKey("StatusId");

                    b.ToTable("StatusCompras");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaDireta", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Categoria", "Categoria")
                        .WithMany("DespesaDiretas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("DespesaDiretas")
                        .HasForeignKey("FormaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("DespesaDiretas")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaFixa", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Categoria", "Categoria")
                        .WithMany("DespesaFixas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("DespesaFixas")
                        .HasForeignKey("FormaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("DespesaFixas")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaDesejo", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Categoria", "Categoria")
                        .WithMany("ListaDesejos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("ListaDesejos")
                        .HasForeignKey("FormaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("ListaDesejos")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaMercado", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Categoria", "Categoria")
                        .WithMany("ListaMercados")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("ListaMercados")
                        .HasForeignKey("FormaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("ListaMercados")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaProduto", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Categoria", "Categoria")
                        .WithMany("ListaProdutos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("ListaProdutos")
                        .HasForeignKey("FormaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("ListaProdutos")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Infra.UsuarioApp")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Infra.UsuarioApp")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleFinanceiro.Models.Infra.UsuarioApp")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Infra.UsuarioApp")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}