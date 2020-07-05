using System.Linq;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControleFinanceiro.Controllers
{
    [Authorize]
    public class ProdutosMercadoController : Controller
    {
        private readonly ControlePessoalContext _context;

        public ProdutosMercadoController(ControlePessoalContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult ListarProdutos(int id)
        {

            var lista = _context.Produtos.Where(p => p.ListaMercado.MercadoId == id).ToList();
            ViewBag.Mercado = id;
            return PartialView(lista);
        }

        [Authorize]
        public IActionResult SalvarProdutos(int quantidade,
            string produto,
            int valorunitario,
            int idMercado)
        {

            var prod = new ProdutoMercado()
            {
                Quantidade = quantidade
                ,
                ProdutoNome = produto
                ,
                ValorUnitario = valorunitario
                ,
                ListaMercado = _context.Mercados.Find(idMercado)
            };

            _context.Produtos.Add(prod);
            _context.SaveChanges();

            return Json(new { Resultado = prod.ProdutoId }, new JsonSerializerSettings());
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var result = false;
            var item = _context.Produtos.Find(id);

            if (item != null)
            {
                _context.Produtos.Remove(item);
                _context.SaveChanges();
                result = true;
            }
            return Json(new { Resultado = result }, new JsonSerializerSettings());
        }
    }
}