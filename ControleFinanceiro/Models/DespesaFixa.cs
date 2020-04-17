using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class DespesaFixa
    {

        public int DespFixaId { get; set; }
        public double DespFixaValor { get; set; }
        public DateTime DespFixaData { get; set; }
    }
}
