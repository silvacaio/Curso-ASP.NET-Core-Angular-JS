﻿
using System;

namespace CS.Eventos.IO.Domain.Eventos.Events
{
    public class EventoAtualizadoEvent : BaseEventoEvent
    {
        public EventoAtualizadoEvent(
                    Guid id,
                    string nome,
                    string descCurta,
                    string descLonga,
                    DateTime dataInicio,
                    DateTime dateFinal,
                    bool gratuito,
                    decimal valor,
                    bool online,
                    string nomeEmpresa)
        {
            Id = id;
            DescricaoLonga = descLonga;
            DescricaoCurta = descCurta;
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
