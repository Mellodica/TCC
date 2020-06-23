using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Servico.Erros;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Servico
{
    public class ProdutoServico
    {
        private readonly ControlePessoalContext _context;

        public ProdutoServico(ControlePessoalContext context)
        {
            _context = context;
        }

        public async Task<List<ListaProduto>> EncontrarTudoProdutoAsync()
        {
            return await _context.Produtos.OrderBy(x => x.ProdutoNome).ToListAsync();
        }

        //IQueryable<> é específico para o LINQ.Um IQueryable<> também é 
        //derivado de um IEnumerable<T> e admite lazy loading permitindo uma melhor otimização 
        //de uma consulta.Ou seja, apenas os elementos realmente necessários para uma determinada 
        //operação são retornados na consulta para futura análise.
        public IQueryable<ListaProduto> PegarProdutoPorNome()
        {
            return _context.Produtos
                .Include(i => i.Categoria)
                .Include(i => i.FormaPagamento)
                .Include(i => i.StatusCompra)
                .OrderBy(p => p.ProdutoNome);
        }

        public async Task<ListaProduto> PegarProdutoPorIdAsync(int? id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.ProdutoId == id);
            _context.Categorias.Where(i => produto.CategoriaId == i.CategoriaId).Load();
            _context.Formas.Where(i => produto.FormaId == i.FormaId).Load();
            _context.StatusCompras.Where(i => produto.StatusId == i.StatusId).Load();
            return produto;
        }

        public async Task AtualizarAsync(ListaProduto produto)
        {
            bool hasAny = await _context.Produtos.AnyAsync(x => x.ProdutoId == produto.ProdutoId);
            if (!hasAny)
            {
                throw new NotFoundException("não encontrado");
            }
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<ListaProduto> RegistrarProdutos(ListaProduto produto)
        {
            if (produto.ProdutoId == null)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                _context.Update(produto);
            }
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<ListaProduto> DeletarProdutoPorId(int? id)
        {
            ListaProduto produto = await PegarProdutoPorIdAsync(id.Value);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }


    }
}
