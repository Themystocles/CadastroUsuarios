public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Usuario usuarioParaExcluir = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuarioParaExcluir != null)
            {
                // O usuário foi encontrado, então podemos excluí-lo
                _context.Usuarios.Remove(usuarioParaExcluir);
                _context.SaveChanges();
            }
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Get(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void Update(Usuario usuario)
        {
            var existingUsuarios = _context.Usuarios.Find(usuario.Id);

            if (existingUsuarios != null)
            {
               
                existingUsuarios.Nome = usuario.Nome;
                existingUsuarios.Profissao = usuario.Profissao;
                existingUsuarios.Idade = usuario.Idade;
                

                _context.SaveChanges();
            }
        }
       
    }