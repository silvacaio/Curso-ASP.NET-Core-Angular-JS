using System;

namespace CS.Eventos.IO.Domain.Eventos.Commands
{
    public class RemoverEventoCommand : BaseEventoCommand
    {
        public RemoverEventoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
