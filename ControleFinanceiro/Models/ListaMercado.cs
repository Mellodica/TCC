using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models
{
    public class ListaMercado
    {
        [Key]
        public int MercadoId { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        public string MercadoNome { get; set; }

        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MercadoValor { get; set; }

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

        public virtual List<ProdutoMercado> Produtos { get; set; }

        public ListaMercado()
        {

        }

        public ListaMercado(int mercadoId, string mercadoNome, decimal mercadoValor, DateTime mercadoData, StatusCompra statusCompra, Categoria categoria, FormaPagamento formaPagamento)
        {
            MercadoId = mercadoId;
            MercadoNome = mercadoNome;
            MercadoValor = mercadoValor;
            MercadoData = mercadoData;
            StatusCompra = statusCompra;
            Categoria = categoria;
            FormaPagamento = formaPagamento;
        }
    }
}
