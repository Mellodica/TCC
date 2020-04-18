using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class Login
    {
        public int LoginId { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }


        [Display(Name = "Senha")]
        [Required]
        public string Senha { get; set; }


        public string Perfil { get; set; }

        public char Ativo { get; set; }
        public Usuario Usuario { get; set; }


        public Login()
        {

        }

     
    }
}
