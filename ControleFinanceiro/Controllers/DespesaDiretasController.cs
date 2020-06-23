using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using ControleFinanceiro.Models.ViewModels;
using System.Diagnostics;

namespace ControleFinanceiro.Controllers
{
    [Authorize]
    public class DespesaDiretasController : Controller
    {
        private readonly ControlePessoalContext _context;
        private readonly ListaDespDiretaServico listaDespDiretaServico;
        private readonly CategoriaServico categoriaServicos;
        private readonly FormaPagamentoServico formaServicos;
        private readonly StatusCompraServico statusServicos;

        public DespesaDiretasController(ControlePessoalContext context)
        {
            _context = context;
            listaDespDiretaServico = new ListaDespDiretaServico(context);
            categoriaServicos = new CategoriaServico(context);
            formaServicos = new FormaPagamentoServico(context);
            statusServicos = new StatusCompraServico(context);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var list = await desejoServicos.EncontrarTudoDesejoAsync();
            //return View(list);
            return View(await listaDespDiretaServico.PegarDiretaPorNome().ToListAsync());

        }


        //GET DespesaDiretas/Create   
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

        //POST: DespesaDiretas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespesaDirNome, DespesaDirDescricao, DiretaValor,DespDirData, StatusId, FormaId, CategoriaId")] DespesaDireta direta)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    await listaDespDiretaServico.RegistrarDespDireta(direta);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(direta);

        }

        //GET: DespesaDiretas/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto nao encontrado" });
            }

            var direta = await listaDespDiretaServico.PegarDiretaPorIdAsync(id.Value);
            if (direta == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto nao existe" });
            }

            ViewResult viewDireta = (ViewResult)await PegarViewDiretaPorId(id);
            DespesaDireta despesaDireta = (DespesaDireta)viewDireta.Model;

            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome()
                , "CategoriaId", "CategoriaNome", despesaDireta.CategoriaId);

            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome()
                , "FormaId", "FormaNome", despesaDireta.FormaId);

            ViewBag.Status = new SelectList(statusServicos.PegarStatusPorNome()
                , "StatusId", "StatusNome", despesaDireta.StatusId);

            return viewDireta;

        }

        //POST: DespesaDiretas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("DespDirId,DespesaDirNome, DespesaDirDescricao, DiretaValor,DespDirData, StatusId, FormaId, CategoriaId")] DespesaDireta direta)
        {

            if (id != direta.DespDirId)
            {
                return RedirectToAction(nameof(Error), new { message = "Desejo não encontrado" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await listaDespDiretaServico.AtualizarAsync(direta);
                }
                catch (ApplicationException e)
                {
                    if (!await DiretaExists(direta.DespDirId))
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

            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome(), "CategoriaId", "CategoriaNome", direta.CategoriaId);
            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome(), "FormaId", "FormaNome", direta.FormaId);
            ViewBag.StatusCompras = new SelectList(statusServicos.PegarStatusPorNome(), "StatusId", "StatusNome", direta.StatusId);
            return View(direta);
        }

        private async Task<bool> DiretaExists(int? id)
        {
            return await listaDespDiretaServico.PegarDiretaPorIdAsync(id.Value) != null;
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            return await PegarViewDiretaPorId(id);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            return await PegarViewDiretaPorId(id);
        }

        // POST: DespesaDiretas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var direta = await listaDespDiretaServico.DeletarDiretaPorId(id.Value);
            TempData["Message"] = "Desejo " + direta.DespesaDirNome.ToUpper() + " foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> PegarViewDiretaPorId(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não providenciado" });
            }

            var direta = await listaDespDiretaServico.PegarDiretaPorIdAsync(id.Value);
            if (direta == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Encontrado" });
            }

            return View(direta);
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
