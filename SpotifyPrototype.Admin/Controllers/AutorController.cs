using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyPrototype.Application.Streaming;
using SpotifyPrototype.Application.Streaming.Dto;

namespace SpotifyPrototype.Admin.Controllers
{
    [Authorize]
    public class AutorController(AutorService _AutorService) : Controller
    {
        public IActionResult Index()
        {
            var result = _AutorService.Obter();

            return View(result);
        }


        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(AutorDto dt)
        {
            if (ModelState.IsValid == false)
            {
                return View("Criar");
            }

            _AutorService.Salvar(dt);

            return RedirectToAction("Index");
        }
    }
}
