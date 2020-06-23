using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.Data;
using ControleFinanceiro.Servico;
using Microsoft.AspNetCore.Authorization;
using ControleFinanceiro.Models.ViewModels;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly ControlePessoalContext _context;
        private readonly CategoriaServico categoriaServico;

        public CategoriasController(ControlePessoalContext context)
        {
            _context = context;
            categoriaServico = new CategoriaServico(context);
            
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            //var list = await categoriaServico.EncontrarTudoCategoriasAsync();
            //return View(list);
            return View(await categoriaServico.PegarCategoriasPorNome().ToListAsync());

        }

        // GET: Categorias/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            return await PegarViewCategoriaPorId(id);
        }


        private async Task<IActionResult> PegarViewCategoriaPorId(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Categoria não existe" });
            }

            var categoria = await categoriaServico.PegarCategoriaPorIdAsync(id.Value);
            if (categoria == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Categoria não Encontrada" });
            }

            return View(categoria);
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
