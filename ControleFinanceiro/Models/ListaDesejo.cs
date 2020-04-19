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

        [Display(Name ="Valor")]
        public double DesejoValor { get; set; }
        [Display(Name = "Data para Compra")]
        public DateTime DesejoData { get; set; }
        [Display(Name = "Situação")]
        public StatusCompra StatusCompra { get; set; }
        public Categoria Categoria { get; set; }
        public FormaPagamento FormaPagamento { get; set; }


        public ListaDesejo()
        {

        }

        public ListaDesejo(int desejoId, double desejoValor, DateTime desejoData, StatusCompra statusCompra, Categoria categoria, FormaPagamento formaPagamento)
        {
            DesejoId = desejoId;
            DesejoValor = desejoValor;
            DesejoData = desejoData;
            StatusCompra = statusCompra;
            Categoria = categoria;
            FormaPagamento = formaPagamento;
            
        }
    }
}
