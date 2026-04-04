using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefasAPI.Models;

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
                return Ok(new { token = "xpto"});
            }
            return BadRequest(new { mensagem = "Credenciais invalidas ou incorretas, verifique sua senha e login novamente"});
        }
    }
}
