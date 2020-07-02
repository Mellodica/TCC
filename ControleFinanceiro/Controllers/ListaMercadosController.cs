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
    public class ListaMercadosController : Controller
    {

        private ControlePessoalContext _context;
        private CategoriaServico categoriaServicos;
        private FormaPagamentoServico formaServicos;
        private StatusCompraServico statusServicos;

        public ListaMercadosController(ControlePessoalContext context)
        {
            _context = context;
            categoriaServicos = new CategoriaServico(context);
            formaServicos = new FormaPagamentoServico(context);
            statusServicos = new StatusCompraServico(context);
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(_context.Mercados.ToList());
        }

        //GET Desejo/Create   
        [Authorize]
        public ActionResult Create()
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
        public ActionResult Create(ListaMercado mercado)

        {
            if (ModelState.IsValid)
            {
                _context.Mercados.Add(mercado);
                _context.SaveChanges();
            }
            return Json(new { Resultado = mercado.MercadoId });

        }

        //GET: Desejo/Edit
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Lista nao encontrada" });
            }

            var mercado = _context.Mercados.Find(id);
            if (mercado == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Lista nao existe" });
            }

            ViewResult viewMercado = (ViewResult)PegarViewMercadoPorId(id.Value);
            ListaMercado mercaDo = (ListaMercado)viewMercado.Model;

            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome()
                , "CategoriaId", "CategoriaNome", mercaDo.CategoriaId);

            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome()
                , "FormaId", "FormaNome", mercaDo.FormaId);

            ViewBag.Status = new SelectList(statusServicos.PegarStatusPorNome()
                , "StatusId", "StatusNome", mercaDo.StatusId);

            return viewMercado;

        }

        //POST: Desejo/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, ListaMercado mercado)
        {
            if (id != mercado.MercadoId)
            {
                return RedirectToAction(nameof(Error), new { message = "Lista não encontrada" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Mercados.Update(mercado);
                    _context.SaveChanges();
                }
                catch (ApplicationException e)
                {
                    if (!MercadoExists(mercado.MercadoId))
                    {
                        return RedirectToAction(nameof(Error), new { message = e.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { Resultado = mercado.MercadoId });
            }
            ViewBag.Categorias = new SelectList(categoriaServicos.PegarCategoriasPorNome(), "CategoriaId", "CategoriaNome", mercado.CategoriaId);
            ViewBag.Formas = new SelectList(formaServicos.PegarFormaPorNome(), "FormaId", "FormaNome", mercado.FormaId);
            ViewBag.StatusCompras = new SelectList(statusServicos.PegarStatusPorNome(), "StatusId", "StatusNome", mercado.StatusId);
            return View(mercado);
        }


        private bool MercadoExists(int? id)
        {
            return _context.Mercados.Find(id) != null;
        }

        [Authorize]
        public ActionResult Details(int? id)
        {
            return PegarViewMercadoPorId(id);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            return PegarViewMercadoPorId(id);
        }

        // POST: Mercado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaMercado mercado = _context.Mercados.Find(id);
            _context.Mercados.Remove(mercado);
            _context.SaveChanges();
            TempData["Message"] = "Lista " + mercado.MercadoNome.ToUpper() + " foi removida com sucesso!";
            return RedirectToAction(nameof(Index));
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private ActionResult PegarViewMercadoPorId(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não providenciado" });
            }

            var mercado = _context.Mercados.Find(id.Value);
            if (mercado == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Encontrado" });
            }

            return View(mercado);
        }
    }
}
