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
    public class DespesaFixasController : Controller
    {      
        private readonly ControlePessoalContext _context;
        private readonly ListaDespFixaServico listaDespFixaServico;
        private readonly CategoriaServico categoriaServicos;
        private readonly FormaPagamentoServico formaServicos;
        private readonly StatusCompraServico statusServicos;

        public DespesaFixasController(ControlePessoalContext context)
        {
            _context = context;
            listaDespFixaServico = new ListaDespFixaServico(context);
            categoriaServicos = new CategoriaServico(context);
            formaServicos = new FormaPagamentoServico(context);
            statusServicos = new StatusCompraServico(context);
        }

        [Authorize]
        public async Task<IActionResult> Index(string Buscar)
        {
            var fixa = from d in _context.DespFixas
                     .Include(i => i.Categoria)
                     .Include(i => i.FormaPagamento)
                     .Include(i => i.StatusCompra)
                     .OrderBy(p => p.DespFixaNome)
                         select d;
            if (!string.IsNullOrEmpty(Buscar))
            {
                fixa = fixa.Where(s => s.DespFixaNome.Contains(Buscar));
            }
            return View(await fixa.ToListAsync());
        }

        [HttpPost]
        public string Index(string Buscar, bool notUsed)
        {
            return "From [HttpPost]Index: filtrar on " + Buscar;
        }

        //GET DespesaFixa/Create   
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

        //POST: DespesaFixa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespFixaNome, DespFixaDescricao, DespFixaValor,DespFixaData, StatusId, FormaId, CategoriaId")] DespesaFixa fixa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await listaDespFixaServico.RegistrarDespesaFixa(fixa);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(fixa);
        }

        //GET: DespesaFixa/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto nao encontrado" });
            }

            var direta = await listaDespFixaServico.PegarFixaPorIdAsync(id.Value);
            if (direta == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto nao existe" });
            }

            ViewResult viewFixa = (ViewResult)await PegarViewFixaPorId(id);
            DespesaFixa despesaFixa = (DespesaFixa)viewFixa.Model;

            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome()
                , "CategoriaId", "CategoriaNome", despesaFixa.CategoriaId);

            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome()
                , "FormaId", "FormaNome", despesaFixa.FormaId);

            ViewBag.Status = new SelectList(statusServicos.PegarStatusPorNome()
                , "StatusId", "StatusNome", despesaFixa.StatusId);

            return viewFixa;
        }

        //POST: DespesaFixa/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("DespFixaId,DespFixaNome, DespFixaDescricao, DespFixaValor,DespFixaData, StatusId, FormaId, CategoriaId")] DespesaFixa fixa)
        {
            if (id != fixa.DespFixaId)
            {
                return RedirectToAction(nameof(Error), new { message = "Desejo não encontrado" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await listaDespFixaServico.AtualizarAsync(fixa);
                }
                catch (ApplicationException e)
                {
                    if (!await DiretaExists(fixa.DespFixaId))
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
            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome(), "CategoriaId", "CategoriaNome", fixa.CategoriaId);
            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome(), "FormaId", "FormaNome", fixa.FormaId);
            ViewBag.StatusCompras = new SelectList(statusServicos.PegarStatusPorNome(), "StatusId", "StatusNome", fixa.StatusId);
            return View(fixa);
        }

        private async Task<bool> DiretaExists(int? id)
        {
            return await listaDespFixaServico.PegarFixaPorIdAsync(id.Value) != null;
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            return await PegarViewFixaPorId(id);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            return await PegarViewFixaPorId(id);
        }

        // POST: DespesaFixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var fixa = await listaDespFixaServico.DeletarFixaPorId(id.Value);
            TempData["Message"] = "Despesa " + fixa.DespFixaNome.ToUpper() + " foi removida com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> PegarViewFixaPorId(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não providenciado" });
            }

            var fixa = await listaDespFixaServico.PegarFixaPorIdAsync(id.Value);
            if (fixa == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Encontrado" });
            }

            return View(fixa);
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
