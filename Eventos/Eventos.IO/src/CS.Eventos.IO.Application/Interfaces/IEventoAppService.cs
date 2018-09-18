using CS.Eventos.IO.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CS.Eventos.IO.Application.Interfaces
{
    public interface IEventoAppService : IDisposable
    {
        void Registrar(EventoViewModel eventoViewModel);
        IEnumerable<EventoViewModel> ObterTodos();
        IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId);
        EventoViewModel ObertPorId(Guid id);
        void Atualizar(EventoViewModel eventoViewModel);
        void Excluir(Guid id);
        void AdicionarEndereco(EnderecoViewModel enderecoViewModel);
        void AtualizarEndreco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel ObterEnderecoPorId(Guid id);
    }
}
