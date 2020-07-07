using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControleFinanceiro.Models
{
    public class DespesaDireta
    {
        [Key]
        public int? DespDirId { get; set; }

        [Display(Name = "Nome da Despesa")]
        [Required(ErrorMessage = "O nome da despesa é obrigatória", AllowEmptyStrings = false)]
        public string DespesaDirNome { get; set; }

        [Display(Name = "Descrição da Despesa")]
        [Required(ErrorMessage = "A descrição da despesa é obrigatória", AllowEmptyStrings = false)]
        public string DespesaDirDescricao { get; set; }

        [Display(Name = "Valor Da Despesa")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required]
        public double DespDirValor { get; set; }

        [Display(Name = "Data da Despesa")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DespDirData { get; set; }

        [Display(Name = "Situação da Despesa")]
        public StatusCompra StatusCompra { get; set; }
        public int StatusId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Display(Name = "Método de Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaId { get; set; }

        public DespesaDireta()
        {

        }

        public DespesaDireta(int despDirId, string despDirNome, string despDirDescricao, double despDirValor, DateTime despDirData, StatusCompra statusCompra, FormaPagamento formaPagamento, Categoria categoria)
        {
            DespDirId = despDirId;
            DespesaDirNome = despDirNome;
            DespesaDirDescricao = despDirDescricao;
            DespDirValor = despDirValor;
            DespDirData = despDirData;
            StatusCompra = statusCompra;
            FormaPagamento = formaPagamento;
            Categoria = categoria;
        }
    }
}
