using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Models.ViewModels;
using ControleFinanceiro.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Controllers
{
    [Authorize]
    public class ListaProdutosController : Controller
    {
        private readonly ControlePessoalContext _context;
        private readonly ProdutoServico produtoServico;
        private readonly CategoriaServico categoriaServicos;
        private readonly FormaPagamentoServico formaServicos;
        private readonly StatusCompraServico statusServicos;

        public ListaProdutosController(ControlePessoalContext context)
        {
            _context = context;
            produtoServico = new ProdutoServico(context);
            categoriaServicos = new CategoriaServico(context);
            formaServicos = new FormaPagamentoServico(context);
            statusServicos = new StatusCompraServico(context);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            // var list = await desejoServicos.EncontrarTudoDesejoAsync();
            // return View(list);
            return View(await produtoServico.PegarProdutoPorNome().ToListAsync());

        }


        //GET Desejo/Create   
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {

            var categorias = categoriaServicos.PegarCategoriasPorNome().ToList();
            categorias.Insert(0, new Categoria() { CategoriaId = 0, CategoriaNome = "Selecione a Categoria" });
            ViewBag.Categorias = categorias;

            var formas = formaServicos.PegarFormaPorNome().ToList();
            formas.Insert(0, new FormaPagamento() { FormaId = 0, FormaNome = "Selecione a forma de Pagamento" });
            ViewBag.Formas = formas;

            var status = statusServicos.PegarStatusPorNome().ToList();
            status.Insert(0, new StatusCompra() { StatusId = 0, StatusNome = "Selecione a situação da compra" });
            ViewBag.StatusCompras = status;

            return View();

        }

        //POST: Desejo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoNome, ProdutoDescricao, StatusId, FormaId, CategoriaId")] ListaProduto produto)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    await produtoServico.RegistrarProdutos(produto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(produto);

        }

        //GET: Desejo/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto nao encontrado" });
            }

            var desejo = await produtoServico.PegarProdutoPorIdAsync(id.Value);
            if (desejo == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto nao existe" });
            }

            ViewResult viewProduto = (ViewResult)await PegarViewProdutoPorId(id);
            ListaProduto listaProduto = (ListaProduto)viewProduto.Model;

            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome()
                , "CategoriaId", "CategoriaNome", listaProduto.CategoriaId);

            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome()
                , "FormaId", "FormaNome", listaProduto.FormaId);

            ViewBag.Status = new SelectList(statusServicos.PegarStatusPorNome()
              , "StatusId", "StatusNome", listaProduto.StatusId);

            return viewProduto;

        }

        //POST: Desejo/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ProdutoId,ProdutoNome, ProdutoDescricao, StatusId, FormaId, CategoriaId")] ListaProduto produto)
        {

            if (id != produto.ProdutoId)
            {
                return RedirectToAction(nameof(Error), new { message = "Desejo não encontrado" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await produtoServico.AtualizarAsync(produto);
                }
                catch (ApplicationException e)
                {
                    if (!await ProdutoExists(produto.ProdutoId))
                    {
                        return RedirectToAction(nameof(Error), new { message = e.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome(), "CategoriaId", "CategoriaNome", produto.CategoriaId);
            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome(), "FormaId", "FormaNome", produto.FormaId);
            ViewBag.StatusCompras = new SelectList(statusServicos.PegarStatusPorNome(), "StatusId", "StatusNome", produto.StatusId);
            return View(produto);
        }

        private async Task<bool> ProdutoExists(int? id)
        {
            return await produtoServico.PegarProdutoPorIdAsync(id.Value) != null;
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            return await PegarViewProdutoPorId(id);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            return await PegarViewProdutoPorId(id);
        }

        // POST: Desejo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var produto = await produtoServico.DeletarProdutoPorId(id.Value);
            TempData["Message"] = "Produto " + produto.ProdutoNome.ToUpper() + " foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> PegarViewProdutoPorId(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não providenciado" });
            }

            var produto = await produtoServico.PegarProdutoPorIdAsync(id.Value);
            if (produto == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Encontrado" });
            }

            return View(produto);
        }

        [Authorize]
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
