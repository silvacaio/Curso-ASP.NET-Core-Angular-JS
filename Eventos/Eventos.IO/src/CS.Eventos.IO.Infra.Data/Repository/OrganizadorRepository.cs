
using CS.Eventos.IO.Domain.Organizadores;
using CS.Eventos.IO.Domain.Organizadores.Repository;
using CS.Eventos.IO.Infra.Data.Context;

namespace CS.Eventos.IO.Infra.Data.Repository
{
    public class OrganizadorRepository : Repository<Organizador>, IOrganizadorRepository
    {
        public OrganizadorRepository(EventosContext context) : base(context)
        {
        }
    }
}
