using ControleFinanceiro.Models;
using ControleFinanceiro.Models.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Data
{

    public class ControlePessoalContext : IdentityDbContext<UsuarioApp>
    {
        public ControlePessoalContext(DbContextOptions<ControlePessoalContext> options)
            : base(options)
        {
        }

        public DbSet<Salario> Salarios { get; set; }

        public DbSet<ListaProduto> Produtos { get; set; }

        public DbSet<ListaDesejo> Desejos { get; set; }
        public DbSet<ListaMercado> Mercados { get; set; }
        public DbSet<DespesaDireta> DespDiretas { get; set; }
        public DbSet<DespesaFixa> DespFixas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<FormaPagamento> Formas { get; set; }
        public DbSet<StatusCompra> StatusCompras { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ControleDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        */
    }
    
}
