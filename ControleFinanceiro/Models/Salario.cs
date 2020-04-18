using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class Salario
    {
        [Key]
        public int SalarioId { get; set; }
        public decimal SalarioValor { get; set; }
        public DateTime SalarioData { get; set; }
        public Usuario Usuario { get; set; }



        public Salario()
        {

        }

        public Salario(int salarioId, decimal salarioValor, DateTime salarioData, Usuario usuario)
        {
            SalarioId = salarioId;
            SalarioValor = salarioValor;
            SalarioData = salarioData;
            Usuario = usuario;
        }
    }
}
