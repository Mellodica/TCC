using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class FormaPagamentoServico
    {

        private readonly ControleFinanceiroContext _context;

        public FormaPagamentoServico(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public List<FormaPagamento> PegarTudo()
        {
            return _context.FormaPagamento.ToList();
        }
    }
}
