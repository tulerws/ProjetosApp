using System.ComponentModel.DataAnnotations;

namespace ProjetosApp.API.Models.Usuarios.Request
{
    /// <summary>
    /// Modelo de dados para a requisição de cadastro de usuários na API
    /// </summary>
    public class CriarUsuarioPostRequestModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informeno máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe um nome")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereco de email válido")]
        [Required(ErrorMessage = "Por favor, informe um endereco de email")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,50}$",
            ErrorMessage = "Por favor, informe uma senha com pelo menos estes requisitos: 1 Letra maiúscula, 1 minúscula, 1 número, 1 caracter especial e entre 8 e 50 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe uma senha")]
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem, por favor verifique.")]
        [Required(ErrorMessage = "Por favor, confirme a senha do usuário.")]
        public string? SenhaConfirmacao { get; set; }
    }
}
