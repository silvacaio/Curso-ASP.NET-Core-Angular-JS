using System;

namespace CS.Eventos.IO.Domain.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(string nome,
                     string descricaoCurta,
                     string descricaoLonga,
                     DateTime dataInicio,
                     DateTime dateFinal,
                     bool gratuito,
                     decimal valor,
                     bool online,
                     string nomeEmpresa,
                     Guid organizadorId,
                     Guid categoriaId,
                     IncluirEnderecoEventoCommand endereco)
        {
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataInicio = dataInicio;
            DateFinal = dateFinal;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
            OrganizadorId = organizadorId;
            CategoriaId = categoriaId;
            Endereco = endereco;
        }

        public IncluirEnderecoEventoCommand Endereco { get; private set; }
    }
}
