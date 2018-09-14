using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace CS.Evento.IO.Site.Areas.Identity
{
    public class BasePage : PageModel
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUser _user;
        public Guid OrganizadorId { get; set; }

        public BasePage(IDomainNotificationHandler<DomainNotification> notifications, IUser user)
        {
            _notifications = notifications;
            _user = user;

            if (_user.IsAuthenticated())
                OrganizadorId = _user.GetUserId();
        }

        protected bool OperacaoValida()
        {
            return !_notifications.HasNotifications();
        }
    }
}
