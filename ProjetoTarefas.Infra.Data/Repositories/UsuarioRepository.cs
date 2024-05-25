using Microsoft.EntityFrameworkCore;
using ProjetosApp.Domain.Entities;
using ProjetosApp.Domain.Interfaces.Repositories;
using ProjetosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosApp.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            using(var context = new DataContext())
            {
                context.Add(usuario);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Consultar um usuário no banco de dados através do email
        /// </summary>
        public Usuario? GetByEmail(string email)
        {
            using (var context = new DataContext())
            {
                //SQL -> SELECT * FROM USUARIO WHERE EMAIL = @Email
                return context.Set<Usuario>()
                    .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public Usuario? GetByEmailAndPassword(string email, string senha)
        {
            using (var context = new DataContext())
            {
                //SQL -> SELECT * FROM USUARIO WHERE EMAIL = @email AND SENHA = @senha
                return context
                    .Set<Usuario>()
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));
            }
        }

        public Usuario? GetById(Guid id)
        {
            using(var context = new DataContext())
            {
                return context.Set<Usuario>()
                    .Include(u => u.Projetos)
                    .Where(u => u.Id == id)
                    .FirstOrDefault();
            }
        }
    }
}
