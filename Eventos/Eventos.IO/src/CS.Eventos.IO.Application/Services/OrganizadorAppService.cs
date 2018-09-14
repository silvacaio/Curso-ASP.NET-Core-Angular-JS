using AutoMapper;
using CS.Eventos.IO.Application.Interfaces;
using CS.Eventos.IO.Application.ViewModels;
using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Organizadores.Commands;
using CS.Eventos.IO.Domain.Organizadores.Repository;

namespace CS.Eventos.IO.Application.Services
{
    public class OrganizadorAppService : IOrganizadorAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IOrganizadorRepository _organizadorRepository;

        public OrganizadorAppService(IBus bus, IMapper mapper, IOrganizadorRepository organizadorRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _organizadorRepository = organizadorRepository;
        }

        public void Registrar(OrganizadorViewModel organizadorViewModel)
        {
            var registroCommand = _mapper.Map<RegistrarOrganizadorCommand>(organizadorViewModel);
            _bus.SendCommand(registroCommand);
        }

        public void Dispose()
        {
            _organizadorRepository.Dispose();
        }

    }
}
