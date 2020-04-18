using ControleFinanceiro.Models.enums;
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
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaPagamentoId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public ListaProduto ListaProduto { get; set; }
        public int ListaProdutoId { get; set; }

        public DespesaDireta()
        {

        }

        public DespesaDireta(int despDirId, double despDirValor, DateTime despDirData, Status status, int statusId, FormaPagamento formaPagamento, int formaPagamentoId, Categoria categoria, int categoriaId, ListaProduto listaProduto, int listaProdutoId)
        {
            DespDirId = despDirId;
            DespDirValor = despDirValor;
            DespDirData = despDirData;
            Status = status;
            StatusId = statusId;
            FormaPagamento = formaPagamento;
            FormaPagamentoId = formaPagamentoId;
            Categoria = categoria;
            CategoriaId = categoriaId;
            ListaProduto = listaProduto;
            ListaProdutoId = listaProdutoId;
        }
    }
}
