using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
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

        public List<ListaProduto> EncontrarTudo()
        {
            return _context.ListaProduto.OrderBy(i => i.ProdutoNome).ToList();
        }

        public void Insert(ListaProduto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }
        public List<ListaProduto> PegarTudo()
        {
            return _context.ListaProduto.OrderBy(i => i.ProdutoNome).ToList();
        }

    }
}
