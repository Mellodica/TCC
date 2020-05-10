using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class StatusCompraServico
    {

        private readonly ControleFinanceiroContext _context;

        public StatusCompraServico(ControleFinanceiroContext context)
        {
            _context = context;
        }


        public List<StatusCompra> PegarTudo()
        {
            return _context.StatusCompra.ToList();
        }
        
        
    }
}
