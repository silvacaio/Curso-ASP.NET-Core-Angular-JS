using AutoMapper;
using CS.Eventos.IO.Application.ViewModels;
using CS.Eventos.IO.Domain.Eventos;
using CS.Eventos.IO.Domain.Organizadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Eventos.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Organizador, OrganizadorViewModel>();
        }
    }
}
