using Microsoft.AspNetCore.Mvc;

namespace SuaAplicacao.Controllers
{
   [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = _usuarioRepository.Get();
            return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _usuarioRepository.Get(id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado"); // Retorna 404 Not Found se o usuário não for encontrado.
            }

            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Nenhum usuario foi cadastrado. opção cancelada."); // Retorna 400 Bad Request se o objeto for nulo.
            }

            _usuarioRepository.Add(usuario);
            return CreatedAtAction("Get", new { id = usuario.Id }, usuario); // Retorna 201 Created.
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(); // Retorna 400 Bad Request se o objeto for nulo.
            }

            var existingUsuario = _usuarioRepository.Get(id);

            if (existingUsuario == null)
            {
                return NotFound(); // Retorna 404 Not Found se o usuário não for encontrado.
            }

            usuario.Id = id; // Certifica-se de que o ID do usuário corresponda ao parâmetro de rota.

            _usuarioRepository.Update(usuario);
            return NoContent(); // Retorna 204 No Content.
        }

         
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingUsuario = _usuarioRepository.Get(id);

            if (existingUsuario == null)
            {
                return NotFound("Usuario não encontrado"); 
            }

            _usuarioRepository.Delete(id);
            return Ok(new { Message = "Usuário deletado com sucesso"} );
        }
    }
}
