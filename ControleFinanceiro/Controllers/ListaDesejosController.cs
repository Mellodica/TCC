using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Servico;
using ControleFinanceiro.Models.ViewModel;

namespace ControleFinanceiro.Controllers
{
   
    public class ListaDesejosController : Controller
    { 
        private readonly ControleFinanceiroContext _context;
        private readonly CategoriaServico _categoriaServico;
        private readonly FormaPagamentoServico _formaPagamentoServico;
        private readonly StatusCompraServico _statusCompraServico;
        private readonly ServicoProduto _servicoProduto;
        private readonly DesejoViewModel _desejoViewModel;
        


        public ListaDesejosController(ControleFinanceiroContext context, CategoriaServico categoriaServico, ServicoProduto servicoProduto, FormaPagamentoServico formaPagamentoServico, StatusCompraServico statusCompraServico)
        {
            _context = context;
            _servicoProduto = servicoProduto;
            _categoriaServico = categoriaServico;
            _formaPagamentoServico = formaPagamentoServico;
            _statusCompraServico =  statusCompraServico;
        }

        // GET: ListaDesejos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListaDesejo.ToListAsync());
        }

        // GET: ListaDesejos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaDesejo = await _context.ListaDesejo
                .FirstOrDefaultAsync(m => m.DesejoId == id);
            if (listaDesejo == null)
            {
                return NotFound();
            }

            return View(listaDesejo);
        }

        // GET: ListaDesejos/Create
        public IActionResult Create()
        {
            var prod = _servicoProduto.PegarTudo();
            var cat = _categoriaServico.PegarTudo();
            var forma = _formaPagamentoServico.PegarTudo();
            var status = _statusCompraServico.PegarTudo();
            var viewModel = new DesejoViewModel { Categorias = cat, FormaPagamentos = forma, StatusCompras = status, ListaProdutos = prod };
            return View(viewModel);
        }

        // POST: ListaDesejos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ListaDesejo listaDesejo)
        {
            if (ModelState.IsValid)
            {
                this._context.Entry(listaDesejo).State = EntityState.Modified;
                this._context.SaveChanges();

                return this.RedirectToAction("Index");
            }

            //this.ViewBa = new SelectList(this._context.ListaDesejo, "StatusId", "StatusNome", listaDesejo.StatId);
            //this.ViewBag.ArtistId = new SelectList(this._context.ListaDesejo, "FormaId", "FormaNome", listaDesejo.FormId);

            return this.View(listaDesejo);






            //if (ModelState.IsValid)
            //{
            //    _desejoServico.Insert(listaDesejo);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(listaDesejo);
        }

        // GET: ListaDesejos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaDesejo = await _context.ListaDesejo.FindAsync(id);
            if (listaDesejo == null)
            {
                return NotFound();
            }
            return View(listaDesejo);
        }

        // POST: ListaDesejos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesejoId,DesejoValor,DesejoData")] ListaDesejo listaDesejo)
        {
            if (id != listaDesejo.DesejoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaDesejo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaDesejoExists(listaDesejo.DesejoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(listaDesejo);
        }

        // GET: ListaDesejos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaDesejo = await _context.ListaDesejo
                .FirstOrDefaultAsync(m => m.DesejoId == id);
            if (listaDesejo == null)
            {
                return NotFound();
            }

            return View(listaDesejo);
        }

        // POST: ListaDesejos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaDesejo = await _context.ListaDesejo.FindAsync(id);
            _context.ListaDesejo.Remove(listaDesejo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaDesejoExists(int id)
        {
            return _context.ListaDesejo.Any(e => e.DesejoId == id);
        }
    }
}
