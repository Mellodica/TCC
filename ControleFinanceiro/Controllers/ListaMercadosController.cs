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
    public class ListaMercadosController : Controller
    {
        private readonly ControleFinanceiroContext _context;

        public ListaMercadosController(ControleFinanceiroContext context)
        {
            _context = context;
        }

        // GET: ListaMercados
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListaMercado.ToListAsync());
        }

        // GET: ListaMercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaMercado = await _context.ListaMercado
                .FirstOrDefaultAsync(m => m.MercadoId == id);
            if (listaMercado == null)
            {
                return NotFound();
            }

            return View(listaMercado);
        }

        // GET: ListaMercados/Create
        public IActionResult Create()
        {
            ListaMercado listaMercado= new ListaMercado();
            var obj1 = listaMercado;
            return View(listaMercado);
        }

        // POST: ListaMercados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MercadoId,MercadoValor,MercadoData","StatusValor","StatId")] ListaMercado listaMercado)
        {
            
            
            if (ModelState.IsValid)
            {
               
                _context.Add(listaMercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaMercado);
        }

        // GET: ListaMercados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaMercado = await _context.ListaMercado.FindAsync(id);
            if (listaMercado == null)
            {
                return NotFound();
            }
            return View(listaMercado);
        }

        // POST: ListaMercados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MercadoId,MercadoValor,MercadoData")] ListaMercado listaMercado)
        {
            if (id != listaMercado.MercadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaMercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaMercadoExists(listaMercado.MercadoId))
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
            return View(listaMercado);
        }

        // GET: ListaMercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaMercado = await _context.ListaMercado
                .FirstOrDefaultAsync(m => m.MercadoId == id);
            if (listaMercado == null)
            {
                return NotFound();
            }

            return View(listaMercado);
        }

        // POST: ListaMercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaMercado = await _context.ListaMercado.FindAsync(id);
            _context.ListaMercado.Remove(listaMercado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaMercadoExists(int id)
        {
            return _context.ListaMercado.Any(e => e.MercadoId == id);
        }
    }
}
