using ControleFinanceiro.Models.Infra;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class ServicoControles : List<ServicoControles>
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Salario> Salarios { get; set; }

        public ICollection<ProdutoMercado> Produtos { get; set; }
        public ICollection<ListaMercado> Mercados { get; set; }

        public ICollection<ListaDesejo> Desejos { get; set; }
        public ICollection<DespesaDireta> DespDiretas { get; set; }
        public ICollection<DespesaFixa> DespFixas { get; set; }

        public ICollection<Categoria> Categorias { get; set; }
        public ICollection<FormaPagamento> Formas { get; set; }
        public ICollection<StatusCompra> StatusCompras { get; set; }
        public ICollection<UsuarioApp> Usuarios { get; set; }
    }
}
