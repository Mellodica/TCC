using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public enum Categoria : int
    {
        [Display(Name = "Acessórios")]
        Acessorios,
        [Display(Name = "Bônus")]
        Bonus,
        [Display(Name = "Cheque Especial")]
        ChequeEspecial,
        [Display(Name = "Comidas e Bebidas")]
        ComidasBebidas,
        [Display(Name = "Contas Residênciais")]
        ContasResisdenciais,
        [Display(Name = "Crediário")]
        Crediario,
        [Display(Name ="Crédito Consiginado")]
        CreditoConsignado,
        [Display(Name ="Cuidados Pessoais")]
        CuidadosPessoais,
        [Display(Name ="Despesas com Trabalho")]
        DespesasTrabalho,
        [Display(Name ="Educação")]
        Educacao,
        [Display(Name ="Eletrônicos")]
        Eletronicos,
        [Display(Name ="Eletrodomésticos")]
        Eletrodomesticos,
        [Display(Name ="Empréstimo")]
        Emprestimo,
        [Display(Name ="Encargos")]
        Encargos,
        [Display(Name ="Família e Filhos")]
        FamiliaFilhos,
        [Display(Name ="FGTS")]
        FGTS,
        [Display(Name ="Imposto")]
        Imposto,
        [Display(Name ="Investimentos")]
        Investimentos,
        [Display(Name ="Jogos Eletrônicos")]
        JogosEletronicos,
        [Display(Name ="Juros")]
        Juros,
        [Display(Name ="Lazer e Hobbie")]
        LazerHobbie,
        [Display(Name ="Mercado")]
        Mercado,
        [Display(Name ="Moradia")]
        Moradia,
        [Display(Name ="Outras Rendas")]
        OutrasRendas,
        [Display(Name ="Outros Gastos")]
        OutrosGastos,
        [Display(Name = "Mascote")]
        Mascote,
        [Display(Name ="Presentes e Doação")]
        PresentesDoacao,
        [Display(Name ="Rendimentos")]
        Rendimentos,
        [Display(Name ="Resgate")]
        Resgate,
        [Display(Name ="Salário")]
        Salario,
        [Display(Name = "Saques")]
        Saques,
        [Display(Name ="Saúde")]
        Saude,
        [Display(Name ="Serviços")]
        Servicos,
        [Display(Name ="Telefonia / Internet / TV")]
        TelefoneInternetTV,
        [Display(Name ="Transferência")]
        Transferencia,
        [Display(Name = "Transporte")]
        Transporte,
        [Display(Name = "Vestuário")]
        Vestuário

    }
}
