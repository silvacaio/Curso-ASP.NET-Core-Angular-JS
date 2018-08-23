using CS.Eventos.IO.Domain.Core.Events;
using CS.Eventos.IO.Domain.Eventos.Events;

namespace CS.Eventos.IO.Domain.Eventos.EventHandlers
{
    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
           IHandler<EventoAtualizadoEvent>,
           IHandler<EventoRemovidoEvent>
    {
        public void Handle(EventoRegistradoEvent message)
        {
            //enviar e-mail
            //registrar log
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            //enviar e-mail
            //registrar log
        }

        public void Handle(EventoRemovidoEvent message)
        {
            //enviar e-mail
            //registrar log
        }
    }
}
