﻿using System.ComponentModel.DataAnnotations;

namespace CS.Eventos.IO.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
