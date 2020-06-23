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
    public class ListaDesejosController : Controller
    {
        private readonly ControlePessoalContext _context;
        private readonly ListaDesejoServico desejoServicos;
        private readonly CategoriaServico categoriaServicos;
        private readonly FormaPagamentoServico formaServicos;
        private readonly StatusCompraServico statusServicos;

        public ListaDesejosController(ControlePessoalContext context)
        {
            _context = context;           
            desejoServicos = new ListaDesejoServico(context);
            categoriaServicos = new CategoriaServico(context);
            formaServicos = new FormaPagamentoServico(context);
            statusServicos = new StatusCompraServico(context);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
           // var list = await desejoServicos.EncontrarTudoDesejoAsync();
           // return View(list);
            return View(await desejoServicos.PegarDesejoPorNome().ToListAsync());

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
        public async Task<IActionResult> Create([Bind("DesejoNome, DesejoDescricao, DesejoValor, DesejoData,DesejoLoja, StatusId, FormaId, CategoriaId")] ListaDesejo desejo)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    await desejoServicos.RegistrarDesejo(desejo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(desejo);

        }

        //GET: Desejo/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto nao encontrado" });
            }

            var desejo = await desejoServicos.PegarDesejoPorIdAsync(id.Value);
            if (desejo == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto nao existe" });
            }

            ViewResult viewDesejo = (ViewResult)await PegarViewDesejoPorId(id);
            ListaDesejo listaDesejo = (ListaDesejo)viewDesejo.Model;

            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome()
                , "CategoriaId", "CategoriaNome", listaDesejo.CategoriaId);

            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome()
                , "FormaId", "FormaNome", listaDesejo.FormaId);

            ViewBag.Status = new SelectList(statusServicos.PegarStatusPorNome()
              , "StatusId", "StatusNome", listaDesejo.StatusId);

            return viewDesejo;

        }

        //POST: Desejo/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("DesejoId,DesejoNome,DesejoDescricao,DesejoValor,DesejoLoja,DesejoData,StatusId,FormaId,CategoriaId")] ListaDesejo desejo)
        {

            if (id != desejo.DesejoId)
            {
                return RedirectToAction(nameof(Error), new { message = "Desejo não encontrado" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await desejoServicos.AtualizarAsync(desejo);
                }
                catch (ApplicationException e)
                {
                    if (!await DesejoExists(desejo.DesejoId))
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

            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome(), "CategoriaId", "CategoriaNome", desejo.CategoriaId);
            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome(), "FormaId", "FormaNome", desejo.FormaId);
            ViewBag.StatusCompras = new SelectList(statusServicos.PegarStatusPorNome(), "StatusId", "StatusNome", desejo.StatusId);
            return View(desejo);
        }

        private async Task<bool> DesejoExists(int? id)
        {
            return await desejoServicos.PegarDesejoPorIdAsync(id.Value) != null;
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            return await PegarViewDesejoPorId(id);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            return await PegarViewDesejoPorId(id);
        }

        // POST: Desejo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var desejo = await desejoServicos.DeletarDesejoPorId(id.Value);
            TempData["Message"] = "Desejo " + desejo.DesejoNome.ToUpper() + " foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> PegarViewDesejoPorId(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não providenciado" });
            }

            var desejo = await desejoServicos.PegarDesejoPorIdAsync(id.Value);
            if (desejo == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Encontrado" });
            }

            return View(desejo);
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
