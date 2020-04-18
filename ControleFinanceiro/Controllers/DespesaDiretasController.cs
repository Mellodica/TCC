using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Controllers
{
    public class DespesaDiretasController : Controller
    {
        private readonly ControleFinanceiroContext _context;

        public DespesaDiretasController(ControleFinanceiroContext context)
        {
            _context = context;
        }

        // GET: DespesaDiretas
        public async Task<IActionResult> Index()
        {
            var controleFinanceiroContext = _context.DespesaDireta.Include(d => d.ListaProduto);
            return View(await controleFinanceiroContext.ToListAsync());
        }

        // GET: DespesaDiretas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesaDireta = await _context.DespesaDireta
                .Include(d => d.ListaProduto)
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
            ViewData["ListaProdutoId"] = new SelectList(_context.ListaProduto, "ProdutoId", "ProdutoId");
            return View();
        }

        // POST: DespesaDiretas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespDirId,DespDirValor,DespDirData,Status,StatusId,FormaPagamento,FormaPagamentoId,Categoria,CategoriaId,ListaProdutoId")] DespesaDireta despesaDireta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesaDireta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListaProdutoId"] = new SelectList(_context.ListaProduto, "ProdutoId", "ProdutoId", despesaDireta.ListaProdutoId);
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
            ViewData["ListaProdutoId"] = new SelectList(_context.ListaProduto, "ProdutoId", "ProdutoId", despesaDireta.ListaProdutoId);
            return View(despesaDireta);
        }

        // POST: DespesaDiretas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DespDirId,DespDirValor,DespDirData,Status,StatusId,FormaPagamento,FormaPagamentoId,Categoria,CategoriaId,ListaProdutoId")] DespesaDireta despesaDireta)
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
            ViewData["ListaProdutoId"] = new SelectList(_context.ListaProduto, "ProdutoId", "ProdutoId", despesaDireta.ListaProdutoId);
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
                .Include(d => d.ListaProduto)
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
