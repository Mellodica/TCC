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
    [Migration("20200418044839_Primeira")]
    partial class Primeira
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaDireta", b =>
                {
                    b.Property<int>("DespDirId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Categoria");

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DespDirData");

                    b.Property<double>("DespDirValor");

                    b.Property<int>("FormaPagamento");

                    b.Property<int>("FormaPagamentoId");

                    b.Property<int>("ListaProdutoId");

                    b.Property<int>("Status");

                    b.Property<int>("StatusId");

                    b.HasKey("DespDirId");

                    b.HasIndex("ListaProdutoId");

                    b.ToTable("DespesaDireta");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaFixa", b =>
                {
                    b.Property<int>("DespFixaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Categoria");

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DespFixaData");

                    b.Property<double>("DespFixaValor");

                    b.Property<int>("FormaPagamento");

                    b.Property<int>("FormaPagamentoId");

                    b.Property<int>("ListaProdutoId");

                    b.Property<int>("Status");

                    b.Property<int>("StatusId");

                    b.HasKey("DespFixaId");

                    b.HasIndex("ListaProdutoId");

                    b.ToTable("DespesaFixa");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaDesejo", b =>
                {
                    b.Property<int>("DesejoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DesejoData");

                    b.Property<double>("DesejoValor");

                    b.Property<int>("FormaPagamento");

                    b.Property<int>("FormaPagamentoId");

                    b.Property<int>("ListaProdutoId");

                    b.Property<int>("Status");

                    b.Property<int>("StatusId");

                    b.HasKey("DesejoId");

                    b.HasIndex("ListaProdutoId");

                    b.ToTable("ListaDesejo");
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaMercado", b =>
                {
                    b.Property<int>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FormaPagamento");

                    b.Property<int>("FormaPagamentoId");

                    b.Property<int>("ListaProdutoId");

                    b.Property<DateTime>("MercadoData");

                    b.Property<double>("MercadoValor");

                    b.Property<int>("Status");

                    b.Property<int>("StatusId");

                    b.HasKey("MercadoId");

                    b.HasIndex("ListaProdutoId");

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

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaDireta", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.ListaProduto", "ListaProduto")
                        .WithMany("DespesaDireta")
                        .HasForeignKey("ListaProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleFinanceiro.Models.DespesaFixa", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.ListaProduto", "ListaProduto")
                        .WithMany("DespesaFixa")
                        .HasForeignKey("ListaProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaDesejo", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.ListaProduto", "Produto")
                        .WithMany("Desejos")
                        .HasForeignKey("ListaProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleFinanceiro.Models.ListaMercado", b =>
                {
                    b.HasOne("ControleFinanceiro.Models.ListaProduto", "Produto")
                        .WithMany("Mercado")
                        .HasForeignKey("ListaProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
