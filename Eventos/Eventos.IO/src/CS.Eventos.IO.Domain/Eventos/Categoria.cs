using CS.Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace CS.Eventos.IO.Domain.Eventos
{
    public class Categoria : Entity<Categoria>
    {


        //Construtor para o EF
        protected Categoria()
        {

        }

        public Categoria(Guid id)
        {
            Id = id;
        }

        public string Nome { get; private set; }
        public virtual ICollection<Evento> Eventos { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}