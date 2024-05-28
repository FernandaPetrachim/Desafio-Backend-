namespace UsuariosAPI.models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; } 
        public string? Email { get; set; }
        public string? SenhaHash { get; set; }
        public string? CPF { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
