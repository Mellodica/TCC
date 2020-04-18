using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Controllers
{
    
    public class LoginController : Controller
    {
       
       
        
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        

        public  IActionResult Logar( [FromForm]Login login)
        {
            if (login.Email =="breno" && login.Senha == "123456")
            {
                return RedirectToAction("Index", "Home");

            }
           else
            {
               

                return new ContentResult() { Content = "Não foi possível logar" };
            }
            
        }
    }
}