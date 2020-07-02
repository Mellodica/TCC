using System.Linq;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult ListarProdutos(int id)
        {

            var lista = _context.Produtos.Where(p => p.ListaMercado.MercadoId == id).ToList();
            ViewBag.Mercado = id;
            return PartialView(lista);
        }

        [Authorize]
        public ActionResult SalvarProdutos(int quantidade,
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

            return Json(new { Resultado = prod.ProdutoId }, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var result = false;
            var item = _context.Produtos.Find(id);

            if (item != null)
            {
                _context.Produtos.Remove(item);
                _context.SaveChanges();
                result = true;
            }
            return Json(new { Resultado = result }, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}