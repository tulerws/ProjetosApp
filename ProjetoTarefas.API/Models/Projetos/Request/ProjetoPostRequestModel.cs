using Newtonsoft.Json;
using ProjetosApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjetosApp.API.Models.Projetos.Request
{
    public class ProjetoPostRequestModel
    {
        public Guid Id { get; set; }

        [MinLength(5, ErrorMessage = "Por favor informe no mínimo {1} caracteres")]
        [MaxLength(60, ErrorMessage = "Por favor informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe o nome do projeto")]
        public string? Nome { get; set; }

        [MinLength(10, ErrorMessage = "Por favor informe no mínimo {1} caracteres")]
        [Required(ErrorMessage = "Por favor, informe uma descricao para o projeto")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Insira a categoria do projeto")]
        public int? Categoria { get; set; }

        [Required(ErrorMessage = "Informe uma data de início")]
        public DateTime? DataInicio { get; set; }

        public DateTime? DataEntrega {  get; set; }

        public Status? Status { get; set; }
    }
}
