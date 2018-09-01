using CS.Eventos.IO.Domain.Core.Commands;
using System;

namespace CS.Eventos.IO.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
