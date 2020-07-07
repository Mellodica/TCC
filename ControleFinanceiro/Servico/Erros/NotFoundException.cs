using System;

namespace ControleFinanceiro.Servico.Erros
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
