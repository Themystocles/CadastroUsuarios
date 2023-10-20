using Microsoft.AspNetCore.Mvc;

namespace SuaAplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("Exemplo")]
        public ActionResult<string> GetExemplo()
        {
            return "Isso é um exemplo de retorno da API";
        }
    }
}
