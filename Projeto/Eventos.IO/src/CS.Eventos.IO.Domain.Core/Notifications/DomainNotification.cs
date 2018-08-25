using CS.Eventos.IO.Domain.Core.Events;
using System;

namespace CS.Eventos.IO.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }

        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; } //Nome do evento
        public string Value { get; private set; } //Valor do evento
        public int Version { get; private set; }
    }
}
