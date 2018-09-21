using CS.Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CS.Evento.IO.Site.Controllers
{
    public class ErroController : Controller
    {

        private readonly IUser _user;

        public ErroController(IUser user)
        {
            _user = user;
        }

        [Route("/erro-de-aplicacao")]
        [Route("/erro-de-aplicacao/{id}")]
        public IActionResult Erros(string id)
        {
            switch (id)
            {
                case "404":
                    return View("NotFound");
                case "403": //FORBIDEN
                case "401": //NÂO ESTA LOGADO
                    if (!_user.IsAuthenticated()) return RedirectToAction("Login", "Account");
                    return RedirectToAction("Login", "AccessDenied");
                default:
                    return View("Error");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
