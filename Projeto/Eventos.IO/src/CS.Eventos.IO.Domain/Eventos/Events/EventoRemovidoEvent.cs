using System;

namespace CS.Eventos.IO.Domain.Eventos.Events
{
    public class EventoRemovidoEvent : BaseEventoEvent
    {
        public EventoRemovidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
