using CS.Eventos.IO.Domain.Core.Events;
using System;

namespace CS.Eventos.IO.Domain.Eventos.Events
{
    public class EnderecoEventoAdicionadoEvent : Event
    {
        public EnderecoEventoAdicionadoEvent(Guid enderecoId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, Guid eventoId)
        {
            Id = enderecoId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            AggregateId = eventoId; //O endereco esta na raiz de agregação do Evento, por isso o aggregete Id é o Evento
        }

        public Guid Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}
