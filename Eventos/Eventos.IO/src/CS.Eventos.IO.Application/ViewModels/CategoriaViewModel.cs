using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Eventos.IO.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }

        public SelectList Categorias()
        {
            return new SelectList(ListarCategorias(), "Id", "Nome");
        }

        public static List<CategoriaViewModel> ListarCategorias()
        {
            return new List<CategoriaViewModel>()
            {
                new CategoriaViewModel() { Id = Guid.Parse("5abe6c7b-0960-49f5-93d8-9cedc2ad6ea4"), Nome= "TDC POA" },
                new CategoriaViewModel() { Id =Guid.NewGuid(), Nome= "Teste1" },
                new CategoriaViewModel() { Id =Guid.NewGuid(), Nome= "Teste2" }
            };
        }
    }
}
