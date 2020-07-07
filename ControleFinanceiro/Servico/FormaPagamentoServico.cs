using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class FormaPagamentoServico
    {
        private readonly ControlePessoalContext _context;
        public FormaPagamentoServico(ControlePessoalContext context)
        {
            _context = context;
        }
        public async Task<List<FormaPagamento>> EncontrarTudoFormasAsync()
        {          
            return await _context.Formas.OrderBy(x => x.FormaNome).ToListAsync();
        }
        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<FormaPagamento> PegarFormaPorNome()
        {
            return _context.Formas.OrderBy(c => c.FormaNome);
        }
        public async Task<FormaPagamento> PegarFormaPorId(int id)
        {
            return await _context.Formas
                .Include(p => p.DespesaDiretas)
                .Include(p => p.DespesaFixas)
                .Include(l => l.ListaDesejos)
                .Include(m => m.ListaMercados)
                .FirstOrDefaultAsync(m => m.FormaId == id);
        }
    }
}
