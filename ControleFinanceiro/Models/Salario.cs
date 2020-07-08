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

        [Display(Name = "Nome do Provento")]
        [Required(ErrorMessage = "O nome do salario é obrigatório", AllowEmptyStrings = false)]
        public string SalarioNome { get; set; }

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "Informe o valor do Sálario", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalarioValor { get; set; }

        [Display(Name = "Dia da Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SalarioData { get; set; }

        public Salario()
        {

        }
        public Salario(string salarioNome,decimal salarioValor, DateTime salarioData)
        {
            SalarioNome = salarioNome;
            SalarioValor = salarioValor;
            SalarioData = salarioData;
        }
    }
}
