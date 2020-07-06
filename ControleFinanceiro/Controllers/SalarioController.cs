using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.Models.ViewModels;
using ControleFinanceiro.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Controllers
{
    [Authorize]
    public class SalarioController : Controller
    {
        private readonly ControlePessoalContext _context;
        private readonly SalarioServico salarioServico;

        public SalarioController(ControlePessoalContext context)
        {
            _context = context;
            salarioServico = new SalarioServico(context);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await salarioServico.PegarSalarioPorNome().ToListAsync());
        }

        //GET Salario/Create   
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        //POST: Salario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalarioNome,SalarioValor, SalarioData")] Salario salario)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    await salarioServico.RegistrarSalario(salario);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(salario);

        }

        //GET: Salario/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Salário nao encontrado" });
            }

            var salario = await salarioServico.PegarSalarioPorIdAsync(id.Value);
            if (salario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Salário nao existe" });
            }

            ViewResult viewSalario = (ViewResult)await PegarViewSalarioPorId(id);
            Salario listaSalario = (Salario)viewSalario.Model;

            return viewSalario;
        }

        //POST: Salario/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("SalarioId,SalarioNome, SalarioValor, SalarioData")] Salario salario)
        {

            if (id != salario.SalarioId)
            {
                return RedirectToAction(nameof(Error), new { message = "Salario não encontrado" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await salarioServico.AtualizarAsync(salario);
                }
                catch (ApplicationException e)
                {
                    if (!await SalarioExists(salario.SalarioId))
                    {
                        return RedirectToAction(nameof(Error), new { message = e.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salario);
        }

        private async Task<bool> SalarioExists(int? id)
        {
            return await salarioServico.PegarSalarioPorIdAsync(id.Value) != null;
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            return await PegarViewSalarioPorId(id.Value);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            return await PegarViewSalarioPorId(id.Value);
        }

        // POST: Salario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var salario = await salarioServico.DeletarSalarioPorId(id.Value);
            TempData["Message"] = "Salario " + salario.SalarioNome.ToUpper() + " foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> PegarViewSalarioPorId(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var salario = await salarioServico.PegarSalarioPorIdAsync(id.Value);
            if (salario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Encontrado" });
            }

            return View(salario);
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
    }
}