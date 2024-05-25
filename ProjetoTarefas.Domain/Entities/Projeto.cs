using ProjetosApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosApp.Domain.Entities
{
    public class Projeto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public CategoriaProjeto Categoria { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataEntrega { get; set; }
        public Status? Status { get; set; }
        public Guid UsuarioId { get; set; }

        #region Relacionamentos

        public List<Usuario>? Usuarios { get; set; }

        #endregion


    }
}
