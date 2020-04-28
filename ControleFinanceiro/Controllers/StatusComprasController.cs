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
    public class StatusComprasController : Controller
    {
        private readonly ControleFinanceiroContext _context;

        public StatusComprasController(ControleFinanceiroContext context)
        {
            _context = context;
        }

        // GET: StatusCompras
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusCompra.ToListAsync());
        }

        // GET: StatusCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCompra = await _context.StatusCompra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusCompra == null)
            {
                return NotFound();
            }

            return View(statusCompra);
        }

        // GET: StatusCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusNome")] StatusCompra statusCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusCompra);
        }

        // GET: StatusCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCompra = await _context.StatusCompra.FindAsync(id);
            if (statusCompra == null)
            {
                return NotFound();
            }
            return View(statusCompra);
        }

        // POST: StatusCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusNome")] StatusCompra statusCompra)
        {
            if (id != statusCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusCompraExists(statusCompra.Id))
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
            return View(statusCompra);
        }

        // GET: StatusCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCompra = await _context.StatusCompra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusCompra == null)
            {
                return NotFound();
            }

            return View(statusCompra);
        }

        // POST: StatusCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusCompra = await _context.StatusCompra.FindAsync(id);
            _context.StatusCompra.Remove(statusCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusCompraExists(int id)
        {
            return _context.StatusCompra.Any(e => e.Id == id);
        }

        public List<StatusCompra> PegarTudo()
        {
            return _context.StatusCompra.OrderBy(i => i.StatusNome).ToList();
        }
    }
}
