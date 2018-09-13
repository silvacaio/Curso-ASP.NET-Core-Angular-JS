﻿using CS.Eventos.IO.Domain.Eventos;
using CS.Eventos.IO.Domain.Eventos.Repository;
using CS.Eventos.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace CS.Eventos.IO.Infra.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(EventosContext context) : base(context)
        {
        }

        public override IEnumerable<Evento> ObterTodos()
        {
            var sql = "select * from eventos e where e.excluido = 0 order by e.datefinal desc";
            return Db.Database.GetDbConnection().Query<Evento>(sql);
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            var sql = @"SELECT * FROM Enderecos E " +
                     "WHERE E.Id = @uid";

            var endereco = Db.Database.GetDbConnection().Query<Endereco>(sql, new { uid = id });

            return endereco.SingleOrDefault();
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            var sql = @"select * from eventos e " +
               "where e.excluido = 0" +
               "and e.organizadorid = @oid" +
               "order by e.datefinal desc";

            return Db.Database.GetDbConnection().Query<Evento>(sql, new { oid = organizadorId });
        }

        public override Evento ObterPorId(Guid id)
        {
            var sql = @"select * from eventos e " +
                "left join enderecos en " +
                "on e.Id = en.EventoId" +
                "where e.Id = @uid";

            var evento = Db.Database.GetDbConnection().Query<Evento, Endereco, Evento>(sql,
                (e, en) =>
                {
                    if (en != null)
                        e.AtributirEndereco(en);

                    return e;
                }, new { uid = id });

            return evento.FirstOrDefault();
        }
    }
}
