using CS.Eventos.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CS.Eventos.IO.Domain.Models
{
    public class Evento : Entity<Evento>
    {
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

            if (nome.Length < 3)
                throw new ArgumentException("O nome do evento deve ter mais de 3 caracteres.");

            if (gratuito && valor != 0)
                throw new ArgumentException("Não pode ter valor se gratuito.");
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
        public Categoria Categoria { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        public Endereco Endereco { get; private set; }
        public Organizador Organizador { get; private set; }

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
                    .ExclusiveBetween(0, 0).When(a => a.Gratuito)
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

        //valida Nome empresa

        #endregion
    }
}
