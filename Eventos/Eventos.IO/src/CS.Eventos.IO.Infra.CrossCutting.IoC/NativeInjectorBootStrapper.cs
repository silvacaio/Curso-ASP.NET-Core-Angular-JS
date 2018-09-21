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
using CS.Eventos.IO.Domain.Organizadores.Commands;
using CS.Eventos.IO.Domain.Organizadores.Events;
using CS.Eventos.IO.Domain.Organizadores.Repository;
using CS.Eventos.IO.Infra.CrossCutting.AspNetFilters;
using CS.Eventos.IO.Infra.CrossCutting.Bus;
using CS.Eventos.IO.Infra.CrossCutting.Identity.Models;
using CS.Eventos.IO.Infra.Data.Context;
using CS.Eventos.IO.Infra.Data.Repository;
using CS.Eventos.IO.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS.Eventos.IO.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddScoped<IOrganizadorAppService, OrganizadorAppService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            //Domain - Commands
            services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<RemoverEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<IncluirEnderecoEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEnderecoEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<RegistrarOrganizadorCommand>, OrganizadorCommandHandler>();

            //Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoRemovidoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EnderecoEventoAdicionadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EnderecoEventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<OrganizadorRegistradoEvent>, OrganizadorEventHandler>();

            //Infra - Data
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EventosContext>();

            //Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();

            //Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            //Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalActionLogger>();
        }
    }
}
