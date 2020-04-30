using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class DespesaFixa
    {

        [Key]
        public int DespFixaId { get; set; }
        public double DespFixaValor { get; set; }
        public DateTime DespFixaData { get; set; }
        public StatusCompra StatusCompra { get; set; }
        public int StatId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int FormId { get; set; }
        public ListaProduto ListaProduto { get; set; }
        public int ProdId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoId { get; set; }


        public DespesaFixa()
        {

        }

        public DespesaFixa(int despFixaId, double despFixaValor, DateTime despFixaData, StatusCompra statusCompra, FormaPagamento formaPagamento, ListaProduto listaProduto, Categoria categoria)
        {
            DespFixaId = despFixaId;
            DespFixaValor = despFixaValor;
            DespFixaData = despFixaData;
            StatusCompra = statusCompra;
            FormaPagamento = formaPagamento;
            ListaProduto = listaProduto;
            Categoria = categoria;
        }
    }
}
