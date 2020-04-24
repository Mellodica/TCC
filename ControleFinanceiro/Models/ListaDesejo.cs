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

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Valor Do Produto")]
        public double DesejoValor { get; set; }


        [Display(Name = "Previsão de Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DesejoData { get; set; }


        [Display(Name = "Situação da Compra")]
        public StatusCompra StatusCompra { get; set; }
        public int StatId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoId { get; set; }


        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public int FormId { get; set; }

        [Display(Name = "Produto")]
        public ListaProduto ListaProduto { get; set; }
        public int ProdId { get; set; }


        public ListaDesejo()
        {

        }

        public ListaDesejo(int desejoId, int v, string v1, double desejoValor, DateTime desejoData, StatusCompra statusCompra, Categoria categoria, FormaPagamento formaPagamento)
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
