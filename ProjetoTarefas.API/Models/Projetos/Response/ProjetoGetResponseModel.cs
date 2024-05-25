using ProjetosApp.Domain.Enums;

namespace ProjetosApp.API.Models.Projetos.Response
{
    public class ProjetoGetResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public CategoriaProjeto? Categoria { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataEntrega { get; set; }
        public Status? Status { get; set; }
    }
}
