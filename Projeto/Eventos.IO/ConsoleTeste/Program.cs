using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Core.Commands;
using CS.Eventos.IO.Domain.Core.Events;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Eventos;
using CS.Eventos.IO.Domain.Eventos.Commands;
using CS.Eventos.IO.Domain.Eventos.Events;
using CS.Eventos.IO.Domain.Eventos.Repository;
using CS.Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new FakeBus();
            //comando de registro com sucesso
            var command = new RegistrarEventoCommand("Evento 1",
                                                     DateTime.Now.AddDays(1),
                                                     DateTime.Now.AddDays(2),
                                                     true,
                                                     0,
                                                     true,
                                                     "CS");
            Inicio(command);
            bus.SendCommand(command);
            Fim(command);

            //Comando com erros
            command = new RegistrarEventoCommand("",
                                                     DateTime.Now,
                                                     DateTime.Now,
                                                     true,
                                                     777,
                                                     true,
                                                     "");

            Inicio(command);
            bus.SendCommand(command);
            Fim(command);

            //Atualizando com sucesso
            var command2 = new AtualizarEventoCommand(Guid.NewGuid(),
                                                    "Evento 1",
                                                     "",
                                                     "",
                                                     DateTime.Now.AddDays(1),
                                                     DateTime.Now.AddDays(2),
                                                     true,
                                                     0,
                                                     true,
                                                     "CS");

            Inicio(command2);
            bus.SendCommand(command2);
            Fim(command2);

            //Excluir evento
            var command3 = new RemoverEventoCommand(Guid.NewGuid());

            Inicio(command3);
            bus.SendCommand(command3);
            Fim(command3);



            Console.ReadKey();
        }

        private static void Inicio(Message message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Inicio do Comando { message.MessageType }");
        }

        private static void Fim(Message message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Fim do Comando { message.MessageType }");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************");
            Console.WriteLine("");
        }

        public class FakeEventoRepository : IEventoRepository
        {
            public void Add(Evento obj)
            {
                //throw new NotImplementedException();
            }

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public IEnumerable<Evento> Find(Expression<Func<Evento, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Evento> GetAll()
            {
                throw new NotImplementedException();
            }

            public Evento GetById(Guid id)
            {
                return new Evento("Fake", DateTime.Now, DateTime.Now, true, 0, true, "EmpresaFake");
            }

            public void Remove(Evento obj)
            {
                throw new NotImplementedException();
            }

            public void Remove(Guid id)
            {
                //throw new NotImplementedException();
            }

            public int SaveChanges()
            {
                throw new NotImplementedException();
            }

            public void Update(Evento obj)
            {
                // throw new NotImplementedException();
            }
        }

        public class FakeUow : IUnitOfWork
        {
            public CommandResponse Commit()
            {
                return new CommandResponse(true);
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        internal class FakeBus : IBus
        {
            public void RaiseEvent<T>(T theEvent) where T : Event
            {
                Publish(theEvent);
            }

            public void SendCommand<T>(T theCommand) where T : Command
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Comando {theCommand.MessageType} chamado");
                Publish(theCommand);
            }

            private static void Publish<T>(T message) where T : Message
            {
                var msgType = message.MessageType;

                if (msgType.Equals("DomainNotification"))
                {
                    var obj = new DomainNotificationHandler();
                    ((IDomainNotificationHandler<T>)obj).Handle(message);
                }

                if (msgType.Equals("RegistrarEventoCommand") ||
                    msgType.Equals("AtualizarEventoCommand") ||
                    msgType.Equals("RemoverEventoCommand"))
                {
                    var obj = new EventoCommandHandler(new FakeEventoRepository(), new FakeUow(), new FakeBus(), new DomainNotificationHandler());
                    ((IHandler<T>)obj).Handle(message);
                }

                if (msgType.Equals("EventoRegistradoEvent") ||
                    msgType.Equals("EventoAtualizadoEvent") ||
                    msgType.Equals("EventoRemovidoEvent"))
                {
                    var obj = new EventoEventHandler();
                    ((IHandler<T>)obj).Handle(message);
                }
            }
        }
    }
}
