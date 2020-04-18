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

        public DbSet<ControleFinanceiro.Models.ListaProduto> ListaProduto { get; set; }

        public DbSet<ControleFinanceiro.Models.ListaMercado> ListaMercado { get; set; }

        public DbSet<ControleFinanceiro.Models.DespesaDireta> DespesaDireta { get; set; }

        public DbSet<ControleFinanceiro.Models.DespesaFixa> DespesaFixa { get; set; }

        public DbSet<ControleFinanceiro.Models.ListaDesejo> ListaDesejo { get; set; }
    }
}
