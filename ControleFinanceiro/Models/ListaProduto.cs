using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class ListaProduto
    {

        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public string ProdutoDescricao { get; set; }

        public ListaProduto()
        {
        }

        public ListaProduto(int produtoId, string produtoNome, string produtoDescricao)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            ProdutoDescricao = produtoDescricao;
        }
    }
}
