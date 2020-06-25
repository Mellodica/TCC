using System.Linq;
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

            /*
            ListaProduto p1 = new ListaProduto(new int(), "CELULAR A50", "CELULAR SAMSUNG A50 128GB");
            ListaProduto p2 = new ListaProduto(new int(), "MONITOR 22 DELL", "MONITOR DELL P2219H FULLHD");
            ListaProduto p3 = new ListaProduto(new int(), "TV LED 4K SAMSUNG 50", "TV LED 4K SANSUMG RU7100 50 POLEDADAS");
            ListaProduto p4 = new ListaProduto(new int(), "BOLSA GRANDE FEMININA DE COURO", "BOLSA GRANDE FEMININA DE COURO MACIO COM 2 ALÇAS");
            ListaProduto p5 = new ListaProduto(new int(), "XIAOMI SMARTWATCH AMAZIFIT BIP", "AMAZIFIT BIP XIAOMI A1608, PRETO");
            ListaProduto p6 = new ListaProduto(new int(), "GAMEPAD 5X1 PARA CELULAR", " SUPORTE PARA CELULAR GAMEPAD 5 EM 1");
            ListaProduto p7 = new ListaProduto(new int(), "XIAOMI MIBAND 4", "PULSEIRA XIAOMI MIBAND 4 PRETO");
            ListaProduto p8 = new ListaProduto(new int(), "TAPETE DE SISAL 2X3M", "TAPETE SISAL 2X3M");
            ListaProduto p9 = new ListaProduto(new int(), "PANELA PRESSÃO 10L", "PANELA PRESSÃO 10L EIRILAR TRAVA EXTERNA");
            ListaProduto p10 = new ListaProduto(new int(), "SUPORTE DE TABLET", "SUPORTE DE MESA PARA TABLET");
            */

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

            //ListaDesejo l1 = new ListaDesejo(new int(), "400", 200, DateTime.Now, s1, c38, f1);


            _context.StatusCompras.AddRange(s1, s2, s3);
            _context.Formas.AddRange(f1, f2, f3, f4, f5, f6);
            _context.Categorias.AddRange(
                c1, c2, c3, c4, c5, c6, c7, c8, c9, c10,
                c11, c12, c13, c14, c15, c16, c17, c18, c19, c20,
                c21, c22, c23, c24, c25, c26, c27, c28, c29, c30,
                c31, c32, c33, c34, c35, c36, c37, c38);
            //_context.ListaProduto.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

            //_context.ListaDesejo.AddRange(l1);

            _context.SaveChanges();
        }

    }
}
