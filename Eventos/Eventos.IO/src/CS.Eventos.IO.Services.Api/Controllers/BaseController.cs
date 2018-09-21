using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CS.Eventos.IO.Services.Api.Controllers
{
    [Produces("application/json")] //só trabalhar com JSON    
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUser _user;
        private readonly IBus _bus;
        protected Guid OrganizadorId { get; set; }

        protected BaseController(IDomainNotificationHandler<DomainNotification> notifications,
                                 IUser user,
                                 IBus bus)
        {
            _notifications = notifications;
            _bus = bus;
            _user = user;

            if (user.IsAuthenticated())
                OrganizadorId = user.GetUserId();
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                }); //status code  200
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            }); //status code 400
        }

        protected bool OperacaoValida()
        {
            return !_notifications.HasNotifications();
        }

        protected void NotificarErrorModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                NotificarErro(string.Empty, erro.ErrorMessage);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _bus.RaiseEvent(new DomainNotification(codigo, mensagem));
        }
    }
}