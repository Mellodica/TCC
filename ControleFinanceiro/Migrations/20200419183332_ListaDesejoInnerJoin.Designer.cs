﻿// <auto-generated />
using System;
using ControleFinanceiro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleFinanceiro.Migrations
{
    [DbContext(typeof(ControleFinanceiroContext))]
    [Migration("20200419183332_ListaDesejoInnerJoin")]
    partial class ListaDesejoInnerJoin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaDireta", b =>
                {
                    b.Property<int>("DespDirId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId");

                    b.Property<DateTime>("DespDirData");

                    b.Property<double>("DespDirValor");

                    b.Property<int?>("FormaPagamentoFormaId");

                    b.Property<int?>("ListaProdutoProdutoId");

                    b.Property<int?>("StatusCompraStatusId");

                    b.HasKey("DespDirId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaPagamentoFormaId");

                    b.HasIndex("ListaProdutoProdutoId");

                    b.HasIndex("StatusCompraStatusId");

                    b.ToTable("DespesaDireta");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaFixa", b =>
                {
                    b.Property<int>("DespFixaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId");

                    b.Property<DateTime>("DespFixaData");

                    b.Property<double>("DespFixaValor");

                    b.Property<int?>("FormaPagamentoFormaId");

                    b.Property<int?>("ListaProdutoProdutoId");

                    b.Property<int?>("StatusCompraStatusId");

                    b.HasKey("DespFixaId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaPagamentoFormaId");

                    b.HasIndex("ListaProdutoProdutoId");

                    b.HasIndex("StatusCompraStatusId");

                    b.ToTable("DespesaFixa");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.FormaPagamento", b =>
                {
                    b.Property<int>("FormaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FormaNome");

                    b.HasKey("FormaId");

                    b.ToTable("FormaPagamento");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaDesejo", b =>
                {
                    b.Property<int>("DesejoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DesejoData");

                    b.Property<double>("DesejoValor");

                    b.Property<int>("FormaId");

                    b.Property<int?>("ListaProdutoProdutoId");

                    b.Property<int>("StatusId");

                    b.HasKey("DesejoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaId");

                    b.HasIndex("ListaProdutoProdutoId");

                    b.HasIndex("StatusId");

                    b.ToTable("ListaDesejo");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaMercado", b =>
                {
                    b.Property<int>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId");

                    b.Property<int?>("FormaPagamentoFormaId");

                    b.Property<int?>("ListaProdutoProdutoId");

                    b.Property<DateTime>("MercadoData");

                    b.Property<double>("MercadoValor");

                    b.Property<int?>("StatusCompraStatusId");

                    b.HasKey("MercadoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FormaPagamentoFormaId");

                    b.HasIndex("ListaProdutoProdutoId");

                    b.HasIndex("StatusCompraStatusId");

                    b.ToTable("ListaMercado");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaProduto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProdutoDescricao");

                    b.Property<string>("ProdutoNome");

                    b.HasKey("ProdutoId");

                    b.ToTable("ListaProduto");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.StatusCompra", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusNome");

                    b.HasKey("StatusId");

                    b.ToTable("StatusCompra");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaDireta", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Categoria", "Categoria")
                        .WithMany("DespesaDiretas")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("ControleFinanceiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("DespesaDiretas")
                        .HasForeignKey("FormaPagamentoFormaId");

                    b.HasOne("ControleFinanceiro.Models.ListaProduto", "ListaProduto")
                        .WithMany("DespesaDireta")
                        .HasForeignKey("ListaProdutoProdutoId");

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("DespesaDiretas")
                        .HasForeignKey("StatusCompraStatusId");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaFixa", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Categoria", "Categoria")
                        .WithMany("DespesaFixas")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("ControleFinanceiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("DespesaFixas")
                        .HasForeignKey("FormaPagamentoFormaId");

                    b.HasOne("ControleFinanceiro.Models.ListaProduto", "ListaProduto")
                        .WithMany("DespesaFixa")
                        .HasForeignKey("ListaProdutoProdutoId");

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("DespesaFixas")
                        .HasForeignKey("StatusCompraStatusId");
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

                    b.HasOne("ControleFinanceiro.Models.ListaProduto")
                        .WithMany("Desejos")
                        .HasForeignKey("ListaProdutoProdutoId");

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("ListaDesejos")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaMercado", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.Categoria", "Categoria")
                        .WithMany("ListaMercados")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("ControleFinanceiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("ListaMercados")
                        .HasForeignKey("FormaPagamentoFormaId");

                    b.HasOne("ControleFinanceiro.Models.ListaProduto")
                        .WithMany("Mercado")
                        .HasForeignKey("ListaProdutoProdutoId");

                    b.HasOne("ControleFinanceiro.Models.StatusCompra", "StatusCompra")
                        .WithMany("ListaMercados")
                        .HasForeignKey("StatusCompraStatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
