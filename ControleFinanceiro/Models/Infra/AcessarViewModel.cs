using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models.Infra
{
    public class AcessarViewModel
    {
        [Required]
        [Display(Name = "Login - Nome de Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        //P@ssw0rd -- senha precisa de uma letra maiúscula, um número, e um caractere especial.

        [Display(Name = "Lembrar de mim?")]
        public bool LembrarDeMim { get; set; }
    }
}
