using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using BTech.DataAccess.Context;
using BTech.DataAccess.Entities;
using BTech.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BTech.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
	public class LoginController : Controller
    {
		private readonly BTContext db;

		public LoginController(BTContext context)
		{
			db = context;
		}

		[AllowAnonymous, HttpPost]
		public object PostLogin([FromBody] Pessoa usuario, [FromServices] TokenConfiguration tokenConfigurations, [FromServices] SigningConfigurations signingConfigurations)
		{
			if (!db.Pessoas.Any(p => p.Login == usuario.Login))
			{
				return NotFound();
			}

			ClaimsIdentity identity = new ClaimsIdentity(
					new GenericIdentity(usuario.Login, "Login"),
					new[] {
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
						new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login)
					}
				);

			DateTime dataCriacao = DateTime.Now;
			DateTime dataExpiracao = dataCriacao.AddSeconds(tokenConfigurations.Seconds);

			var handler = new JwtSecurityTokenHandler();
			var securityToken = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = tokenConfigurations.Issuer,
				Audience = tokenConfigurations.Audience,
				SigningCredentials = signingConfigurations.signingCredentials,
				Subject = identity,
				NotBefore = dataCriacao,
				Expires = dataExpiracao
			});

			var token = handler.WriteToken(securityToken);

			return new
			{
				authenticated = true,
				created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
				expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
				accessToken = token,
				message = "Ok"
			};
		}
    }
}