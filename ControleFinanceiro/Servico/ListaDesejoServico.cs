using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Servico.Erros;

namespace ControleFinanceiro.Servico
{
    public class ListaDesejoServico
    {
        private readonly ControlePessoalContext _context;

        public ListaDesejoServico(ControlePessoalContext context)
        {
            _context = context;
        }

        public async Task<List<ListaDesejo>> EncontrarTudoDesejoAsync()
        {
            return await _context.Desejos.OrderBy(x => x.DesejoNome).ToListAsync();
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<ListaDesejo> PegarDesejoPorNome()
        {
            return _context.Desejos
                .Include(i => i.Categoria)
                .Include(i => i.FormaPagamento)
                .Include(i => i.StatusCompra)
                .OrderBy(p => p.DesejoNome);
        }

        public async Task<ListaDesejo> PegarDesejoPorIdAsync(int? id)
        {
            var desejo = await _context.Desejos.FirstOrDefaultAsync(m => m.DesejoId == id);
            _context.Categorias.Where(i => desejo.CategoriaId == i.CategoriaId).Load();
            _context.Formas.Where(i => desejo.FormaId == i.FormaId).Load();
            _context.StatusCompras.Where(i => desejo.StatusId == i.StatusId).Load();
            return desejo;
        }

        public async Task AtualizarAsync(ListaDesejo desejo)
        {
            bool hasAny = await _context.Desejos.AnyAsync(x => x.DesejoId == desejo.DesejoId);
            if (!hasAny)
            {
                throw new NotFoundException("não encontrado");
            }
            try
            {
                _context.Update(desejo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<ListaDesejo> RegistrarDesejo(ListaDesejo desejo)
        {
            if (desejo.DesejoId == null)
            {
                _context.Desejos.Add(desejo);
            }
            else
            {
                _context.Update(desejo);
            }
            await _context.SaveChangesAsync();
            return desejo;
        }

        public async Task<ListaDesejo> DeletarDesejoPorId(int? id)
        {
            ListaDesejo desejo = await PegarDesejoPorIdAsync(id.Value);
            _context.Desejos.Remove(desejo);
            await _context.SaveChangesAsync();
            return desejo;
        }
    }
}
