using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControleFinanceiro.Models
{
    public class DespesaFixa
    {
        [Key]
        public int? DespFixaId { get; set; }

        [Display(Name = "Nome da Despesa")]
        [Required(ErrorMessage = "O nome da despesa é obrigatória", AllowEmptyStrings = false)]
        public string DespFixaNome { get; set; }
    
        [Display(Name = "Descrição da Despesa")]
        [Required(ErrorMessage = "A descrição da despesa é obrigatória", AllowEmptyStrings = false)]
        public string DespFixaDescricao { get; set; }

        [Display(Name = "Valor Da Despesa")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required]
        public double DespFixaValor { get; set; }

        [Display(Name = "Data da Despesa")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DespFixaData { get; set; }

        [Display(Name = "Situação da Despesa")]
        public StatusCompra StatusCompra { get; set; }
        public int StatusId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaId { get; set; }

        public DespesaFixa()
        {

        }
        public DespesaFixa(string despFixaNome, string despFixaDescricao, double despFixaValor, DateTime despFixaData, StatusCompra statusCompra, FormaPagamento formaPagamento, Categoria categoria)
        {
            DespFixaNome = despFixaNome;
            DespFixaDescricao = despFixaDescricao;
            DespFixaValor = despFixaValor;
            DespFixaData = despFixaData;
            StatusCompra = statusCompra;
            FormaPagamento = formaPagamento;
            Categoria = categoria;
        }
    }
}
