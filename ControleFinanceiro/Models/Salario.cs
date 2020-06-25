using ControleFinanceiro.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models
{
    public class Salario
    {
        [Key]
        public int? SalarioId { get; set; }

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "Informe o valor do Sálario", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalarioValor { get; set; }

        [Display(Name = "Dia do Sálario")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]   
        [NotMapped]
        public DateTime SalarioData { get; set; }

        public ICollection<UsuarioApp> Usuarios { get; set; } = new List<UsuarioApp>();

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
