using CS.Eventos.IO.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Eventos.IO.Application.Interfaces
{
    public interface IOrganizadorAppService : IDisposable
    {
        void Registrar(OrganizadorViewModel organizadorViewModel);
    }
}
