using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Servico.Erros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class ListaDespFixaServico
    {
        private readonly ControlePessoalContext _context;

        public ListaDespFixaServico(ControlePessoalContext context)
        {
            _context = context;
        }

        public async Task<List<DespesaFixa>> EncontrarTudoFixaAsync()
        {
            return await _context.DespFixas.OrderBy(x => x.DespFixaNome).ToListAsync();
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<DespesaFixa> PegarFixaPorNome()
        {
            return _context.DespFixas
                .Include(i => i.Categoria)
                .Include(i => i.FormaPagamento)
                .Include(i => i.StatusCompra)
                .OrderBy(p => p.DespFixaNome);
        }

        public async Task<DespesaFixa> PegarFixaPorIdAsync(int? id)
        {
            var fixa = await _context.DespFixas.FirstOrDefaultAsync(m => m.DespFixaId == id);
            _context.Categorias.Where(i => fixa.CategoriaId == i.CategoriaId).Load();
            _context.Formas.Where(i => fixa.FormaId == i.FormaId).Load();
            _context.StatusCompras.Where(i => fixa.StatusId == i.StatusId).Load();
            return fixa;
        }

        public async Task AtualizarAsync(DespesaFixa mercado)
        {
            bool hasAny = await _context.DespFixas.AnyAsync(x => x.DespFixaId == mercado.DespFixaId);
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

        public async Task<DespesaFixa> RegistrarDespesaFixa(DespesaFixa fixa)
        {
            if (fixa.DespFixaId == null)
            {
                _context.DespFixas.Add(fixa);
            }
            else
            {
                _context.Update(fixa);
            }
            await _context.SaveChangesAsync();
            return fixa;
        }

        public async Task<DespesaFixa> DeletarFixaPorId(int? id)
        {
            DespesaFixa fixa = await PegarFixaPorIdAsync(id.Value);
            _context.DespFixas.Remove(fixa);
            await _context.SaveChangesAsync();
            return fixa;
        }
    }
}
