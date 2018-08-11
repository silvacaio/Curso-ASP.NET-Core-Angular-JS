using System;
using System.Collections.Generic;

namespace StartupDemo.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime Data { get; set; }
    }

    public class Categoria
    {
        public string Tipo { get; set; }
    }

    //ViewModel
    public class EventoCategoriaViewModel
    {
        public Evento Evento { get; set; }
        public IEnumerable<Categoria> Categoria { get; set; }
    }
}
