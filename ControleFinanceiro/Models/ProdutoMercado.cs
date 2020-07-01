using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models
{
    public class ProdutoMercado
    {
        [Key]
        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public ListaMercado ListaMercado { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        public string ProdutoNome { get; set; }

        [Display(Name = "Valor do Produto")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorUnitario { get; set; }
    }
}
