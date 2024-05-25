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
    public class ProjetoRepository : IProjetoRepository
    {
        public void Add(Projeto projeto)
        {
            using (var context = new DataContext())
            {
                context.Add(projeto);
                context.SaveChanges();
            }
        }

        public void Update(Projeto projeto)
        {
            using (var context = new DataContext())
            {
                context.Update(projeto);
                context.SaveChanges();
            }
        }

        public void Delete(Projeto projeto)
        {
            using (var context = new DataContext())
            {
                context.Remove(projeto);
                context.SaveChanges();
            }
        }

        public List<Projeto> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<Projeto>().ToList();
            }
        }

        public List<Projeto> GetByName(string nome)
        {
            using (var context = new DataContext())
            {
                return context.Set<Projeto>().Where(p => p.Nome.Contains(nome)).ToList();
            }
        }

        public Projeto? GetById(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Set<Projeto>().Find(id);
            }
        }
    }
}
