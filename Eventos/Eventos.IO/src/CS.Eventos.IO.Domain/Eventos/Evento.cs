using CS.Eventos.IO.Domain.Core.Models;
using CS.Eventos.IO.Domain.Organizadores;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CS.Eventos.IO.Domain.Eventos
{
    public class Evento : Entity<Evento>
    {
        protected Evento() { }

        public Evento(string nome,
                      DateTime dataInicio,
                      DateTime dateFinal,
                      bool gratuito,
                      decimal valor,
                      bool online,
                      string nomeEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInicio = dataInicio;
            DateFinal = dateFinal;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
        }

        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DateFinal { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public bool Online { get; private set; }
        public string NomeEmpresa { get; private set; }
        public bool Excluido { get; private set; }
        public ICollection<Tags> Tags { get; private set; }

        public Guid? CategoriaId { get; private set; }
        public Guid? EnderecoId { get; private set; }
        public Guid OrganizadorId { get; private set; }

        //EF propriedades de navegação
        public virtual Categoria Categoria { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual Organizador Organizador { get; private set; }

        #region AD-HOC setters
        public void AtributirEndereco(Endereco endereco)
        {
            if (!endereco.EhValido()) return;

            Endereco = endereco;
        }

        public void AtributirCategoria(Categoria categoria)
        {
            if (!categoria.EhValido()) return;

            Categoria = categoria;
        }

        public void ExcluirEvento()
        {
            //TODO: deve validar alguma  regra?
            Excluido = true;
        }

        #endregion

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validacoes

        private void Validar()
        {
            ValidarNome();
            ValidarValor();
            ValidarLocal();

            ValidationResult = Validate(this);

            //Validacões adicionais
            ValidarEndereco();
            ValidarEmpresa();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(Resources.Evento.Erros.NOME_NULL)
                .Length(2, 150).WithMessage(Resources.Evento.Erros.NOME_LENGTH);
        }

        private void ValidarValor()
        {
            if (!Gratuito)
                RuleFor(c => c.Valor)
                    .ExclusiveBetween(1, 50000).When(a => !a.Gratuito)
                    .WithMessage(Resources.Evento.Erros.VALOR_MIN_MAX);

            if (Gratuito)
                RuleFor(c => c.Valor)
                    .Equal(0).When(a => a.Gratuito)
                    .WithMessage(Resources.Evento.Erros.VALOR_GRATUITO);
        }

        private void ValidarData()
        {
            RuleFor(c => c.DataInicio)
                .GreaterThan(c => c.DateFinal)
                .WithMessage(Resources.Evento.Erros.DATAINICIO_MAIOR_DATAFINAL);

            RuleFor(c => c.DataInicio)
                .LessThan(DateTime.Now)
                .WithMessage(Resources.Evento.Erros.DATAINICIO_MAIOR_DATAATUAL);
        }

        private void ValidarLocal()
        {
            if (!Online)
                RuleFor(c => c.Endereco)
                    .NotNull().When(a => !a.Online)
                    .WithMessage(Resources.Evento.Erros.PRESENCIAL_SEM_ENDERECO);

            if (Online)
                RuleFor(c => c.Endereco)
                .Null().When(a => a.Online)
                .WithMessage(Resources.Evento.Erros.ONLINE_COM_ENDERECO);
        }

        private void ValidarEndereco()
        {
            if (Online) return;
            if (Endereco.EhValido()) return;

            foreach (var error in Endereco.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        private void ValidarEmpresa()
        {
            RuleFor(c => c.NomeEmpresa)
                     .NotEmpty()
                     .NotNull()
                     .WithMessage(Resources.Evento.Erros.PRESENCIAL_SEM_ENDERECO);
        }

        #endregion

        public static class EventoFactory
        {
            public static Evento NovoEventoCompleto(
                      Guid id,
                      string nome,
                      DateTime dataInicio,
                      DateTime dateFinal,
                      bool gratuito,
                      decimal valor,
                      bool online,
                      string nomeEmpresa,
                      Guid? OrganizadorId,
                      Endereco endereco,
                      Guid categoriaId)
            {
                var evento = new Evento
                {
                    Id = id,
                    Nome = nome,
                    DataInicio = dataInicio,
                    DateFinal = dateFinal,
                    Gratuito = gratuito,
                    Valor = valor,
                    Online = online,
                    NomeEmpresa = nomeEmpresa
                };

                if (OrganizadorId.HasValue)
                    evento.OrganizadorId = OrganizadorId.Value;

                if (!online)
                    evento.Endereco = endereco;

                evento.CategoriaId = categoriaId;

                return evento;
            }
        }

        #region MyRegion

        #endregion
    }
}
