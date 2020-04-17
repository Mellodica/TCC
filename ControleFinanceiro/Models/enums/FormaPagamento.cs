using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public enum FormaPagamento
    {

        [Display(Name ="Cartão de Crédito")]
        CartaoCredito,
        [Display(Name ="Cartão de Débito")]
        CartaoDebito,
        [Display(Name = "Boleto")]
        Boleto,
        [Display(Name ="Parcelado")]
        Parcelado,
        [Display(Name ="Cartão Alimentação")]
        CartaoAlimentacao,
        [Display(Name = "Cartão Refeição")]
        CartaoRefeição,
        [Display(Name = "Dinheiro")]
        Dinheiro

    }
}
