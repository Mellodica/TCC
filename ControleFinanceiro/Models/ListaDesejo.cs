using ControleFinanceiro.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class ListaDesejo
    {

        [Key]
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

        public ListaDesejo(int desejoId, double desejoValor, DateTime desejoData, Status status, int statusId, FormaPagamento formaPagamento, int formaPagamentoId, ListaProduto produto, int listaProdutoId)
        {
            DesejoId = desejoId;
            DesejoValor = desejoValor;
            DesejoData = desejoData;
            Status = status;
            StatusId = statusId;
            FormaPagamento = formaPagamento;
            FormaPagamentoId = formaPagamentoId;
            Produto = produto;
            ListaProdutoId = listaProdutoId;
        }
    }
}
