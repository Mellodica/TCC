
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class DespesaDireta
    {
        [Key]
        public int DespDirId { get; set; }

        [Display(Name = "Valor")]
        public double DespDirValor { get; set; }

        [Display(Name = "Data")]
        public DateTime DespDirData { get; set; }

        [Display(Name = "Situação da Compra")]
        public StatusCompra StatusCompra { get; set; }
        public int CategoId { get; set; }

        [Display(Name = "Forma Pagamento")]
        public FormaPagamento FormaPagamento { get; set; }
        public int FormId { get; set; }

        [Display(Name = "Produto")]
        public ListaProduto ListaProduto { get; set; }
        public int ProdId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }

   
        public DespesaDireta()
        {

        }

        public DespesaDireta(int despDirId, double despDirValor, DateTime despDirData, StatusCompra statusCompra, FormaPagamento formaPagamento, ListaProduto listaProduto, Categoria categoria)
        {
            DespDirId = despDirId;
            DespDirValor = despDirValor;
            DespDirData = despDirData;
            StatusCompra = statusCompra;
            FormaPagamento = formaPagamento;
            ListaProduto = listaProduto;
            Categoria = categoria;
        }
    }
}
