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
    public class SalarioServico
    {
        private readonly ControlePessoalContext _context;
        public SalarioServico(ControlePessoalContext context)
        {
            _context = context;
        }
        public IQueryable<Salario> PegarSalarioPorNome()
        {
            return _context.Salarios
                .OrderBy(p => p.SalarioNome);
        }
        public async Task<List<Salario>> EncontrarPorDataAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Salarios select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.SalarioData >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.SalarioData <= maxDate.Value);
            }
            return await result
                .OrderByDescending(x => x.SalarioData)
                .ToListAsync();
        }
        public async Task<Salario> PegarSalarioPorIdAsync(int? id)
        {
            var salario = await _context.Salarios.FirstOrDefaultAsync(m => m.SalarioId == id);
            return salario;
        }
        public async Task AtualizarAsync(Salario salario)
        {
            bool hasAny = await _context.Salarios.AnyAsync(x => x.SalarioId == salario.SalarioId);
            if (!hasAny)
            {
                throw new NotFoundException("não encontrado");
            }
            try
            {
                _context.Update(salario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        public async Task<Salario> RegistrarSalario(Salario salario)
        {
            if (salario.SalarioId == null)
            {
                _context.Salarios.Add(salario);
            }
            else
            {
                _context.Update(salario);
            }
            await _context.SaveChangesAsync();
            return salario;
        }
        public async Task<Salario> DeletarSalarioPorId(int? id)
        {
            Salario salario = await PegarSalarioPorIdAsync(id.Value);
            _context.Salarios.Remove(salario);
            await _context.SaveChangesAsync();
            return salario;
        }
    }
}
