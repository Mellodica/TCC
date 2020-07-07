using ControleFinanceiro.Data;

namespace ControleFinanceiro.Servico
{
    public class ServicoControle
    {
        private readonly ControlePessoalContext _context;
        public ServicoControle(ControlePessoalContext context)
        {
            _context = context;
        }
    }
}
