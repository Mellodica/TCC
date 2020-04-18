using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Login Login { get; set; }
        


    }
}
