using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models.Infra
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome de usuario de acesso é Obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Login - Nome de Usuário")]
        public string UserName { get; set; }

        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "O primeiro nome é Obrigatório!", AllowEmptyStrings = false)]
        public string PrimeiroNome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O sobrenome é Obrigatório!", AllowEmptyStrings = false)]
        public string Sobrenome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "A data de nascimento é Obrigatória!", AllowEmptyStrings = false)]
        public DateTime? DataNascimento { get; set; }
        public string FotoMimeType { get; set; }
        public byte[] Foto { get; set; }


        [Required(ErrorMessage = "O email é Obrigatório!", AllowEmptyStrings = false)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} precisa ter ao menos {2} e no máximo {1} caracteres de cumprimento.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "Os valores informados para SENHA e CONFIRMAÇÃO não são iguais.")]
        public string ConfirmPassword { get; set; }
    }
}
