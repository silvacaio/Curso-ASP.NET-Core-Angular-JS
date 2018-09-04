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
                new CategoriaViewModel() { Id =Guid.NewGuid(), Nome= "Teste" },
                new CategoriaViewModel() { Id =Guid.NewGuid(), Nome= "Teste1" },
                new CategoriaViewModel() { Id =Guid.NewGuid(), Nome= "Teste2" }
            };
        }
    }
}
