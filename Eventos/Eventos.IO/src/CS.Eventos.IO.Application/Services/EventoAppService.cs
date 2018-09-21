using AutoMapper;
using CS.Eventos.IO.Application.Interfaces;
using CS.Eventos.IO.Application.ViewModels;
using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Eventos.Commands;
using CS.Eventos.IO.Domain.Eventos.Repository;
using CS.Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CS.Eventos.IO.Application.Services
{
    public class EventoAppService : IEventoAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IEventoRepository _repository;
        private readonly IUser _user;

        public EventoAppService(IBus bus, IMapper mapper, IEventoRepository repository, IUser user)
        {
            _bus = bus;
            _mapper = mapper;
            _repository = repository;
            _user = user;
        }

        public void Registrar(EventoViewModel eventoViewModel)
        {
            var registroCommand = _mapper.Map<RegistrarEventoCommand>(eventoViewModel);
            _bus.SendCommand(registroCommand);
        }

        public void Atualizar(EventoViewModel eventoViewModel)
        {
            var atualizarCommand = _mapper.Map<AtualizarEventoCommand>(eventoViewModel);
            _bus.SendCommand(atualizarCommand);
        }

        public void Excluir(Guid id)
        {
            _bus.SendCommand(new RemoverEventoCommand(id));
        }

        public EventoViewModel ObertPorId(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_repository.ObterPorId(id));
        }

        public IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId)
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_repository.ObterEventoPorOrganizador(organizadorId));
        }

        public IEnumerable<EventoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_repository.ObterTodos());
        }

        public void AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var enderecoCommand = _mapper.Map<IncluirEnderecoEventoCommand>(enderecoViewModel);
            _bus.SendCommand(enderecoCommand);
        }

        public void AtualizarEndreco(EnderecoViewModel enderecoViewModel)
        {
            var enderecoCommand = _mapper.Map<AtualizarEnderecoEventoCommand>(enderecoViewModel);
            _bus.SendCommand(enderecoCommand);
        }

        public EnderecoViewModel ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(_repository.ObterEnderecoPorId(id));
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
