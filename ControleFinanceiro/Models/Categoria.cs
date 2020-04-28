using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string CategoriaNome { get; set; }

        public ICollection<ListaDesejo> ListaDesejos { get; set; } = new List<ListaDesejo>();
        public ICollection<ListaMercado> ListaMercados { get; set; } = new List<ListaMercado>();
        public ICollection<DespesaDireta> DespesaDiretas { get; set; } = new List<DespesaDireta>();
        public ICollection<DespesaFixa> DespesaFixas { get; set; } = new List<DespesaFixa>();


        public Categoria()
        {

        }


        public Categoria(int categoriaId, string categoriaNome)
        {
            Id = categoriaId;
            CategoriaNome = categoriaNome;
        }
    }
}
