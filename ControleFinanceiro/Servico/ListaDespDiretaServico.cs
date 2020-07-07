using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Servico.Erros;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class ListaDespDiretaServico
    {
        private readonly ControlePessoalContext _context;
        public ListaDespDiretaServico(ControlePessoalContext context)
        {
            _context = context;
        }
        public async Task<DespesaDireta> PegarDiretaPorIdAsync(int? id)
        {
            var direta = await _context.DespDiretas.FirstOrDefaultAsync(m => m.DespDirId == id);
            _context.Categorias.Where(i => direta.CategoriaId == i.CategoriaId).Load();
            _context.Formas.Where(i => direta.FormaId == i.FormaId).Load();
            _context.StatusCompras.Where(i => direta.StatusId == i.StatusId).Load();
            return direta;
        }
        public async Task AtualizarAsync(DespesaDireta direta)
        {
            bool hasAny = await _context.DespDiretas.AnyAsync(x => x.DespDirId == direta.DespDirId);
            if (!hasAny)
            {
                throw new NotFoundException("não encontrado");
            }
            try
            {
                _context.Update(direta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        public async Task<DespesaDireta> RegistrarDespDireta(DespesaDireta direta)
        {
            if (direta.DespDirId == null)
            {
                _context.DespDiretas.Add(direta);
            }
            else
            {
                _context.Update(direta);
            }
            await _context.SaveChangesAsync();
            return direta;
        }
        public async Task<DespesaDireta> DeletarDiretaPorId(int? id)
        {
            DespesaDireta direta = await PegarDiretaPorIdAsync(id.Value);
            _context.DespDiretas.Remove(direta);
            await _context.SaveChangesAsync();
            return direta;
        }
    }
}
