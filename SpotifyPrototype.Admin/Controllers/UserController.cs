using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyPrototype.Application;
using SpotifyPrototype.Application.Admin.Dto;

namespace SpotifyPrototype.Admin.Controllers
{
    [Authorize]
    public class UserController(UsuarioAdminService usuarioAdminService) : Controller
    {
        public IActionResult Index()
        {
            var result = usuarioAdminService.ObterTodos();

            return View(result);
        }

        [AllowAnonymous]
        public IActionResult Criar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Salvar(UsuarioAdminDto dt)
        {
            if (ModelState.IsValid == false)
            {
                return View("Criar");
            }

            usuarioAdminService.Salvar(dt);

            return RedirectToAction("Index");
        }
    }
}
