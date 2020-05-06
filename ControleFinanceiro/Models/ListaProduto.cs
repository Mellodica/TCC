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

        [Display(Name = "Nome do Produto")]
        public string ProdutoNome { get; set; }

        [Display(Name = "Descrição do Produto")]
        public string ProdutoDescricao { get; set; }

        public ICollection<ListaDesejo> Desejos { get; set; } = new List<ListaDesejo>();
        public ICollection<ListaMercado> Mercados { get; set; } = new List<ListaMercado>();
        public ICollection<DespesaDireta> DespesaDiretas { get; set; } = new List<DespesaDireta>();
        public ICollection<DespesaFixa> DespesaFixas { get; set; } = new List<DespesaFixa>();

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
