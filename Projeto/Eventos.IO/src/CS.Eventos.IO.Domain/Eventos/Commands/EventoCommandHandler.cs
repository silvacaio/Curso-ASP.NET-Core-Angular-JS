using CS.Eventos.IO.Domain.CommandHandlers;
using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Core.Events;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Eventos.Commands;
using CS.Eventos.IO.Domain.Eventos.Events;
using CS.Eventos.IO.Domain.Eventos.Repository;
using CS.Eventos.IO.Domain.Interfaces;
using System;
using static CS.Eventos.IO.Domain.Eventos.Evento;

namespace CS.Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<RemoverEventoCommand>,
        IHandler<AtualizarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IBus _bus;

        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow,
                                    IBus bus,
                                    IDomainNotificationHandler<DomainNotification> _notification) : base(uow, bus, _notification)
        {
            _eventoRepository = eventoRepository;
            _bus = bus;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var evento = new Evento(message.Nome, message.DataInicio, message.DateFinal, message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);
            if (!EventoValido(evento)) return;

            // TODO: 
            //Validações de negocio!
            //valida se já existe um evento com o nome igual, mesma data...
            //Organizador pode registrar o evento?

            //Persistencia
            _eventoRepository.Add(evento);

            if (Commit())
            {
                //Notificar processo concluido
                Console.WriteLine("Evento registro com sucesso.");
                _bus.RaiseEvent(new EventoRegistradoEvent(
                                        evento.Id,
                                        evento.Nome,
                                        evento.DataInicio,
                                        evento.DateFinal,
                                        evento.Gratuito,
                                        evento.Valor,
                                        evento.Online,
                                        evento.NomeEmpresa));
            }
        }

        public void Handle(RemoverEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;
            _eventoRepository.Remove(message.Id);

            if (Commit())
                _bus.RaiseEvent(new EventoRemovidoEvent(message.Id));

        }

        public void Handle(AtualizarEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;

            var evento = EventoFactory.NovoEventoCompleto(message.Id,
                                                          message.Nome,
                                                          message.DataInicio,
                                                          message.DateFinal,
                                                          message.Gratuito,
                                                          message.Valor,
                                                          message.Online,
                                                          message.NomeEmpresa,
                                                          null);

            if (!EventoValido(evento)) return;

            _eventoRepository.Update(evento);

            if (Commit())
            {
                //Notificar processo concluido                
                _bus.RaiseEvent(new EventoAtualizadoEvent(
                                        evento.Id,
                                        evento.Nome,
                                        evento.DescricaoCurta,
                                        evento.DescricaoLonga,
                                        evento.DataInicio,
                                        evento.DateFinal,
                                        evento.Gratuito,
                                        evento.Valor,
                                        evento.Online,
                                        evento.NomeEmpresa));
            }
        }

        private bool EventoValido(Evento evento)
        {
            if (evento.EhValido()) return true;

            NotificarValidacoesErro(evento.ValidationResult);
            return false;
        }

        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _eventoRepository.GetById(id);
            if (evento != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrado"));
            return false;
        }
    }
}
