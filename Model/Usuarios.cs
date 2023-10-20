using System.ComponentModel.DataAnnotations.Schema;

[Table("usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public int Idade { get; set; }
    }

