using System;
using Microsoft.AspNetCore.Mvc;
using CS.Eventos.IO.Application.ViewModels;
using CS.Eventos.IO.Application.Interfaces;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CS.Evento.IO.Site.Controllers
{
    public class EventosController : BaseController
    {
        private readonly IEventoAppService _eventoAppService;

        public EventosController(IEventoAppService eventoAppService,
                        IDomainNotificationHandler<DomainNotification> notifications,
                          IUser user) : base(notifications, user)
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

        [Authorize]
        // GET: Eventos/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid) return View(eventoViewModel);

            eventoViewModel.OrganizadorId = OrganizadorId;
            _eventoAppService.Registrar(eventoViewModel);

            ViewBag.RetornoPost = OperacaoValida() ? "success,Evento registrado com sucesso." : "error,Evento não registrado. Verifique as mensagens.";

            return View(eventoViewModel);
        }

        [Authorize]
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
        [Authorize]
        public IActionResult Edit([Bind("Id,Nome,DescricaoCurta,DescricaoLonga,DataInicio,DateFinal,Gratuito,Valor,Online,NomeEmpresa,CategoriaId,OrganizadorId")] EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid) return View(eventoViewModel);

            eventoViewModel.OrganizadorId = OrganizadorId; //Não camada de DOMAIN é validado se este organizador é realmente o dono do EVENTO

            _eventoAppService.Atualizar(eventoViewModel);

            ViewBag.RetornoPost = OperacaoValida() ? "success,Evento atualizado com sucesso." : "error,Evento não pode ser atualizado. Verifique as mensagens.";

            var eventoAtualizado = _eventoAppService.ObertPorId(eventoViewModel.Id);
            if (eventoAtualizado.Online)
                eventoViewModel.Endereco = null;
            else
                eventoViewModel = eventoAtualizado;

            return View(eventoViewModel);
        }

        [Authorize]
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
        [Authorize]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _eventoAppService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult IncluirEndereco(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = _eventoAppService.ObertPorId(id.Value);
            return PartialView("_IncluirEndereco", eventoViewModel);
        }

        public IActionResult AtualizarEndereco(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = _eventoAppService.ObertPorId(id.Value);
            return PartialView("_AtualizarEndereco", eventoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IncluirEndereco(EventoViewModel eventoViewModel)
        {
            ModelState.Clear();// Não valida a model state pois nesse momento somente a parte do endereço deve ser validada
            eventoViewModel.Endereco.EventoId = eventoViewModel.Id;
            _eventoAppService.AdicionarEndereco(eventoViewModel.Endereco);

            if (OperacaoValida())
            {
                string url = Url.Action("ObterEndereco", "Eventos", new { id = eventoViewModel.Id });
                return Json(new { success = true, url = url });
            }

            return PartialView("_IncluirEndereco", eventoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarEndereco(EventoViewModel eventoViewModel)
        {
            ModelState.Clear();// Não valida a model state pois nesse momento somente a parte do endereço deve ser validada
            _eventoAppService.AtualizarEndreco(eventoViewModel.Endereco);

            if (OperacaoValida())
            {
                string url = Url.Action("ObterEndereco", "Eventos", new { id = eventoViewModel.Id });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarEndereco", eventoViewModel);
        }

        [HttpGet]
        public IActionResult ObterEndereco(Guid id)
        {
            return PartialView("_DetalhesEndereco", _eventoAppService.ObertPorId(id));
        }
    }
}
