 public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        List<Usuario> Get();

        Usuario Get(int id);

        void Update(Usuario usuario);

        void Delete(int id);

        

    }
