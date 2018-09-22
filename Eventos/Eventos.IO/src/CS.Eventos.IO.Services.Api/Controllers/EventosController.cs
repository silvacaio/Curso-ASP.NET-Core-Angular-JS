using System;
using System.Collections.Generic;
using AutoMapper;
using CS.Eventos.IO.Application.Interfaces;
using CS.Eventos.IO.Application.ViewModels;
using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Eventos.Commands;
using CS.Eventos.IO.Domain.Eventos.Repository;
using CS.Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CS.Eventos.IO.Services.Api.Controllers
{
    public class EventosController : BaseController
    {
        private readonly IEventoAppService _eventoAppService;
        private readonly IBus _bus;
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;

        public EventosController(IDomainNotificationHandler<DomainNotification> notifications,
           IUser user,
           IEventoAppService eventoAppService,
           IBus bus,
           IEventoRepository eventoRepository,
           IMapper mapper) : base(notifications, user, bus)
        {
            _eventoAppService = eventoAppService;
            _bus = bus;
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("eventos")]
        public IEnumerable<EventoViewModel> Get()
        {
            return _eventoAppService.ObterTodos();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("eventos/{id:guid}")]
        public EventoViewModel Get(Guid id, int version)
        {
            return _eventoAppService.ObterPorId(id);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("eventos/categorias")]
        public IEnumerable<CategoriaViewModel> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_eventoRepository.ObterCategorias());
        }

        [HttpPost]
        [Route("eventos")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Post([FromForm]EventoViewModel eventoViewModel)
        {
            if(!ModelState.IsValid)
            {
                NotificarErrorModelInvalida();
                return Response();
            }

            var eventoCommand = _mapper.Map<RegistrarEventoCommand>(eventoViewModel);

            _bus.SendCommand(eventoCommand);
            return Response(eventoCommand);
        }

        [HttpPut]
        [Route("eventos")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Put([FromForm]AtualizarEventoCommand eventoCommand)
        {
            _bus.SendCommand(eventoCommand);
            return Response(eventoCommand);
        }

        [HttpPost]
        [Route("eventos/{id:guid}")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Delete(Guid id)
        {
            _eventoAppService.Excluir(id);
            return Response();
        }
    }
}