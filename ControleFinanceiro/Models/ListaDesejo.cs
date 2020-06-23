using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class ListaDesejo
    {

        [Key]
        public int? DesejoId { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Valor Do Produto")]
        [Required(ErrorMessage = "Informe o preço do produto desejado", AllowEmptyStrings = false)]
        public double DesejoValor { get; set; }

        [Display(Name = "Nome do Desejo")]
        [Required(ErrorMessage = "O nome do desejo é obrigatório", AllowEmptyStrings = false)]
        public string DesejoNome { get; set; }

        [Display(Name = "Descrição do Desejo")]
        [Required(ErrorMessage = "A descrição do desejo é obrigatório", AllowEmptyStrings = false)]
        public string DesejoDescricao { get; set; }

        [Display(Name = "Previsão de Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DesejoData { get; set; }

        [Display(Name = "Ir Para loja")]
        public string DesejoLoja { get; set; }

        [Display(Name = "Situação da Compra")]
        public StatusCompra StatusCompra { get; set; }
        public int StatusId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaId { get; set; }


        public ListaDesejo()
        {

        }

        public ListaDesejo(int desejoId, string desejoNome,string desejoDescricao, double desejoValor, DateTime desejoData, StatusCompra statusCompra, Categoria categoria, FormaPagamento formaPagamento)
        {
            DesejoId = desejoId;
            DesejoNome = desejoNome;
            DesejoDescricao = desejoDescricao;
            DesejoValor = desejoValor;
            DesejoData = desejoData;
            StatusCompra = statusCompra;
            Categoria = categoria;
            FormaPagamento = formaPagamento;        
        }
    }
}
