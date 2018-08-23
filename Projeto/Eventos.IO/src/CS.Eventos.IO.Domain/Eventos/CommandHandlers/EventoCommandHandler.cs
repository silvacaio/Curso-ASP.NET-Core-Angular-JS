using CS.Eventos.IO.Domain.CommandHandlers;
using CS.Eventos.IO.Domain.Core.Events;
using CS.Eventos.IO.Domain.Eventos.Commands;
using CS.Eventos.IO.Domain.Eventos.Repository;
using CS.Eventos.IO.Domain.Interfaces;

namespace CS.Eventos.IO.Domain.Eventos.CommandHandlers
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<RemoverEventoCommand>,
        IHandler<AtualizarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow) : base(uow)
        {
            _eventoRepository = eventoRepository;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var evento = new Evento(message.Nome, message.DataInicio, message.DateFinal, message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);
            if (!evento.EhValido())
            {
                NotificarValidacoesErro(evento.ValidationResult);
                return;
            }

            // TODO: 
            //Validações de negocio!
                //valida se já existe um evento com o nome igual, mesma data...
                //Organizador pode registrar o evento?

            //Persistencia
            _eventoRepository.Add(evento);

            if(Commit())
            {
                //Notificar processo concluido
            }
        }

        public void Handle(RemoverEventoCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarEventoCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}
