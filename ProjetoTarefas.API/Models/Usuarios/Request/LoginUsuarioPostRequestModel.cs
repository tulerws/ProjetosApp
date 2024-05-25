using System.ComponentModel.DataAnnotations;

namespace ProjetosApp.API.Models.Usuarios.Request
{
    public class LoginUsuarioPostRequestModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email de acesso.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, insira sua senha.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        public string? Senha { get; set; }
    }
}
