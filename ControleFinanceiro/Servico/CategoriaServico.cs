using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class CategoriaServico
    {  
        private readonly ControlePessoalContext _context;
        public CategoriaServico(ControlePessoalContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> EncontrarTudoCategoriasAsync()
        {
            return await _context.Categorias.OrderBy(i => i.CategoriaNome).ToListAsync();
        }
        public IQueryable<Categoria> PegarCategoriasPorNome()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaNome);
        }
        public async Task<Categoria> PegarCategoriaPorIdAsync(int id)
        {
            return await _context.Categorias
                .Include(p => p.DespesaFixas)
                .Include(p => p.DespesaDiretas)
                .Include(l => l.ListaDesejos)
                .Include(m => m.ListaMercados)
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
        }
    }
}
