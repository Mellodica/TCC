using System;

namespace ControleFinanceiro.Servico.Erros
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {

        }
    }
}
