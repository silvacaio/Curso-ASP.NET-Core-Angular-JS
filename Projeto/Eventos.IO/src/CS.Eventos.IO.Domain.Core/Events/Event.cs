using System;

namespace CS.Eventos.IO.Domain.Core.Events
{
   public abstract class Event : Message
    {
        public DateTime TimeStamp { get; set; }
        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
