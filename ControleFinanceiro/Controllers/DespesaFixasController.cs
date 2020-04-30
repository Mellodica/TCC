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
    public class DespesaFixasController : Controller
    {
        private readonly ControleFinanceiroContext _context;
        private readonly CategoriaServico _categoriaServico;
        private readonly FormaPagamentoServico _formaPagamentoServico;
        private readonly StatusCompraServico _statusCompraServico;
        private readonly ServicoProduto _servicoProduto;


        public DespesaFixasController(ControleFinanceiroContext context, CategoriaServico categoriaServico, FormaPagamentoServico formaPagamentoServico, StatusCompraServico statusCompraServico, ServicoProduto servicoProduto)
        {
            _context = context;
            _categoriaServico = categoriaServico;
            _formaPagamentoServico = formaPagamentoServico;
            _statusCompraServico = statusCompraServico;
            _servicoProduto = servicoProduto;
        }

        // GET: DespesaFixas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DespesaFixa.ToListAsync());
        }

        // GET: DespesaFixas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaFixa = await _context.DespesaFixa
                .FirstOrDefaultAsync(m => m.DespFixaId == id);
            if (despesaFixa == null)
            {
                return NotFound();
            }

            return View(despesaFixa);
        }

        // GET: DespesaFixas/Create
        public IActionResult Create()
        {
            var prod = _servicoProduto.PegarTudo();
            var cat = _categoriaServico.PegarTudo();
            var forma = _formaPagamentoServico.PegarTudo();
            var status = _statusCompraServico.PegarTudo();
            var viewModel = new FixaViewModel { Categorias = cat, FormaPagamentos = forma, StatusCompras = status, ListaProdutos = prod };
            return View(viewModel);
        }

        // POST: DespesaFixas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] //[Bind("DespFixaId,DespFixaValor,DespFixaData")] 
        public async Task<IActionResult> Create(DespesaFixa despesaFixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesaFixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(despesaFixa);
        }

        // GET: DespesaFixas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaFixa = await _context.DespesaFixa.FindAsync(id);
            if (despesaFixa == null)
            {
                return NotFound();
            }
            return View(despesaFixa);
        }

        // POST: DespesaFixas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DespFixaId,DespFixaValor,DespFixaData")] DespesaFixa despesaFixa)
        {
            if (id != despesaFixa.DespFixaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesaFixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaFixaExists(despesaFixa.DespFixaId))
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
            return View(despesaFixa);
        }

        // GET: DespesaFixas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaFixa = await _context.DespesaFixa
                .FirstOrDefaultAsync(m => m.DespFixaId == id);
            if (despesaFixa == null)
            {
                return NotFound();
            }

            return View(despesaFixa);
        }

        // POST: DespesaFixas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesaFixa = await _context.DespesaFixa.FindAsync(id);
            _context.DespesaFixa.Remove(despesaFixa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesaFixaExists(int id)
        {
            return _context.DespesaFixa.Any(e => e.DespFixaId == id);
        }
    }
}
