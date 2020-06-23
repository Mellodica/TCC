using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class Salario
    {
        [Key]
        public int? SalarioId { get; set; }

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "Informe o valor do Sálario", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal SalarioValor { get; set; }

        [Display(Name = "Dia do Sálario")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SalarioData { get; set; }

        //public ICollection<UsuarioConta> Usuarios { get; set; } = new List<UsuarioConta>();

        public Salario()
        {

        }

        public Salario(int? salarioId, decimal salarioValor, DateTime salarioData)
        {
            SalarioId = salarioId;
            SalarioValor = salarioValor;
            SalarioData = salarioData;
        }
    }
}
