using ControleFinanceiro.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class ListaMercado
    {
        [Key]
        public int MercadoId { get; set; }
        public double MercadoValor { get; set; }
        public DateTime MercadoData { get; set; }
        public ListaProduto Produto { get; set; }
        public int ListaProdutoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaPagamentoId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        

        public ListaMercado()
        {

        }

        public ListaMercado(int mercadoId, double mercadoValor, DateTime mercadoData, ListaProduto produto, int listaProdutoId, FormaPagamento formaPagamento, int formaPagamentoId, Status status, int statusId)
        {
            MercadoId = mercadoId;
            MercadoValor = mercadoValor;
            MercadoData = mercadoData;
            Produto = produto;
            ListaProdutoId = listaProdutoId;
            FormaPagamento = formaPagamento;
            FormaPagamentoId = formaPagamentoId;
            Status = status;
            StatusId = statusId;
        }
    }
}
