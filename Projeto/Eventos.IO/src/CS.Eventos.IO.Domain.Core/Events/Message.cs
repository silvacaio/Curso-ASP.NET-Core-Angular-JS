using System;

namespace CS.Eventos.IO.Domain.Core.Events
{
    public abstract class Message
    {
        protected Message()
        {
            MessageType = GetType().Name; //nome da classe
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; set; }
    }
}
