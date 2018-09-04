using AutoMapper;
using CS.Eventos.IO.Application.ViewModels;
using CS.Eventos.IO.Domain.Eventos.Commands;

namespace CS.Eventos.IO.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EventoViewModel, RegistrarEventoCommand>()
                .ConstructUsing(c => new RegistrarEventoCommand(c.Nome, c.DescricaoCurta, c.DescricaoLonga, c.DataInicio, c.DateFinal, c.Gratuito, c.Valor, c.Online, c.NomeEmpresa, c.OrganizadorId, c.CategoriaId,
                                         new IncluirEnderecoEventoCommand(c.Endereco.Id, c.Endereco.Logradouro, c.Endereco.Numero, c.Endereco.Complemento, c.Endereco.Bairro, c.Endereco.CEP, c.Endereco.Cidade, c.Endereco.Estado, c.Id)));

            CreateMap<EnderecoViewModel, IncluirEnderecoEventoCommand>()
                .ConstructUsing(c => new IncluirEnderecoEventoCommand(c.Id, c.Logradouro, c.Numero, c.Complemento, c.Bairro, c.CEP, c.Cidade, c.Estado, c.EventoId));

            CreateMap<EventoViewModel, AtualizarEventoCommand>()
               .ConstructUsing(c => new AtualizarEventoCommand(c.Id, c.Nome, c.DescricaoCurta, c.DescricaoLonga, c.DataInicio, c.DateFinal, c.Gratuito, c.Valor, c.Online, c.NomeEmpresa, c.OrganizadorId, c.CategoriaId));

            CreateMap<EventoViewModel, RemoverEventoCommand>()
              .ConstructUsing(c => new RemoverEventoCommand(c.Id));
        }
    }
}
