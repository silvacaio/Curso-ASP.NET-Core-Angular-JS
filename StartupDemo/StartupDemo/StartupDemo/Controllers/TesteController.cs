using Microsoft.AspNetCore.Mvc;
using System;

namespace StartupDemo.Controllers
{
    public class TesteController : Controller
    {
        [Route("dashboard/tela")]
        [Route("dashboard/tela/{id:int}/{valor:guid}")]
        public IActionResult Index(int id, Guid valor)
        {
            // return View();
            //return Json()
            return RedirectToAction("Teste");
        }

        public IActionResult Teste()
        {
            return View("Index");
            //return Json()
        }
    }
}