using System.Collections.Generic;

namespace CS.Eventos.IO.Application.ViewModels
{
    public class EstadoViewModel
    {
        public string UF { get; set; }
        public string Nome { get; set; }

        public static List<EstadoViewModel> ListarEstados()
        {
            return new List<EstadoViewModel>();
        }
    }
}
