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

namespace ControleFinanceiro.Controllers
{
    public class DespesaDiretasController : Controller
    {
        private readonly ControleFinanceiroContext _context;
        private readonly CategoriaServico _categoriaServico;
        private readonly FormaPagamentoServico _formaPagamentoServico;
        private readonly StatusCompraServico _statusCompraServico;
        private readonly ServicoProduto _servicoProduto;

        public DespesaDiretasController(ControleFinanceiroContext context, CategoriaServico categoriaServico, FormaPagamentoServico formaPagamentoServico, StatusCompraServico statusCompraServico, ServicoProduto servicoProduto)
        {
            _categoriaServico = categoriaServico;
            _formaPagamentoServico = formaPagamentoServico;
            _statusCompraServico = statusCompraServico;
            _servicoProduto = servicoProduto;
            _context = context;
        }

       
        // GET: DespesaDiretas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DespesaDireta.ToListAsync());
        }

        // GET: DespesaDiretas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaDireta = await _context.DespesaDireta
                .FirstOrDefaultAsync(m => m.DespDirId == id);
            if (despesaDireta == null)
            {
                return NotFound();
            }

            return View(despesaDireta);
        }

        // GET: DespesaDiretas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DespesaDiretas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespDirId,DespDirValor,DespDirData")] DespesaDireta despesaDireta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesaDireta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(despesaDireta);
        }

        // GET: DespesaDiretas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaDireta = await _context.DespesaDireta.FindAsync(id);
            if (despesaDireta == null)
            {
                return NotFound();
            }
            return View(despesaDireta);
        }

        // POST: DespesaDiretas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DespDirId,DespDirValor,DespDirData")] DespesaDireta despesaDireta)
        {
            if (id != despesaDireta.DespDirId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesaDireta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaDiretaExists(despesaDireta.DespDirId))
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
            return View(despesaDireta);
        }

        // GET: DespesaDiretas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaDireta = await _context.DespesaDireta
                .FirstOrDefaultAsync(m => m.DespDirId == id);
            if (despesaDireta == null)
            {
                return NotFound();
            }

            return View(despesaDireta);
        }

        // POST: DespesaDiretas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesaDireta = await _context.DespesaDireta.FindAsync(id);
            _context.DespesaDireta.Remove(despesaDireta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesaDiretaExists(int id)
        {
            return _context.DespesaDireta.Any(e => e.DespDirId == id);
        }
    }
}
