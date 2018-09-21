using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CS.Eventos.IO.Application.Interfaces;
using CS.Eventos.IO.Application.ViewModels;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS.Evento.IO.Site.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : BasePage
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IOrganizadorAppService _organizadorAppService;


        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IOrganizadorAppService organizadorAppService,
            IDomainNotificationHandler<DomainNotification> notifications,
            IUser user) : base(notifications, user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _organizadorAppService = organizadorAppService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a senha")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "O nome é requerido")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "O cpf é requerido")]
            [StringLength(11)]
            public string CPF { get; set; }

            [Display(Name = "E-mail")]
            [Required(ErrorMessage = "O e-mail é requerido")]
            [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
            public string Email { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    var claims = new List<System.Security.Claims.Claim>(){
                        new System.Security.Claims.Claim("Eventos", "Ler") ,
                        new System.Security.Claims.Claim("Eventos", "Gravar")};


                    await _userManager.AddClaimsAsync(user, claims);

                    var organizador = new OrganizadorViewModel()
                    {
                        id = Guid.Parse(user.Id),
                        CPF = Input.CPF,
                        Email = user.Email,
                        Nome = Input.Nome
                    };

                    _organizadorAppService.Registrar(organizador);

                    if (!OperacaoValida())
                    {
                        await _userManager.DeleteAsync(user);
                        return Page();
                    }

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
