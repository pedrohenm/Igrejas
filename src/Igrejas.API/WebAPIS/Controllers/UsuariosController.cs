using Entities.Entidades;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebAPIS.Models;
using WebAPIS.Token;

namespace WebAPIS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : 
        ControllerBase
    {
        private readonly UserManager<UsuarioAplicacao> _userManager;
        private readonly SignInManager<UsuarioAplicacao> _signInManager;

        public UsuariosController(
            UserManager<UsuarioAplicacao> userManager, 
            SignInManager<UsuarioAplicacao> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/Entrar")]
        public async Task<IActionResult> CriarTokenIdentity(
            [FromBody] Login login)
        {
            if(string.IsNullOrWhiteSpace(login.Email)
               || string.IsNullOrWhiteSpace(login.Senha))
                return Unauthorized();

            var resultadoAutenticacao = await _signInManager.PasswordSignInAsync(
                login.Email,
                login.Senha,
                false,
                false);

            if (resultadoAutenticacao.Succeeded)
            {
                var usuarioLogado = await _userManager.
                    FindByEmailAsync(login.Email);

                var usuarioId = usuarioLogado.Id;

                var token = new TokenJWTConstrutor()
                    .AddSecuityKey(JwtChaveSeguranca.Criar("Secret_Key_12345678"))
                    .AddSubject("Empresa - Igrejas")
                    .AddIssuer("Teste.Security.Bearer")
                    .AddAudience("Teste.Security.Bearer")
                    .AddClaims("idUsuario", usuarioId)
                    .AddExpiry(5)
                    .Builder();

                return Ok(token);
            }
            else
                return Unauthorized();
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/Registrar")]
        public async Task<IActionResult> AdicionarUsuarioIdentity(
            [FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email)
               || string.IsNullOrWhiteSpace(login.Senha))
                return Ok("Faltam alguns dados");

            var usuario = new UsuarioAplicacao
            {
                UserName = login.Email,
                Email = login.Email,
                CPF = login.CPF,
                TipoUsuario = TipoUsuario.Comum
            };

            var resultadoCriacao = await _userManager.CreateAsync(
                usuario, 
                login.Senha);

            if (resultadoCriacao.Errors.Any())
                return Ok(resultadoCriacao.Errors);

            var idUsuario = await _userManager
                .GetUserIdAsync(usuario);

            var codigo = await _userManager
                .GenerateEmailConfirmationTokenAsync(usuario);
            codigo = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(codigo));

            codigo = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(codigo));
            var resultadoConfirmacao = await _userManager.ConfirmEmailAsync(usuario, codigo);

            if (resultadoConfirmacao.Succeeded)
                return Ok("Usuario adicionado com sucesso");
            else
                return Ok("Erro ao confirmar o usuario");
        }
    }
}
