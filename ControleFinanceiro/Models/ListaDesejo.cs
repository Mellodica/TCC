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
        [Display(Name ="Valor Do Produto")]
        public double DesejoValor { get; set; }
        [Display(Name = "Previsão de Compra")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0{dd:MM:yyyy")]
        public DateTime DesejoData { get; set; }
        [Display(Name = "Situação da Compra")]
        public StatusCompra StatusCompra { get; set; }
        public int StatusId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaId { get; set; }


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
