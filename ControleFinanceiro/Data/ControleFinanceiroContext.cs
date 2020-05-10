using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Data
{
    public class ControleFinanceiroContext : DbContext
    {
        public ControleFinanceiroContext (DbContextOptions<ControleFinanceiroContext> options)
            : base(options)
        {
        }

        public DbSet<ListaProduto> ListaProduto { get; set; }

        public DbSet<ListaMercado> ListaMercado { get; set; }

        public DbSet<DespesaDireta> DespesaDireta { get; set; }

        public DbSet<DespesaFixa> DespesaFixa { get; set; }

        public DbSet<ListaDesejo> ListaDesejo { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<StatusCompra> StatusCompra { get; set; }
    }
}
