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
    public class ListaProdutosController : Controller
    {
        private readonly ControleFinanceiroContext _context;

        public ListaProdutosController(ControleFinanceiroContext context)
        {
            _context = context;
        }

        // GET: ListaProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListaProduto.ToListAsync());
        }

        // GET: ListaProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaProduto = await _context.ListaProduto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listaProduto == null)
            {
                return NotFound();
            }

            return View(listaProduto);
        }

        // GET: ListaProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListaProdutos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,ProdutoNome,ProdutoDescricao")] ListaProduto listaProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaProduto);
        }

        // GET: ListaProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaProduto = await _context.ListaProduto.FindAsync(id);
            if (listaProduto == null)
            {
                return NotFound();
            }
            return View(listaProduto);
        }

        // POST: ListaProdutos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,ProdutoNome,ProdutoDescricao")] ListaProduto listaProduto)
        {
            if (id != listaProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaProdutoExists(listaProduto.Id))
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
            return View(listaProduto);
        }

        // GET: ListaProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaProduto = await _context.ListaProduto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listaProduto == null)
            {
                return NotFound();
            }

            return View(listaProduto);
        }

        // POST: ListaProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaProduto = await _context.ListaProduto.FindAsync(id);
            _context.ListaProduto.Remove(listaProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaProdutoExists(int id)
        {
            return _context.ListaProduto.Any(e => e.Id == id);
        }
    }
}
