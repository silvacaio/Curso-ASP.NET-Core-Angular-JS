using CS.Eventos.IO.Domain.Core.Events;
using System;

namespace CS.Eventos.IO.Domain.Eventos.Events
{
    public class EventoRegistradoEvent : BaseEventoEvent
    {
        public EventoRegistradoEvent(
                    Guid id,
                    string nome,                  
                    DateTime dataInicio,
                    DateTime dateFinal,
                    bool gratuito,
                    decimal valor,
                    bool online,
                    string nomeEmpresa)
        {
            Id = id;           
            Nome = nome;
            DataInicio = dataInicio;
            DateFinal = dateFinal;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;

            AggregateId = id;
        }
    }
}
