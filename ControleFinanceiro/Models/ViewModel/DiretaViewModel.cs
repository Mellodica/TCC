using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models.ViewModel
{
    public class DiretaViewModel
    {

        public DespesaDireta DespesaDireta { get; set; }

        public ICollection<ListaProduto> ListaProdutos { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
        public ICollection<FormaPagamento> FormaPagamentos { get; set; }
        public ICollection<StatusCompra> StatusCompras { get; set; }
    }
}
