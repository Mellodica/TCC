using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class ListaProduto
    {
        [Key]
        public int? ProdutoId { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        public string ProdutoNome { get; set; }

        [Display(Name = "Descrição do Produto")]
        [Required(ErrorMessage = "A descrição do produto é obrigatório", AllowEmptyStrings = false)]
        public string ProdutoDescricao { get; set; }

        [Display(Name = "Situação da Compra")]
        public StatusCompra StatusCompra { get; set; }
        public int StatusId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaId { get; set; }

        public ListaProduto()
        {
        }

        public ListaProduto(int produtoId, string produtoNome, string produtoDescricao, DateTime desejoData, StatusCompra statusCompra, Categoria categoria, FormaPagamento formaPagamento)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            ProdutoDescricao = produtoDescricao;
            StatusCompra = statusCompra;
            FormaPagamento = formaPagamento;
            Categoria = categoria;
        }
    }
}
