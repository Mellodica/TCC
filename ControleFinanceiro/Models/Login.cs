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
        [Required(ErrorMessage = "Digite seu {0}")]
        //[StringLength(60, MinimumLength = 10, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.")]
        public string Email { get; set; }


        [Display(Name = "Senha")]
        [Required(ErrorMessage ="Digite sua {0}")]
        public string Senha { get; set; }


        public string Perfil { get; set; }

        public char Ativo { get; set; }

        [Display(Name ="Usuário")]
        public Usuario Usuario { get; set; }


        public Login()
        {

        }

        public Login(int loginId, string email, string senha, string perfil, char ativo, Usuario usuario)
        {
            LoginId = loginId;
            Email = email;
            Senha = senha;
            Perfil = perfil;
            Ativo = ativo;
            Usuario = usuario;
        }
    }
}
