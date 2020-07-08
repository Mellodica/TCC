using System;
using System.Linq;
using System.Security.Cryptography;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Data
{
    public class SeedingService
    {
        private ControlePessoalContext _context;

        public SeedingService(ControlePessoalContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Categorias.Any() ||
                _context.Formas.Any() ||
                _context.StatusCompras.Any() ||
                _context.Desejos.Any() ||
                _context.Mercados.Any() ||
                _context.DespDiretas.Any() ||
                _context.DespFixas.Any())
            {
                return; //Já tem dados.
            }


            StatusCompra s1 = new StatusCompra(new int(), "Pendente");
            StatusCompra s2 = new StatusCompra(new int(), "Comprado");
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

            //SEEDDE DESPESA DIRETA
            DespesaDireta d1 = new DespesaDireta("Conta de Luz","Conta mensal", 200.0, new DateTime(2020, 7, 7), s1, f1, c1);
            DespesaDireta d2 = new DespesaDireta("Conta de Água", "Conta mensal", 150.0, new DateTime(2020, 7, 7), s1, f1, c1);
            DespesaDireta d3 = new DespesaDireta("Pizza", "Pizza de Sexta", 59.90, new DateTime(2020, 7, 3), s2, f4, c19);
            DespesaDireta d4 = new DespesaDireta("Escolinha", "Escolinha Mensal", 890.00, new DateTime(2020, 7, 3), s3, f5, c15);
            DespesaDireta d5 = new DespesaDireta("Passagem", "Passagem URBS", 180.00, new DateTime(2020, 6, 3), s2, f3, c12);
            DespesaDireta d6 = new DespesaDireta("Conta Internet", "INternet mes 7", 149.00, new DateTime(2020, 7, 25), s2, f4, c12);
            DespesaDireta d7 = new DespesaDireta("Compra Bicileta", "Bicileta para passeio", 785.00, new DateTime(2020, 3, 16), s3, f4, c13);
            DespesaDireta d8 = new DespesaDireta("Sorvete", "Sorvete para semana 4Litros", 20.00, new DateTime(2020, 2, 22), s2, f5, c15);
            DespesaDireta d9 = new DespesaDireta("Ração 20Kg", "Ração para o mês 06", 122.00, new DateTime(2020, 6, 10), s1, f3, c18);
            DespesaDireta d10 = new DespesaDireta("Pão Padaria", "Pão para Lanche", 3.00, new DateTime(2020, 7, 6), s3, f2, c10);
          
            //SEED DE LISTA DESEJO
            ListaDesejo l1 = new ListaDesejo("FOGÃO","5 BOCAS CONSUL",800.00, "www.casasbahia.com", new DateTime(2020, 8,12 ), s1, c1, f1);
            ListaDesejo l2 = new ListaDesejo("IPHONE 8","64GB ROSE GOLD",2000.0, "www.mercadolivre.com.br", new DateTime(2021, 12, 11), s1, c1, f1);

            //SEED DE DESPESA FIXA
            DespesaFixa df1 = new DespesaFixa("Telefone", " ", 200.0, new DateTime(2020, 6,7),s1,f1,c2);
            DespesaFixa df2 = new DespesaFixa("Internet", " ", 150.0, new DateTime(2020, 6,7),s1,f1,c2);

            Salario sa1 = new Salario("Vale", 450, new DateTime(2020,5,7));

    
            _context.StatusCompras.AddRange(s1, s2, s3);
            _context.Formas.AddRange(f1, f2, f3, f4, f5, f6);
            _context.Categorias.AddRange(
                c1, c2, c3, c4, c5, c6, c7, c8, c9, c10,
                c11, c12, c13, c14, c15, c16, c17, c18, c19, c20,
                c21, c22, c23, c24, c25, c26, c27, c28, c29, c30,
                c31, c32, c33, c34, c35, c36, c37, c38);
            _context.DespDiretas.AddRange(d1, d2, d3, d4, d5, d6, d7, d8, d9, d10);
            _context.Desejos.AddRange(l1, l2);
            _context.DespFixas.AddRange(df1, df2);
            _context.Salarios.Add(sa1);

            _context.SaveChanges();
        }

    }
}
