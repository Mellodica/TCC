using ControleFinanceiro.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class ListaDesejo
    {

        public int DesejoId { get; set; }
        public double DesejoValor { get; set; }
        public DateTime DesejoData { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }        
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaPagamentoId { get; set; }
        public ListaProduto Produto { get; set; }
        public int ListaProdutoId { get; set; }

        public ListaDesejo()
        {

        }


    }
}
