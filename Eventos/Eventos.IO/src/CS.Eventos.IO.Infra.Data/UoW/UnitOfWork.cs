using CS.Eventos.IO.Domain.Core.Commands;
using CS.Eventos.IO.Domain.Interfaces;
using CS.Eventos.IO.Infra.Data.Context;

namespace CS.Eventos.IO.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventosContext _context;

        public UnitOfWork(EventosContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsEffected = _context.SaveChanges();
            return new CommandResponse(rowsEffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
