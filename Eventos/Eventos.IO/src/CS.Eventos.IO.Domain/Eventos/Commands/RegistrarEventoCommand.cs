using System;

namespace CS.Eventos.IO.Domain.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(string nome,
                     DateTime dataInicio,
                     DateTime dateFinal,
                     bool gratuito,
                     decimal valor,
                     bool online,
                     string nomeEmpresa,
                     Guid organizadorId,
                     Endereco endereco,
                     Categoria categoria)
        {         
            Nome = nome;
            DataInicio = dataInicio;
            DateFinal = dateFinal;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
            OrganizadorId = organizadorId;
            Endereco = endereco;
            Categoria = categoria;
        }       
    }
}
