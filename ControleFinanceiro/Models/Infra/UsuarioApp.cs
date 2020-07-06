using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models.Infra
{
    public class UsuarioApp : IdentityUser
    {

        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "O primeiro nome é Obrigatório!", AllowEmptyStrings = false)]
        public string PrimeiroNome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O sobrenome é Obrigatório!", AllowEmptyStrings = false)]
        public string Sobrenome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required]
        public DateTime? DataNascimento { get; set; }
    }
}
