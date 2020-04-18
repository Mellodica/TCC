using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Login Login { get; set; }

        public Usuario()
        {

        }

        public Usuario(int usuarioId, string primeiroNome, string segundoNome, DateTime dataNascimento)
        {
            UsuarioId = usuarioId;
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;
            DataNascimento = dataNascimento;
        }
    }
}
