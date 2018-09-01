using AutoMapper;
using CS.Eventos.IO.Application.Interfaces;
using CS.Eventos.IO.Application.Services;
using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Core.Events;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Eventos.Commands;
using CS.Eventos.IO.Domain.Eventos.Events;
using CS.Eventos.IO.Domain.Eventos.Repository;
using CS.Eventos.IO.Domain.Interfaces;
using CS.Eventos.IO.Infra.Data.Context;
using CS.Eventos.IO.Infra.Data.Repository;
using CS.Eventos.IO.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace CS.Eventos.IO.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetServices));

            //Domain - Commands
            services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<RemoverEventoCommand>, EventoCommandHandler>();

            //Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoRemovidoEvent>, EventoEventHandler>();

            //Infra - Data
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EventosContext>();

            //Infra - Bus
            //services.AddScoped<IBus, InMemoryBus>();
        }
    }
}
