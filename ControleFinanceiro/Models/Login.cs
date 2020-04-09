using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class Login
    {
        public long? LoginId { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
