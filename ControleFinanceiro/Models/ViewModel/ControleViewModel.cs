using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models.ViewModel
{
    public class ControleViewModel
    {

        public ICollection<DespesaDireta> DespesaDiretas { get; set; }
        public ICollection<DespesaFixa> DespesaFixas { get; set; }
        public ICollection<ListaDesejo> ListaDesejos { get; set; }
        public ICollection<ListaMercado> ListaMercados { get; set; }
        public Usuario Usuario { get; set; }
    }
}
