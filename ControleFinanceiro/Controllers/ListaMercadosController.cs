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
    public class ListaMercadosController : Controller
    {
        private readonly ControleFinanceiroContext _context;
        private readonly CategoriaServico _categoriaServico;
        private readonly FormaPagamentoServico _formaPagamentoServico;
        private readonly StatusCompraServico _statusCompraServico;
        private readonly ServicoProduto _servicoProduto;


        public ListaMercadosController(ControleFinanceiroContext context, CategoriaServico categoriaServico, FormaPagamentoServico formaPagamentoServico, StatusCompraServico statusCompraServico, ServicoProduto servicoProduto)
        {
            _context = context;
            _categoriaServico = categoriaServico;
            _formaPagamentoServico = formaPagamentoServico;
            _statusCompraServico = statusCompraServico;
            _servicoProduto = servicoProduto;
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
            var prod = _servicoProduto.PegarTudo();
            var cat = _categoriaServico.PegarTudo();
            var forma = _formaPagamentoServico.PegarTudo();
            var status = _statusCompraServico.PegarTudo();
            var viewModel = new MercadoViewModel { Categorias = cat, FormaPagamentos = forma, StatusCompras = status, ListaProdutos = prod };
            return View(viewModel);
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
