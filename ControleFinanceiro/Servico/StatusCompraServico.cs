using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class StatusCompraServico
    {
        private readonly ControlePessoalContext _context;
        public StatusCompraServico(ControlePessoalContext context)
        {
            _context = context;
        }
        public async Task<List<StatusCompra>> EncontrarTudoStatusAsync()
        {
            return await _context.StatusCompras
                .OrderBy(x => x.StatusNome)
                .ToListAsync();
        }
        public IQueryable<StatusCompra> PegarStatusPorNome()
        {
            return _context.StatusCompras.OrderBy(c => c.StatusNome);
        }
        public async Task<StatusCompra> PegarStatusPorId(int id)
        {
            return await _context.StatusCompras
                .Include(p => p.DespesaDiretas)
                .Include(p => p.DespesaDiretas)
                .Include(l => l.ListaDesejos)
                .Include(m => m.ListaMercados)
                .SingleOrDefaultAsync(m => m.StatusId == id);
        }
    }
}
