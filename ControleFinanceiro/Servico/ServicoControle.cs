using ControleFinanceiro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class ServicoControle
    {

        private readonly ControleFinanceiroContext _context;

        public ServicoControle(ControleFinanceiroContext context)
        {
            _context = context;
        }
    }
}
