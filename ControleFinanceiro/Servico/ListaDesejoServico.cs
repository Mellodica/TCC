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
