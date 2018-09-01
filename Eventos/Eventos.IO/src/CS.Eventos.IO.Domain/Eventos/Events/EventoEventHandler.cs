using CS.Eventos.IO.Domain.Core.Events;
using CS.Eventos.IO.Domain.Eventos.Events;

namespace CS.Eventos.IO.Domain.Eventos.Events
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

            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("Comando registrado.");
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            //enviar e-mail
            //registrar log
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("Comando atualizado.");
        }

        public void Handle(EventoRemovidoEvent message)
        {
            //enviar e-mail
            //registrar log
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("Comando removido.");
        }
    }
}
