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
        
        [Display(Name = "Situação")]
        public StatusCompra StatusCompra { get; set; }
        public int StatId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int FormId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoId { get; set; }
        public ListaProduto ListaProduto { get; set; }
        public int ProdId { get; set; }


        public ListaMercado()
        {

        }

        public ListaMercado(int mercadoId, double mercadoValor, DateTime mercadoData, StatusCompra statusCompra, int statId, FormaPagamento formaPagamento, int formId, Categoria categoria, int categoId, ListaProduto listaProduto, int prodId)
        {
            MercadoId = mercadoId;
            MercadoValor = mercadoValor;
            MercadoData = mercadoData;
            StatusCompra = statusCompra;
            StatId = statId;
            FormaPagamento = formaPagamento;
            FormId = formId;
            Categoria = categoria;
            CategoId = categoId;
            ListaProduto = listaProduto;
            ProdId = prodId;
        }
    }
}
