using CS.Eventos.IO.Domain.Core.Commands;
using System;

namespace CS.Eventos.IO.Domain.Eventos.Commands
{
    public class AtualizarEnderecoEventoCommand : Command
    {
        public AtualizarEnderecoEventoCommand(Guid guid, string logradouro, string numero, string complemento, string bairro, string cEP, string cidade, string estado, Guid? eventoId)
        {
            Id = guid;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cEP;
            Cidade = cidade;
            Estado = estado;
            EventoId = eventoId;
        }

        public Guid Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Guid? EventoId { get; set; }
    }
}
