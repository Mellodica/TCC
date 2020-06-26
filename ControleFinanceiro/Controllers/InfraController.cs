using ControleFinanceiro.Controllers;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models.Infra;
using ControleFinanceiro.Models.ViewModels;
using ControleFinanceiro.Servico;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CrudAspNetMVC.Controllers
{
    [Authorize]
    public class InfraController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly ControlePessoalContext _context;
        private readonly InfraServicos infraServicos;
        private readonly UserManager<UsuarioApp> _userManager;//gerenciamento de usuário
        private readonly SignInManager<UsuarioApp> _signInManager;//registrar o acesso do usuário
        private readonly ILogger _logger;//registrar mensagens de Log e exibi-las no console

        public InfraController(
            IHostingEnvironment env,
            ControlePessoalContext context,
            UserManager<UsuarioApp> userManager,
            SignInManager<UsuarioApp> signInManager,
            ILogger<InfraController> logger)
        {
            _context = context;
            infraServicos = new InfraServicos(context);
            _env = env;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            
        }

        //GET: Logar
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Acessar(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);


            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //POST: Logar
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Acessar(AcessarViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Senha, model.LembrarDeMim, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário Autenticado.");
                    return RedirectToLocal(returnUrl);
                }
            }
            ModelState.AddModelError(string.Empty, "Falha na tentativa de login.");
            return View(model);
        }

        //GET: RegistrarNovoUsuario
        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegistrarNovoUsuario(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //POST: RegistrarNovoUsuario
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarNovoUsuario(UsuarioViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var usuario = new UsuarioApp
                {
                    UsuarioId = model.UsuarioId,
                    UserName = model.UserName,
                    Email = model.Email,
                    PrimeiroNome = model.PrimeiroNome,
                    DataNascimento = model.DataNascimento,
                    Sobrenome = model.Sobrenome

                };
                var result = await _userManager.CreateAsync(usuario, model.Password);               

                if (result.Succeeded)
                {
                   
                    _logger.LogInformation("Usuário criou uma nova conta!");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);

                    var logado = await _signInManager.PasswordSignInAsync(usuario.UserName, model.Password, false, false);
                    _logger.LogInformation("Usuário logado " + logado.Succeeded);

                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    _logger.LogInformation("Usuário acessou com a conta criada.");

                    return RedirectToAction(nameof(InfraController.Acessar), "Infra");
                }

                AddErrors(result);
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> PerfilUsuario(int? id)
        {
            return await PegarViewUsuarioPorId(id);
            //var user = await infraServicos.PegarUsuarioPorId(id);
            //return View(user);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PerfilUsuario(int id, [Bind("UsuarioId,Profissao,PrimeiroNome,Sobrenome,DataNascimento,SalarioId")] UsuarioViewModel usuario, IFormFile foto, string chkRemoverFoto)
        {
            if (id != usuario.UsuarioId)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var stream = new MemoryStream();
                    if (chkRemoverFoto != null)
                    {
                        usuario.Foto = null;
                    }
                    else
                    {
                        await foto.CopyToAsync(stream);
                        usuario.Foto = stream.ToArray();
                        usuario.FotoMimeType = foto.ContentType;
                    }

                    await infraServicos.UpdateAsync(usuario);

                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!await UsuarioExists(usuario.UsuarioId))
                    {
                        return RedirectToAction(nameof(Error), new { message = e.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ControlesController.Index), "Controles");
            }
            return View(usuario);
        }

        private async Task<bool> UsuarioExists(int id)
        {
            return await infraServicos.PegarUsuarioPorId(id) != null;
        }

        private async Task<IActionResult> PegarViewUsuarioPorId(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não providenciado" });
            }

            var usuario = await infraServicos.PegarUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Encontrado" });
            }

            return View(usuario);
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            //var user = await infraServicos.PegarUsuarioPorId(id);
            //return View(user);
            return await PegarViewUsuarioPorId(id.Value);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            return await PegarViewUsuarioPorId(id.Value);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        
        private IActionResult RedirectToLocal(string returnUrl)
        {
            _logger.LogInformation("returURL" + returnUrl);
            _logger.LogInformation("isLocal" + Url.IsLocalUrl(returnUrl));

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                //redireciona a pagina de controle após logar
                return RedirectToAction(nameof(ControlesController.Index), "Controles");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await infraServicos.DeletarUsuarioPorId(id);
            TempData["Message"] = "Conta de usuario " + usuario.UserName.ToUpper() + " foi Excluido";
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //Logout
        [HttpGet]
        public async Task<IActionResult> Sair()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Usuário realizou logout.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<FileContentResult> GetFoto(int id)
        {
            UsuarioApp usuario = await infraServicos.PegarUsuarioPorId(id);
            if (usuario != null)
            {
                return File(usuario.Foto, usuario.FotoMimeType);
            }
            return null;
        }

        public async Task<FileResult> DownloadFoto(int id)
        {
            UsuarioApp usuario = await infraServicos.PegarUsuarioPorId(id);
            string nomeArquivo = "Foto" + usuario.UsuarioId.ToString().Trim() + ".jpg";
            FileStream fileStream = new FileStream(Path.Combine(_env.WebRootPath, nomeArquivo), FileMode.Create, FileAccess.Write);
            fileStream.Write(usuario.Foto, 0, usuario.Foto.Length);
            fileStream.Close();

            IFileProvider provider = new PhysicalFileProvider(_env.WebRootPath);
            IFileInfo fileInfo = provider.GetFileInfo(nomeArquivo);
            var readStream = fileInfo.CreateReadStream();
            return File(readStream, usuario.FotoMimeType, nomeArquivo);
        }

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