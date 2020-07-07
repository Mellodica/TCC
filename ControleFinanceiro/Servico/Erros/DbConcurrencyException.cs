using System;

namespace ControleFinanceiro.Servico.Erros
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}
