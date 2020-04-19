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
        public FormaPagamento FormaPagamento { get; set; }
        public Categoria Categoria { get; set; }

       
        public ListaMercado()
        {

        }

        public ListaMercado(int mercadoId, double mercadoValor, DateTime mercadoData, StatusCompra statusCompra, FormaPagamento formaPagamento, Categoria categoria)
        {
            MercadoId = mercadoId;
            MercadoValor = mercadoValor;
            MercadoData = mercadoData;
            StatusCompra = statusCompra;
            FormaPagamento = formaPagamento;
            Categoria = categoria;
        }
    }
}
