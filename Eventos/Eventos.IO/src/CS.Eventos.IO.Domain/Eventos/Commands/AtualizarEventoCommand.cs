using System;

namespace CS.Eventos.IO.Domain.Eventos.Commands
{
    public class AtualizarEventoCommand : BaseEventoCommand
    {
        public AtualizarEventoCommand(
                    Guid id,
                    string nome,
                    string descCurta,
                    string descLonga,
                    DateTime dataInicio,
                    DateTime dateFinal,
                    bool gratuito,
                    decimal valor,
                    bool online,
                    string nomeEmpresa,
                    Guid organizadorId,
                    Guid categoriaId)
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
            OrganizadorId = organizadorId;
            CategoriaId = categoriaId;
        }

    }
}
