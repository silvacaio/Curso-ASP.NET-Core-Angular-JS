using CS.Eventos.IO.Domain.Core.Bus;
using CS.Eventos.IO.Domain.Core.Notifications;
using CS.Eventos.IO.Domain.Interfaces;
using CS.Eventos.IO.Domain.Organizadores.Commands;
using CS.Eventos.IO.Domain.Organizadores.Repository;
using CS.Eventos.IO.Infra.CrossCutting.Identity.Authorization;
using CS.Eventos.IO.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CS.Eventos.IO.Services.Api.Controllers
{
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signanager;
        private readonly ILogger _logger;
        private readonly IBus _bus;
        private readonly TokenDescriptor _tokenDescriptor;
        private readonly IOrganizadorRepository _organizadorRepository;

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public AccountController(IDomainNotificationHandler<DomainNotification> notifications,
                                 IUser user,
                                 UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signanager,
                                 ILoggerFactory logger,
                                 IBus bus,
                                 TokenDescriptor tokenDescriptor,
                                 IOrganizadorRepository organizadorRepository) : base(notifications, user, bus)
        {

            _userManager = userManager;
            _signanager = signanager;
            _bus = bus;
            _logger = logger.CreateLogger<AccountController>();
            _tokenDescriptor = tokenDescriptor;
            _organizadorRepository = organizadorRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("nova-conta")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model, int version)
        {
            if (version == 2)
            {
                return Response(new { Message = "API V2 não disponivel" });
            }

            if (!ModelState.IsValid)
            {
                NotificarErrorModelInvalida();
                return Response(model);
            }

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                var registroCommand = new RegistrarOrganizadorCommand(Guid.Parse(user.Id), model.Nome, model.CPF, model.Email);
                _bus.SendCommand(registroCommand);

                if (!OperacaoValida())
                {
                    await _userManager.DeleteAsync(user);
                    return Response(model);
                }

                _logger.LogInformation(1, "Usuário criado com sucesso!");

                var response = GerarTokenUsuario(new LoginViewModel { Email = model.Email, Senha = model.Senha });
                return Response(response);
            }

            AdicionarErrorIdentity(result);
            return Response(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("conta")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErrorModelInvalida();
                return Response(model);
            }

            var result = await _signanager.PasswordSignInAsync(model.Email, model.Senha, false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                _logger.LogInformation(1, "Usuário logado com sucesso.");

                var response = await GerarTokenUsuario(model);
                return Response(response);
            }

            NotificarErro(result.ToString(), "Falha ao realizar o login.");
            return Response(model);
        }

        private async Task<object> GerarTokenUsuario(LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            var userClaims = await _userManager.GetClaimsAsync(user);

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            // Necessário converver para IdentityClaims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(userClaims);

            var handler = new JwtSecurityTokenHandler();
            var signingConf = new SigningCredentialsConfiguration();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenDescriptor.Issuer,
                Audience = _tokenDescriptor.Audience,
                SigningCredentials = signingConf.SigningCredentials,
                Subject = identityClaims,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(_tokenDescriptor.MinutesValid)
            });

            var encodedJwt = handler.WriteToken(securityToken);
            var orgUser = _organizadorRepository.ObterPorId(Guid.Parse(user.Id));

            var response = new
            {
                access_token = encodedJwt,
                expires_in = DateTime.Now.AddMinutes(_tokenDescriptor.MinutesValid),
                user = new
                {
                    id = user.Id,
                    nome = orgUser.Nome,
                    email = orgUser.Email,
                    claims = userClaims.Select(c => new { c.Type, c.Value })
                }
            };

            return response;
        }

        private void AdicionarErrorIdentity(IdentityResult result)
        {
            foreach (var item in result.Errors)
            {
                NotificarErro(item.ToString(), item.Description);
            }
        }
    }
}