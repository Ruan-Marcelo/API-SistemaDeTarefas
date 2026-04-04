using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaDeTarefasAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaDeTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if(login.Login == "admin" && login.Senha == "admin")
            {
                var token = GerarTokenJWT();
                return Ok(new { token });
            }


            return BadRequest(new { mensagem = "Credenciais invalidas ou incorretas, verifique sua senha e login novamente"});
        }

        private string GerarTokenJWT()
        {
            string chaveSecreta = "a5ee28f6-fe3a-4342-97a0-7145ab5cf1d0";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Login","admin"),
                 new Claim("nome","Administrador do sistema"),
            };

            var token = new JwtSecurityToken(
                issuer: "Sua_empresa",
                audience: "Sua_aplicacao",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
