using System.Linq;
using System.Threading.Tasks;
using BlogDoXim.ApiDados.Services;
using BlogDoXim.ApiDados.ViewModels;
using BlogDoXim.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogDoXim.ApiDados.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly BlogDoXimContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(BlogDoXimContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioTokenAuthentication>> Autenticar([FromBody]LoginAuthentication usuario)
        {
            var usuarioResult = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == usuario.UserName && x.Senha == usuario.Password);
            if (usuarioResult == null)
                return NotFound();

            var strSecretKey = _configuration.GetSection("Jwt").GetValue<string>("SecretKey");
            var model = new UsuarioTokenAuthentication
            {
                UsuarioId = usuarioResult.UsuarioId,
                NomeUsuario = usuarioResult.Nome,
                LoginUsuario = usuarioResult.Login,
                Token = TokenService.GerarToken(usuarioResult, strSecretKey)
            }; 

            return model;
        }
    }
}