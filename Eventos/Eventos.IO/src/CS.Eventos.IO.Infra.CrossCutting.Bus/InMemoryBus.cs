using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Core.Commands;
using CS.Eventos.IO.Domain.Core.Events;
using CS.Eventos.IO.Domain.Core.Notifications;
using System;

namespace CS.Eventos.IO.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        //Metodo de acesso ao container de injeção de dependencia
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }
    }
}
