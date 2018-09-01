using CS.Eventos.IO.Domain.Core.Models;
using FluentValidation;
using System;

namespace CS.Eventos.IO.Domain.Eventos
{
    public class Endereco : Entity<Endereco>
    {
        public Endereco(Guid id, string logradouro, string numero, string complemento, string bairro, string cEP, string cidade, string estado, Guid? eventoId)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cEP;
            Cidade = cidade;
            Estado = estado;
            EventoId = eventoId;
        }

        protected Endereco() { }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Guid? EventoId { get; private set; }

        //EF propriedades de navegação
        public virtual Evento Evento { get; private set; }

        public override bool EhValido()
        {
            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("")
                .Length(2, 150).WithMessage("");  //TODO: mensagens de erro

            //TODO: Adicionar validações do endereço


            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}