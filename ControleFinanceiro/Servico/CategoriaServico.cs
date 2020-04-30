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
    public class CategoriaServico
    {

        private readonly ControleFinanceiroContext _context;

        public CategoriaServico(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> EncontrarTudo()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Categoria> EncontraPorId(int id)
        {
            return await _context.Categoria.FirstOrDefaultAsync (item => item.Id == id);
        }

        public void DeleteConfirma(int id)
        {
            var categoria = _context.Categoria.Find(id);
             _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            
        }

        public async Task Atualizar(Categoria obj)
        {
            if (!_context.Categoria.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Categoria não encontrada!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }

           /* var categoria = _context.Categoria (id);
            if (categoria == null)
            {
                return NotFound();
            }
            */
               

        }


        public async Task Insert(Categoria obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public List<Categoria> PegarTudo()
        {
            return _context.Categoria.OrderBy(i => i.CategoriaNome).ToList();
        }
        
    }
}
