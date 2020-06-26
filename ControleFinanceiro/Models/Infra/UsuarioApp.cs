using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models.Infra
{
    public class UsuarioApp : IdentityUser
    {
        [Key]
        public int UsuarioId { get; set; }

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
        public string FotoMimeType { get; set; }
        public byte[] Foto { get; set; }

        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        public Salario Salario { get; set; }
        public int? SalarioId { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }

    }
}
