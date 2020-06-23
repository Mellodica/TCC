using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [Authorize]
    public class ListaMercadosController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
