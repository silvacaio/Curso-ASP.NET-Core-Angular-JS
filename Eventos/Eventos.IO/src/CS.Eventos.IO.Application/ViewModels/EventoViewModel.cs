using System;
using System.ComponentModel.DataAnnotations;

namespace CS.Eventos.IO.Application.ViewModels
{
    public class EventoViewModel
    {
        public EventoViewModel()
        {
            Id = Guid.NewGuid();
            Endereco = new EnderecoViewModel();
            Categoria = new CategoriaViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requirido")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo do nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do nome é {1}")]
        [Display(Name = "Nome do Evento")]
        public string Nome { get; set; }

        [Display(Name = "Descrição curta do evento")]
        public string DescricaoCurta { get; set; }

        [Display(Name = "Descrição longa do evento")]
        public string DescricaoLonga { get; set; }

        [Display(Name = "Inicio do evento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Fim do evento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateFinal { get; set; }

        [Display(Name = "Será gratuito?")]
        public bool Gratuito { get; set; }

        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Será Online?")]
        public bool Online { get; set; }

        [Display(Name = "Empresa")]
        public string NomeEmpresa { get; set; }
        
        public EnderecoViewModel Endereco { get; set; }

        public CategoriaViewModel Categoria { get; set; }

        public Guid CategoriaId { get; set; }
        public Guid OrganizadorId { get; set; }
        
    }
}
