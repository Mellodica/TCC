using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [Authorize]
    public class ControlesController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}