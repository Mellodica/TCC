using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class ListaProduto
    {
        [Key]
        public int Id { get; set; }
        public string ProdutoNome { get; set; }
        public string ProdutoDescricao { get; set; }
        public ICollection<ListaDesejo> Desejos { get; set; } = new List<ListaDesejo>();
        public ICollection<ListaMercado> Mercado { get; set; } = new List<ListaMercado>();
        public ICollection<DespesaDireta> DespesaDireta { get; set; } = new List<DespesaDireta>();
        public ICollection<DespesaFixa> DespesaFixa { get; set; } = new List<DespesaFixa>();

        public ListaProduto()
        {
        }

        public ListaProduto(int produtoId, string produtoNome, string produtoDescricao)
        {
            Id = produtoId;
            ProdutoNome = produtoNome;
            ProdutoDescricao = produtoDescricao;
        }
    }
}
