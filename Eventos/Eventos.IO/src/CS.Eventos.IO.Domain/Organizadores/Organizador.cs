using CS.Eventos.IO.Domain.Core.Models;
using CS.Eventos.IO.Domain.Eventos;
using System;
using System.Collections.Generic;

namespace CS.Eventos.IO.Domain.Organizadores
{
    public class Organizador : Entity<Organizador>
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        //EF propriedade de navegação
        public ICollection<Evento> Eventos { get; private set; }

        protected Organizador()
        {

        }     

        public Organizador(Guid id, string nome, string cPF, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            Email = email;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}