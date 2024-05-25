using ProjetosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        //Serve pra ver se no banco já existe um usuario com o mesmo email.
        Usuario? GetByEmail(string email);

        Usuario? GetByEmailAndPassword(string email, string senha);

        Usuario? GetById(Guid id);
    }
}
