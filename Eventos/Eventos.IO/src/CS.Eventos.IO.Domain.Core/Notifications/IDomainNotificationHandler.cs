using CS.Eventos.IO.Domain.Core.Events;
using System.Collections.Generic;

namespace CS.Eventos.IO.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<TEntity> : IHandler<TEntity> where TEntity : Message
    {
        bool HasNotifications();
        List<TEntity> GetNotifications();
    }
}
