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
    public class ListaDesejosController : Controller
    {
        private readonly ControleFinanceiroContext _context;

        public ListaDesejosController(ControleFinanceiroContext context)
        {
            _context = context;
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
            return View();
        }

        // POST: ListaDesejos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesejoId,DesejoValor,DesejoData")] ListaDesejo listaDesejo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaDesejo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaDesejo);
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
