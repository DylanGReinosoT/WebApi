using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiLibrary.Models;
using WebApiLibrary.Models.Custom;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace WebApiLibrary.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly EventosContext _context;
        private readonly IConfiguration _configuration;

        public AutorizacionService(EventosContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerarToken(string IdUsuarios)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,IdUsuarios));

            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;

        }


        public async Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            var usuario_encontrado = _context.Usuarios.FirstOrDefault(x => 
                x.NombreUsuario == autorizacion.NombreUsuario &&
                x.Clave == autorizacion.Clave
            );

            if (usuario_encontrado == null)
            {
                return await Task.FromResult<AutorizacionResponse>(null);

            }

            string tokenCreado = GenerarToken(usuario_encontrado.IdUsuarios.ToString());

            return new AutorizacionResponse() { Token= tokenCreado, Resultado= true, Msg="Ok"};
        }
    }
}
