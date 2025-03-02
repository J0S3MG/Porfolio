using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppServer.Controllers;
using WebAppServer.Models;
using WebAppServer.Services;

namespace WebAppServer.VievControllers
{
    public class AccountController : Controller
    {
        readonly UsuarioService _usuariosService;
        readonly ILogger<HomeController> _logger;

        public AccountController(ILogger<HomeController> logger, UsuarioService usuariosService)
        {
            _logger = logger;
            _usuariosService = usuariosService;
        }

        [AllowAnonymous]
        async public Task<ViewResult> Login(string ReturnUrl)
        {
            return View(new Usuario
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuario usuario, string returnUrl = "/")
        {
            var result = await _usuariosService.VerificarLogin(usuario);

            //if (usuario == null) error
            if (result==null)
            {
                ModelState.AddModelError("", "Usuario o contraseña no válidos.");
                return View();
            }

            var claims = new List<Claim>()
            {
             new Claim(ClaimTypes.Name, usuario.Nombre),
            };

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("Cookies", principal);

            return Redirect(returnUrl);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await HttpContext.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
