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
    public class ServicoProduto
    {

        private readonly ControleFinanceiroContext _context;

        public ServicoProduto(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(ListaProduto produto)
        {
            _context.Add(produto);
           await  _context.SaveChangesAsync();
        }

        public List<ListaProduto> PegarTudo()
        {
            return _context.ListaProduto.OrderBy(p => p.ProdutoNome).ToList();
            //return _context.ListaProduto.OrderBy(p => p.ProdutoId).ToList();
        }

 
      

    }
}
