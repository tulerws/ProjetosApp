namespace ProjetosApp.API.Models.Usuarios.Response
{
    /// <summary>
    /// Modelo de dados para autenticação de usuários na API
    /// </summary>
    public class LoginUsuarioPostResponseModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataHoraAcesso { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? DataHoraExpiracao { get; set; }
    }
}
