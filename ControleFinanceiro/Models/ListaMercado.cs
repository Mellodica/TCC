using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class ListaMercado
    {
        [Key]
        public int? MercadoId { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        public string MercadoNome { get; set; }

        [Display(Name = "Descrição Do Produto")]
        [Required(ErrorMessage = "A descrição do produto é obrigatório", AllowEmptyStrings = false)]
        public string MercadoDescricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Valor Do Produto")]
        public double MercadoValor { get; set; }

        [Display(Name = "Dia da Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MercadoData { get; set; }
     
        [Display(Name = "Situação da Compra")]
        public StatusCompra StatusCompra { get; set; }
        public int StatusId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaId { get; set; }      

        public ListaMercado()
        {

        }

        public ListaMercado(int mercadoId, string mercadoNome, string mercadoDescricao, double mercadoValor, DateTime mercadoData, StatusCompra statusCompra, int statId, FormaPagamento formaPagamento, int formId, Categoria categoria, int categoId, ListaProduto listaProduto, int prodId)
        {
            MercadoId = mercadoId;
            MercadoNome = mercadoNome;
            MercadoDescricao = mercadoDescricao;
            MercadoValor = mercadoValor;
            MercadoData = mercadoData;
            StatusCompra = statusCompra;          
            FormaPagamento = formaPagamento;          
            Categoria = categoria;
            



        }
    }
}
