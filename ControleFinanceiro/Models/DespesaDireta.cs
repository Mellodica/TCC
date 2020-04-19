
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
        public double DespDirValor { get; set; }
        public DateTime DespDirData { get; set; }
        public StatusCompra StatusCompra { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public ListaProduto ListaProduto { get; set; }
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
