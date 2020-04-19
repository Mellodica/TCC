using ControleFinanceiro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Servico
{
    public class SeedingService
    {
        private ControleFinanceiroContext _context;

        public SeedingService(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public void Seed()
        {
             if(_context.Categoria.Any() || _context.FormaPagamento.Any() || _context.StatusCompra.Any())
            {
                return; //Já tem dados.
            }

            StatusCompra s1 = new StatusCompra(new int(), "Pendente");
            StatusCompra s2 = new StatusCompra(new int(), "Comprador");
            StatusCompra s3 = new StatusCompra(new int(), "Cancelado");


            FormaPagamento f1 = new FormaPagamento(new int(), "Cartão de Crédito");
            FormaPagamento f2 = new FormaPagamento(new int(), "Cartão de Débito");
            FormaPagamento f3 = new FormaPagamento(new int(), "Boleto");
            FormaPagamento f4 = new FormaPagamento(new int(), "Parcelado");
            FormaPagamento f5 = new FormaPagamento(new int(), "Cartão Refeição");
            FormaPagamento f6 = new FormaPagamento(new int(), "Cartão Alimentação");


            Categoria c1 = new Categoria(new int(), "Acessórios");
            Categoria c2 = new Categoria(new int(), "Bônus");
            Categoria c3 = new Categoria(new int(), "Cheque Especial");
            Categoria c4 = new Categoria(new int(), "Comidas e Bebidas");
            Categoria c5 = new Categoria(new int(), "Contas Residenciais");
            Categoria c6 = new Categoria(new int(), "Crediário");
            Categoria c7 = new Categoria(new int(), "Crédito Consignado");
            Categoria c8 = new Categoria(new int(), "Cuidados Pessoais");
            Categoria c9 = new Categoria(new int(), "Despesas com Trabalho");
            Categoria c10 = new Categoria(new int(), "Educação");
            Categoria c11 = new Categoria(new int(), "Eletrônico");
            Categoria c12 = new Categoria(new int(), "Eletrodoméstico");
            Categoria c13 = new Categoria(new int(), "Empréstimo");
            Categoria c14 = new Categoria(new int(), "Encargos");
            Categoria c15 = new Categoria(new int(), "Família e Filhos");
            Categoria c16 = new Categoria(new int(), "FGTS");
            Categoria c17 = new Categoria(new int(), "Imposto");
            Categoria c18 = new Categoria(new int(), "Investimento");
            Categoria c19 = new Categoria(new int(), "Jogo Eletrônico");
            Categoria c20 = new Categoria(new int(), "Juros");
            Categoria c21 = new Categoria(new int(), "Lazer e Hobbie");
            Categoria c22 = new Categoria(new int(), "Mercado");
            Categoria c23 = new Categoria(new int(), "Moradia");
            Categoria c24 = new Categoria(new int(), "Outras Rendas");
            Categoria c25 = new Categoria(new int(), "Outros Gastos");
            Categoria c26 = new Categoria(new int(), "Mascote");
            Categoria c27 = new Categoria(new int(), "Presente ou Doação");
            Categoria c28 = new Categoria(new int(), "Rendimentos");
            Categoria c29 = new Categoria(new int(), "Resgate");
            Categoria c30 = new Categoria(new int(), "Salário");
            Categoria c31 = new Categoria(new int(), "Saques");
            Categoria c32 = new Categoria(new int(), "Saúde");
            Categoria c33 = new Categoria(new int(), "Serviços");
            Categoria c34 = new Categoria(new int(), "Telefonia / Internet / TV");
            Categoria c35 = new Categoria(new int(), "Transferência");
            Categoria c36 = new Categoria(new int(), "Transporte");
            Categoria c37 = new Categoria(new int(), "Vestuário");
            Categoria c38 = new Categoria(new int(), "Compras");


            _context.StatusCompra.AddRange(s1, s2, s3);
            _context.FormaPagamento.AddRange(f1, f2, f3, f4, f5, f6);
            _context.Categoria.AddRange(
                c1, c2, c3, c4, c5, c6, c7, c8, c9, c10,
                c11, c12, c13, c14, c15, c16, c17, c18, c19, c20,
                c21, c22, c23, c24, c25, c26, c27, c28, c29, c30,
                c31, c32, c33, c34, c35, c36, c37, c38);

            _context.SaveChanges();
        }

    }
}
