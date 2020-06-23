using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Servico.Erros;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class ListaMercadoServico
    {
        private readonly ControlePessoalContext _context;

        public ListaMercadoServico(ControlePessoalContext context)
        {
            _context = context;
        }

        public async Task<List<ListaMercado>> EncontrarTudoMercadoAsync()
        {
            return await _context.Mercados.OrderBy(x => x.MercadoNome).ToListAsync();
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<ListaMercado> PegarMercadoPorNome()
        {
            return _context.Mercados
                .Include(i => i.Categoria)
                .Include(i => i.FormaPagamento)
                .Include(i => i.StatusCompra)
                .OrderBy(p => p.MercadoNome);
        }

        public async Task<ListaMercado> PegarMercadoPorIdAsync(int? id)
        {
            var mercado = await _context.Mercados.FirstOrDefaultAsync(m => m.MercadoId == id);
            _context.Categorias.Where(i => mercado.CategoriaId == i.CategoriaId).Load();
            _context.Formas.Where(i => mercado.FormaId == i.FormaId).Load();
            _context.StatusCompras.Where(i => mercado.StatusId == i.StatusId).Load();
            return mercado;
        }

        public async Task AtualizarAsync(ListaMercado mercado)
        {
            bool hasAny = await _context.Desejos.AnyAsync(x => x.DesejoId == mercado.MercadoId);
            if (!hasAny)
            {
                throw new NotFoundException("não encontrado");
            }
            try
            {
                _context.Update(mercado);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<ListaMercado> RegistrarMercado(ListaMercado mercado)
        {
            if (mercado.MercadoId == null)
            {
                _context.Mercados.Add(mercado);
            }
            else
            {
                _context.Update(mercado);
            }
            await _context.SaveChangesAsync();
            return mercado;
        }

        public async Task<ListaMercado> DeletarMercadoPorId(int? id)
        {
            ListaMercado mercado = await PegarMercadoPorIdAsync(id.Value);
            _context.Mercados.Remove(mercado);
            await _context.SaveChangesAsync();
            return mercado;
        }
    }
}
