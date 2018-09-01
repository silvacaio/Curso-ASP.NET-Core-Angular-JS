using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS.Evento.IO.Site.Data;
using CS.Eventos.IO.Application.ViewModels;
using CS.Eventos.IO.Application.Interfaces;

namespace CS.Evento.IO.Site.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoAppService _eventoAppService;

        public EventosController(IEventoAppService eventoAppService)
        {
            _eventoAppService = eventoAppService;
        }

        // GET: Eventos
        public IActionResult Index()
        {
            return View(_eventoAppService.ObterTodos());
        }

        // GET: Eventos/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = _eventoAppService.ObertPorId(id.Value);

            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return View(eventoViewModel);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,DescricaoCurta,DescricaoLonga,DataInicio,DateFinal,Gratuito,Valor,Online,NomeEmpresa,CategoriaId,OrganizadorId")] EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid) return View(eventoViewModel);

            _eventoAppService.Registrar(eventoViewModel);

            return View(eventoViewModel);
        }

        // GET: Eventos/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = _eventoAppService.ObertPorId(id.Value);
            if (eventoViewModel == null)
            {
                return NotFound();
            }
            
            return View(eventoViewModel);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Nome,DescricaoCurta,DescricaoLonga,DataInicio,DateFinal,Gratuito,Valor,Online,NomeEmpresa,CategoriaId,OrganizadorId")] EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid) return View(eventoViewModel);

            _eventoAppService.Atualizar(eventoViewModel);

            //TODO: validar se a operação ocorreu com suceso

            return View(eventoViewModel);
        }

        // GET: Eventos/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = _eventoAppService.ObertPorId(id.Value);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return View(eventoViewModel);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _eventoAppService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }       
    }
}
