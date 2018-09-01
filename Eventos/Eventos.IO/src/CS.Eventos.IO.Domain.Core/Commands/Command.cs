using CS.Eventos.IO.Domain.Core.Events;
using System;

namespace CS.Eventos.IO.Domain.Core.Commands
{
    public class Command : Message
    {
        public Command()
        {
            TimeStamp = DateTime.Now;
        }
        public DateTime TimeStamp { get; set; } //momento que o evento foi disparado
    }
}
