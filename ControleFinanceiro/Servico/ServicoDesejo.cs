using ControleFinanceiro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class ServicoDesejo
    {

        private readonly ControleFinanceiroContext _context;

        public ServicoDesejo(ControleFinanceiroContext context)
        {
            _context = context;
        }
    }
}
